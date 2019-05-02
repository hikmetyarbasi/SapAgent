using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.Business.General.Concrete;
using SapAgent.Entities.Concrete.General;

namespace SapAgent.Business.General.Abstract
{
    public interface IManagerGeneralCustomerProduct:IManagerGeneral<CustomerProductView>
    {
        List<Product> GetProducts(int customerId);
    }
}
