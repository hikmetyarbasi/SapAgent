using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;
using SapAgent.Entities.Concrete.General.@enum;

namespace SapAgent.Entities.Concrete.Config
{
    [Table("Dump", Schema = "Config")]
    public class Dump : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public string ErrorId { get; set; }
        public int Buffer { get; set; }
        public int WarningRange { get; set; }
        public int ErrorRange { get; set; }
        public int Critical { get; set; }
        public int Limit { get; set; }
    }
}
