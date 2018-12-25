using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("Lock", Schema = "Pure")]
    public partial class Lock : IEntity
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string GCLIENT { get; set; }

        [StringLength(200)]
        public string GTHOST { get; set; }

        [StringLength(50)]
        public string GUNAME { get; set; }

        [StringLength(80)]
        public string GDSPTIME { get; set; }

        [StringLength(10)]
        public string GMODE { get; set; }

        [StringLength(100)]
        public string GNAME { get; set; }
        [StringLength(100)]
        public string GARG { get; set; }

        [StringLength(300)]
        public string GUSR { get; set; }

        [StringLength(300)]
        public string GUSRVB { get; set; }

        public int? GUSE { get; set; }

        public int? GUSEVB { get; set; }

        [StringLength(200)]
        public string GOBJ { get; set; }

        public DateTime? GTDATE { get; set; }

        public TimeSpan? GTTIME { get; set; }

        [StringLength(10)]
        public string BACKED { get; set; }

        public int? LOCKDURATION { get; set; }
    }
}
