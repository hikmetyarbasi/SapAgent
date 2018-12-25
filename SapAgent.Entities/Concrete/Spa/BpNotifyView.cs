using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Spa
{   
    [Table("BP_NOTIFY_VIEW", Schema = "dbo")]
    public class BpNotifyView : IEntity
    {
        [Key]
        public int CustomerProductId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int Level { get; set; }
        public int Amount { get; set; }
    }
}
