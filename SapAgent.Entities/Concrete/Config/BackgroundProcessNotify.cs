using System;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Config
{
    [Table("BackgroundProcessNotify", Schema = "Config")]
    public class BackgroundProcessNotify : IEntity
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string FuncName { get; set; }
        public string Desc { get; set; }
        public int Case { get; set; }
        public DateTime Date { get; set; }
        public int Level { get; set; }
        public int Statu { get; set; }
        public int CustomerProductId { get; set; }
    }
}
