using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Config
{
    [Table("Lock", Schema = "Config")]
    public class Lock : ILock
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ClientId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Buffer { get; set; }
        public int RangeWarning { get; set; }
        public int RangeError { get; set; }
        public int LockLimit { get; set; }

    }
}
