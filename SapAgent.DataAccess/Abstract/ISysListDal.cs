﻿using System.Threading.Tasks;
using SapAgent.Entities.Concrete;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Engine1.Abstract
{
    public interface ISysListDal
    {
        void Add(SysList dump);
        Task<SysList[]> Get();
    }
}