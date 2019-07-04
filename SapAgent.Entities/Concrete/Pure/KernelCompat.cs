using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("KernelCompat", Schema = "Pure")]
    public partial class KernelCompat : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string UnicodeSytem { get; set; }

        [StringLength(100)]
        public string ServerName { get; set; }

        [StringLength(100)]
        public string Host { get; set; }

        public int? KernelRelease { get; set; }

        public int? PatchLevel { get; set; }
    }
}
