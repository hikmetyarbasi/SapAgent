using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SapAgent.Entities.Concrete.General
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }
        public DateTime InsertDate { get; set; }

    }
}
