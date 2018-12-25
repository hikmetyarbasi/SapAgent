using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("SystemVersion", Schema = "Pure")]
    public partial class SystemVersion:IEntity
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string COMPONENT { get; set; }

        public int? RELEASE { get; set; }

        public int? EXTRELEASE { get; set; }

        [StringLength(10)]
        public string COMPTYPE { get; set; }

        [StringLength(50)]
        public string LANGU { get; set; }

        [StringLength(400)]
        public string DESCTEXT { get; set; }

        [StringLength(50)]
        public string PATCHTYPE { get; set; }

        [StringLength(300)]
        public string HIGHPATCH { get; set; }

        public int? SPPLEVEL { get; set; }

        [StringLength(50)]
        public string LASTSPP { get; set; }

        [StringLength(100)]
        public string VIATRANS { get; set; }
    }
}
