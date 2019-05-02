using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SapAgent.Business.General.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.General;

namespace SapAgent.Business.General.Concrete
{
    public class GeneralClientManager: IManagerGeneralClient
    {
        private IBaseDal<Client> _getClientDal;

        public GeneralClientManager(IBaseDal<Client> getClientDal)
        {
            _getClientDal = getClientDal;
        }

        public Task<List<Client>> GetAll(Expression<Func<Client, bool>> filter)
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
