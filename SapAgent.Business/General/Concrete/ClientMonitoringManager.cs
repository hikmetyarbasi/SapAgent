using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SapAgent.Business.General.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.@enum;

namespace SapAgent.Business.General.Concrete
{
    public class ClientMonitoringManager : IManagerGeneral<ClientMonitoringView>
    {
        private readonly IBaseDal<ClientMonitoringView> _customerProductViewDal;

        public ClientMonitoringManager(IBaseDal<ClientMonitoringView> customerProductViewDal)
        {
            _customerProductViewDal = customerProductViewDal;
        }

        public List<ClientMonitoringView> GetAll(Expression<Func<ClientMonitoringView, bool>> filter)
        {
            return _customerProductViewDal.GetAll(filter).Result.Where(x=>x.Level==(int) Category.error).ToList();
        }

        public List<Product> GetProducts(int customerId)
        {
            throw new NotImplementedException();
        }

        public Client Get(int customerProductId)
        {
            throw new NotImplementedException();
        }
    }
}
