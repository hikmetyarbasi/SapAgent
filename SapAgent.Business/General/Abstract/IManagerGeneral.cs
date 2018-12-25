using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.General.Abstract
{
    public interface IManagerGeneral<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter);
        List<Product> GetProducts(int customerId);
    }
}
