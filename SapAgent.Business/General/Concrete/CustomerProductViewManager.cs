using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SapAgent.Business.General.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.General;

namespace SapAgent.Business.General.Concrete
{
    public class CustomerProductViewManager : IManagerGeneral<CustomerProductView>
    {
        private readonly IBaseDal<CustomerProductView> _customerProductViewDal;

        public CustomerProductViewManager(IBaseDal<CustomerProductView> customerProductViewDal)
        {
            _customerProductViewDal = customerProductViewDal;
        }

        public List<CustomerProductView> GetAll(Expression<Func<CustomerProductView, bool>> filter)
        {
            return _customerProductViewDal.GetAll(filter);
        }


    }
}
