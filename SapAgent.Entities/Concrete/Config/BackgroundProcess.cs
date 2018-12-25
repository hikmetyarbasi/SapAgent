using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Config
{
    [Table("BackgroundProcess", Schema = "Config")]
    public class BackgroundProcess : IEntity
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public int Latency { get; set; }
        public int Duration { get; set; }
        public int AvgWorkTime { get; set; }
        public TimeSpan Starttime { get; set; }
        public int ClientId { get; set; }
    }
}
