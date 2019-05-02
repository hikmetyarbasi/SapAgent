using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Config
{
    [Table("SysFile",Schema = "Config")]
    public class SysFile : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Server { get; set; }
        public string SysName { get; set; }
        public int Buffer { get; set; }
        public int WarningRange { get; set; }
        public int ErrorRange { get; set; }
        public int Limit { get; set; }
    }
}
