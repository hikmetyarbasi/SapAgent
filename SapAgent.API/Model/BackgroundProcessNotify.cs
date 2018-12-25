using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapAgent.API.Model
{
    public class BackgroundProcessNotify
    {
        public int FirmId { get; set; }
        public string FirmName { get; set; }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int Client { get; set; }
        public string ClientName { get; set; }
        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }
    }
}
