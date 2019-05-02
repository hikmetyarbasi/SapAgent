using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SapAgent.Business.General.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.General.Concrete
{
    public class GeneralDashboardManager : IManagerGeneralDashboard
    {
        IBaseDal<AllNotifyCountView> _dashboardDal;

        public GeneralDashboardManager(IBaseDal<AllNotifyCountView> dashboardDal)
        {
            _dashboardDal = dashboardDal;
        }

        public Task<List<AllNotifyCountView>> GetAll(Expression<Func<AllNotifyCountView, bool>> filter)
        {
            return _dashboardDal.GetAll(filter);
        }
    }
}
