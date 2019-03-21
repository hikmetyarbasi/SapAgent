using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SapAgent.Business.General.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.General;

namespace SapAgent.Business.General.Concrete
{
    public class ClientManager: IManagerGeneral<Client>
    {
        private IBaseDal<Client> _getClientDal;

        public ClientManager(IBaseDal<Client> getClientDal)
        {
            _getClientDal = getClientDal;
        }

        public List<Client> GetAll(Expression<Func<Client, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts(int customerId)
        {
            throw new NotImplementedException();
        }

        public Client Get(int customerProductId)
        {
            return _getClientDal.Get(x => x.ClientId == customerProductId);
        }
    }
}
