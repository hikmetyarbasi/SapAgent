using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Abstract
{
    public interface IManagerConfig<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter);
        void StartOperation();
        List<BpNotifyView> GetCurrentStateOfNotify();
        int GetBackgroundProcessTotalJobCount();
    }
}
