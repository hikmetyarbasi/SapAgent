using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;


namespace SapAgent.Entities.Concrete.General
{
    [Table("CustomerProductRl", Schema = "dbo")]
    public class CustomerProductRl : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int ClientId { get; set; }
        public bool Enable { get; set; }
        public DateTime Insertdate { get; set; }
    }
}
