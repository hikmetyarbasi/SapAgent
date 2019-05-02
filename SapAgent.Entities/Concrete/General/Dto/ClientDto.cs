using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.Entities.Concrete.General.@enum;

namespace SapAgent.Entities.Concrete.General.Dto
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public NotificationLevel NotificationLevel { get; set; }
        public int CustomerProductId { get; set; }

    }

    public class NotificationLevel
    {
        public string LevelName { get; set; }
        public int Amount { get; set; }
        public Level Category { get; set; }
    }
    
}
