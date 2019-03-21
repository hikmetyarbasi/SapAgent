using System;
using System.Collections.Generic;
using System.Text;

namespace SapAgent.Entities.Concrete.General.Dto
{
    public class ClientMonitoringViewDto
    {
        public List<ClientMonitoringView> ClientMonitoringView { get; set; }
        public CustomerProductView CustomerProduct { get; set; }
    }
}
