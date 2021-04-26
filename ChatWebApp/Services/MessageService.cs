using net_core_chat.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace net_core_chat.Services
{
    public class MessageService
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageService(IChatDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Message>(settings.MessageCollectionName);
        }

        public List<Message> Get() =>
            _messages.Find(message => true).ToList();

        public Message Get(string id) =>
            _messages.Find<Message>(message => message.Id == id).FirstOrDefault();

        public Message Create(Message message)
        {
            _messages.InsertOne(message);
            return message;
        }

        public void Update(string id, Message messageIn) =>
            _messages.ReplaceOne(message => message.Id == id, messageIn);

        public void Remove(Message messageIn) =>
            _messages.DeleteOne(message => message.Id == messageIn.Id);

        public void Remove(string id) => 
            _messages.DeleteOne(message => message.Id == id);
    }
}