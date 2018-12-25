using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SapAgent.Entities.Concrete.General
{
    [Table("Client",Schema = "dbo")]
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public string Desc { get; set; }
    }
}
