using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SapAgent.Business.Config.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Config.Concrete
{
    public class ConfigRtmInfoBaseManager: IManagerConfigRtmInfoBaseManager
    {
        public Task<List<RtmInfoBase>> GetAll(Expression<Func<RtmInfoBase, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void StartOperation(int customerId, int productId)
        {
            
        }

        public void UpFlag(Guid sRIndex)
        {
            throw new NotImplementedException();
        }

        public void DownFlag()
        {
            throw new NotImplementedException();
        }
    }
}
