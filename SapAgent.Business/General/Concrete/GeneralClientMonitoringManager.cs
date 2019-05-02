using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SapAgent.Business.General.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.@enum;

namespace SapAgent.Business.General.Concrete
{
    public class GeneralClientMonitoringManager :IManagerGeneralClientMonitoring
    {
        private readonly IBaseDal<ClientMonitoringView> _customerProductViewDal;

        public GeneralClientMonitoringManager(IBaseDal<ClientMonitoringView> customerProductViewDal)
        {
            _customerProductViewDal = customerProductViewDal;
        }

        public Task<List<ClientMonitoringView>> GetAll(Expression<Func<ClientMonitoringView, bool>> filter)
        {
            return _customerProductViewDal.GetAll(filter);
        }
    }
}
