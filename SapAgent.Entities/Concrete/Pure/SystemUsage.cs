using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("SysUsage", Schema = "Pure")]
    public class SysUsage : IEntity
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

        public Guid SREQINDEX { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
    public class SystemUsageTcpu : IEntity
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
    public class SystemUsageTmem : IEntity
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
