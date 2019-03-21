using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.General
{

    [Table("CLIENT_MONITORING_VIEW", Schema = "dbo")]
    public class ClientMonitoringView : IEntity
    {
        [Key]
        public Int64 RowIndex { get; set; }
        public int FuncId { get; set; }
        public string FuncName { get; set; }
        public int Level { get; set; }
        public int Amount { get; set; }
        public int CustomerProductId { get; set; }
    }
}
