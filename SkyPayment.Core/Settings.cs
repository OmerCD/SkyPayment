namespace SkyPayment.Core
{
    public class Settings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Token Token { get; set; }
    }

    public class ConnectionStrings
    {
        public string MongoDb { get; set; }
    }
    public class Token
    {
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
    }
}