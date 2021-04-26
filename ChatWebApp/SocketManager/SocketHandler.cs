using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
namespace net_core_chat.SocketManager
{
    public abstract class SocketHandler
    {
        public ConectionManager Conections {get; set;}

        public SocketHandler(ConectionManager conections){
            this.Conections = conections;
        }

        public virtual async Task OnConnected(WebSocket socket){
            await Task.Run(()=>{this.Conections.AddSocket(socket);});
        }

        public virtual async Task OnDisconnected(WebSocket socket){
            await this.Conections.RemoveSocketAsync(this.Conections.GetId(socket));
        }

        public async Task SendMessage(WebSocket socket, string message){
            if(socket.State != WebSocketState.Open)
                return;
            await socket.SendAsync(new System.ArraySegment<byte>(Encoding.ASCII.GetBytes(message),0, message.Length),
            WebSocketMessageType.Text, 
            true,
            CancellationToken.None);
        }

        public async Task SendMessage(string id, string message){
            await SendMessage(Conections.GetSocketById(id), message);
        }

        public async Task sendMessageToAll(string message){
            foreach(var con in Conections.GetAllConnections())
                await SendMessage(con.Value, message);
        }

        public abstract Task Recive(WebSocket socket, WebSocketReceiveResult result, byte[] byffer);

    }
}