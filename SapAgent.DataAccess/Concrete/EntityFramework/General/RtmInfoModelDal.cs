using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa.Dto;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class RtmInfoModelDal:BaseDal<RtmModel>
    {
        public RtmInfoModelDal(IEntityRepository<RtmModel> entityRepository) : base(entityRepository)
        {
        }
    }
}
