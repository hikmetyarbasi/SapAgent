using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.Business.Pure.Abstract;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.Dto;

namespace SapAgent.Business.General.Abstract
{
    public interface IManagerGeneralClient : IManagerGeneral<Client>
    {
        Client Get(int customerProductId);
    }
}
