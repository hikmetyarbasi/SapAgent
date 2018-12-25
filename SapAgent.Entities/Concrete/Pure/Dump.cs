using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("Dump", Schema = "Pure")]
    public partial class Dump:IDump
    {
        public int ID { get; set; }

        public DateTime? DATUM { get; set; }

        public TimeSpan? UZEIT { get; set; }

        [StringLength(200)]
        public string AHOST { get; set; }

        [StringLength(100)]
        public string UNAME { get; set; }

        [StringLength(10)]
        public string MANDT { get; set; }

        [StringLength(1)]
        public string XHOLD { get; set; }

        [StringLength(100)]
        public string ERRORID { get; set; }

        [StringLength(200)]
        public string REXCEPTION { get; set; }

        [StringLength(200)]
        public string COMPONENT { get; set; }

        [StringLength(200)]
        public string GPROGRAM { get; set; }

        public int? MODNO { get; set; }

        [StringLength(200)]
        public string TID { get; set; }
    }
}
