using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.Dto;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.General.Abstract
{
    public interface IManagerGeneral<T>
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter);
    }
}
