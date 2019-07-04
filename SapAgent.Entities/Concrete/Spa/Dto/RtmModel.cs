using System.Collections.Generic;
using SapAgent.Entities.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Entities.Concrete.Spa.Dto
{
    public class RtmModel : IEntity
    {
        public RtmModel()
        {
            RtmInfos= new List<RtmInfo>();
        }
        public RtmInfoBase RtmBase { get; set; }
        public List<RtmInfo> RtmInfos { get; set; }

    }
}
