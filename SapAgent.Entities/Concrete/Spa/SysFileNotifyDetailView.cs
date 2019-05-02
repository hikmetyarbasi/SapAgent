using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.Entities.Concrete.Spa
{
    public class SysFileNotifyDetailView : IEntity
    {
        [Key]
        public Int64 RowIndex { get; set; }
        public string Case { get; set; }
        public string Level { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string ClientName { get; set; }
        public string Desc { get; set; }
        public DateTime Date { get; set; }
        public int Statu { get; set; }
        public string FuncName { get; set; }
        public int CustomerProductId { get; set; }
    }
}
