using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Config
{
    [Table("SysListNotify",Schema = "Config")]
    public class SysListNotify : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int FuncId { get; set; }
        public string Desc { get; set; }
        public int Case { get; set; }
        public DateTime Date { get; set; }
        public int Level { get; set; }
        public int Statu { get; set; }
        public int CustomerProductId { get; set; }

    }
}
