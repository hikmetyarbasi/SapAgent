using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SapAgent.Entities.Concrete.General
{
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
