namespace net_core_chat.Models
{
    public class ChatDatabaseSettings : IChatDatabaseSettings
    {
        public string MessageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IChatDatabaseSettings
    {
        string MessageCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
