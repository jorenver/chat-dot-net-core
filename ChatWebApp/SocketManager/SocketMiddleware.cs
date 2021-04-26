using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Threading;

namespace net_core_chat.SocketManager
{
    public class SocketMiddleware
    {
        private readonly RequestDelegate _next;
        private SocketHandler Handler {get;set;}
        
        public SocketMiddleware(RequestDelegate next, SocketHandler handler){
            _next = next;
            Handler = handler;
        }

        public async Task InvokeAsync(HttpContext context){
            if(!context.WebSockets.IsWebSocketRequest)
                return;
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            await Handler.OnConnected(socket);
            await Recive(socket, async (result, buffer) => {
                if (result.MessageType == WebSocketMessageType.Text){
                    await Handler.Recive(socket, result, buffer);
                }else if (result.MessageType == WebSocketMessageType.Close){
                    await Handler.OnDisconnected(socket);
                }
            });
        }

        private async Task Recive(WebSocket webSocket, Action<WebSocketReceiveResult, byte[]> messageHandle){
            var buffer = new byte[1024*4];
            while(webSocket.State == WebSocketState.Open){
                var result = await webSocket.ReceiveAsync( new System.ArraySegment<byte>(buffer), CancellationToken.None);
                messageHandle(result, buffer);
            }
        }
    }
}