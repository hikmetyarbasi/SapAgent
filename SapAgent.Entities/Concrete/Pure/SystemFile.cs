using System.ComponentModel.DataAnnotations.Schema;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Pure
{
    [Table("SysInfo", Schema = "Pure")]
    public class SystemFile: IEntity
    {
        public string SERVER { get; set; }
        public string FSYSNAME { get; set; }
        public int CAPACITY { get; set; }
        public int FREE { get; set; }
        public int FREE_PERCEN { get; set; }
    }
}
