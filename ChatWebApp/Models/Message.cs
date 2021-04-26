using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using  Newtonsoft.Json;

namespace net_core_chat.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [JsonProperty("ownerName")]
        public string OwnerName { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}