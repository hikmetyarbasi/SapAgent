using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.General;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class ClientDal:BaseDal<Client>
    {
        public ClientDal(IEntityRepository<Client> entityRepository) : base(entityRepository)
        {
        }
    }
}
