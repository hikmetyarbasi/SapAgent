using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("RtmInfoBase", Schema = "Pure")]
    public partial class RtmInfoBase:IEntity
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string SERVER { get; set; }

        public DateTime? STARTUPDATE { get; set; }

        public TimeSpan? STARTUPTIME { get; set; }
    }
}
