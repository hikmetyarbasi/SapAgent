using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("RtmInfoBase", Schema = "Pure")]
    public  class RtmInfoBase : IEntity
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int ID { get; set; }

        [StringLength(200)]
        public string SERVER { get; set; }

        public string STARTUPDATE { get; set; }

        public string STARTUPTIME { get; set; }
        public Guid SREQINDEX { get; set; }
    }
}
