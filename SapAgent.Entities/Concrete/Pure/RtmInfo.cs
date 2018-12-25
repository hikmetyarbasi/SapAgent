using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("RtmInfo", Schema = "Pure")]
    public partial class RtmInfo:IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RtmInfo()
        {
            RtmInfo1 = new HashSet<RtmInfo>();
        }

        public int ID { get; set; }

        public int? BASEID { get; set; }

        [StringLength(10)]
        public string BUFFER { get; set; }

        [StringLength(100)]
        public string NAME { get; set; }

        public TimeSpan? HITRATIO { get; set; }

        public int? ALLOCSIZE { get; set; }

        public int? FREESIZE { get; set; }

        public double? FREESIZEP { get; set; }

        public int? MAXOBJCTS { get; set; }

        public int? FREEDIR { get; set; }

        public double? FREEDIRP { get; set; }

        public int? MAXSWAPPED { get; set; }

        public int? DBACCESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RtmInfo> RtmInfo1 { get; set; }

        public virtual RtmInfo RtmInfo2 { get; set; }
    }
}
