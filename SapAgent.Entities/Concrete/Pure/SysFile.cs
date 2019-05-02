using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("SysFile", Schema = "Pure")]
    public class SysFile : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Server { get; set; }
        public string Fsysname { get; set; }
        public int Capacity { get; set; }
        public int Free { get; set; }
        public int FreePercent { get; set; }
        public Guid SREQINDEX { get; set; }
    }
}
