using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.General
{
    public class CustomerProductView : IEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int CustomerProductId { get; set; }
    }
}
