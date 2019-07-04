using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Config
{
    [Table("Scheduler", Schema = "Config")]
    public class Scheduler : IEntity
    {
        [Key]
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int FuncId { get; set; }
        public int ProductId { get; set; }
        public string EngineMethod { get; set; }
        public int ScheduleType { get; set; }
        public DateTime StartTime { get; set; }
        public int RecurEvery { get; set; }
        [Column(TypeName = "xml")]
        public string WeekOn { get; set; }
        [NotMapped]
        public XmlDocument MyDocument { get; set; }
    }
}
