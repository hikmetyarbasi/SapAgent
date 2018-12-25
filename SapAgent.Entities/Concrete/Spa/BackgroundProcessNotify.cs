namespace SapAgent.Entities.Concrete.Spa
{
    public class BackgroundProcessNotify
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }
    }
}
