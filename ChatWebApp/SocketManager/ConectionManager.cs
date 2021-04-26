using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;

namespace net_core_chat.SocketManager
{
    public class ConectionManager
    {
        private ConcurrentDictionary<string, WebSocket> _conections = new ConcurrentDictionary<string, WebSocket>(); 
    
        public WebSocket GetSocketById(string id){
            return _conections.FirstOrDefault(x => x.Key == id).Value;
        }

        public ConcurrentDictionary<string, WebSocket> GetAllConnections(){
            return _conections;
        }

        public string GetId(WebSocket socket){
            return _conections.FirstOrDefault(x => x.Value == socket).Key;
        }

        public async Task RemoveSocketAsync(string id){
            _conections.TryRemove(id, out var socket);
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, 
            "socket connection closed",
            CancellationToken.None);
        }

        public void AddSocket(WebSocket socket){
            _conections.TryAdd(GetConectionId(), socket);
        }

        private string GetConectionId(){
            return Guid.NewGuid().ToString("N");
        }

    }
}