using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("Sm51SysList", Schema = "Pure")]
    public partial class Sm51SysList : IEntity
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string NAME { get; set; }

        [StringLength(100)]
        public string HOST { get; set; }

        [StringLength(100)]
        public string SERV { get; set; }

        [StringLength(10)]
        public string MSGTYPES { get; set; }

        [StringLength(50)]
        public string HOSTADR { get; set; }

        [StringLength(100)]
        public string SERVNO { get; set; }

        public int? STATE { get; set; }

        [StringLength(50)]
        public string HOSTNAMELONG { get; set; }

        [StringLength(50)]
        public string HOSTADDR_V4_STR { get; set; }

        [StringLength(50)]
        public string HOSTADDR_V6_STR { get; set; }

        public int? SYSSERVICE0 { get; set; }

        public int? SYSSERVICE1 { get; set; }

        public int? SYSSERVICE2 { get; set; }

        public int? SYSSERVICE3 { get; set; }

        [StringLength(400)]
        public string SERVICES { get; set; }

        public int? SERVSTR { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }
    }
}
