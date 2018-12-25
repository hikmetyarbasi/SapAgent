using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("SystemUsage", Schema = "Pure")]
    public partial class SystemUsage : IEntity
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string SERVER { get; set; }

        public int? ITEM { get; set; }

        [StringLength(200)]
        public string SECTION { get; set; }

        public string DESCR1 { get; set; }

        public string VALUE1 { get; set; }

        [StringLength(50)]
        public string UNIT1 { get; set; }

        [StringLength(10)]
        public string TYPE { get; set; }
    }
    public partial class SystemUsageTcpu : IEntity
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string SERVER { get; set; }

        public int? ITEM { get; set; }

        [StringLength(200)]
        public string SECTION { get; set; }

        public string DESCR1 { get; set; }

        public string VALUE1 { get; set; }

        [StringLength(50)]
        public string UNIT1 { get; set; }

        [StringLength(10)]
        public string TYPE { get; set; }
    }
    public partial class SystemUsageTmem : IEntity
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string SERVER { get; set; }

        public int? ITEM { get; set; }

        [StringLength(200)]
        public string SECTION { get; set; }

        public string DESCR1 { get; set; }

        public string VALUE1 { get; set; }

        [StringLength(50)]
        public string UNIT1 { get; set; }

        [StringLength(10)]
        public string TYPE { get; set; }
    }
}
