using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.General
{
    [Table("CUSTOMER_PRODUCT_VIEW", Schema = "dbo")]
    public class CustomerProductView : IEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        [Key]
        public int CustomerProductId { get; set; }
    }
}
