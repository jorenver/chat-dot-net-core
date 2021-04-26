using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using net_core_chat.Models;
using net_core_chat.Services;
using Newtonsoft.Json.Linq;

namespace net_core_chat.SocketManager
{
    public class WebSocketMessageHandler: SocketHandler
    {
        private readonly MessageService _messageService;
        public WebSocketMessageHandler(ConectionManager connections, MessageService messageService): base(connections){
            _messageService = messageService;
        }
        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
            var socketId = Conections.GetId(socket);
            Console.WriteLine($"{socketId} is connected");
            //await sendMessageToAll($"{socketId} just joined the party *****");
        }

        public override async Task Recive(WebSocket socket, WebSocketReceiveResult result, byte[] byffer){
            var socketId = Conections.GetId(socket);
            var messageRecived = Encoding.UTF8.GetString(byffer, 0, result.Count);
            Console.WriteLine(messageRecived);
            try{
                JObject messageObject = JObject.Parse(messageRecived);
                string name = messageObject["name"].Value<string>();
                string text = messageObject["message"].Value<string>();
                Message msg = new Message{
                    OwnerName = name,
                    Text = text
                };
                Message msgInserted  =_messageService.Create(msg);
                string messageTosend = JObject.FromObject(msgInserted).ToString();
                Console.WriteLine(messageTosend);
                await sendMessageToAll(messageTosend);
            }catch(Exception e){
                Console.WriteLine(e.Message);
            } 
        }
    }
}