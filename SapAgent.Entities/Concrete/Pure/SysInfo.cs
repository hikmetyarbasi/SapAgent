using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("SysInfo", Schema = "Pure")]
    public partial class SysInfo
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string SERVER { get; set; }

        [StringLength(10)]
        public string ITEM { get; set; }

        [StringLength(200)]
        public string SECTION { get; set; }

        public string DESCR1 { get; set; }

        [StringLength(200)]
        public string VALUE1 { get; set; }

        [StringLength(50)]
        public string UNIT1 { get; set; }
    }
}
