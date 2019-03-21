using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.Dto;

namespace SapAgent.Entities.Concrete.Spa
{
    public class BpNotifyViewDto
    {
        public Product Product { get; set; }
        public List<ClientDto> Clients { get; set; }
        public int CustomerId { get; set; }

    }
}
