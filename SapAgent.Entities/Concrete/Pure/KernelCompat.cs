using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("KernelCompat", Schema = "Pure")]
    public partial class KernelCompat
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TSYSCHECK { get; set; }

        [StringLength(50)]
        public string UNICODE_SYTEM { get; set; }

        [StringLength(100)]
        public string SERVERNAME { get; set; }

        [StringLength(100)]
        public string HOST { get; set; }

        public int? KERNELRELEASE { get; set; }

        public int? PATCHLEVEL { get; set; }
    }
}
