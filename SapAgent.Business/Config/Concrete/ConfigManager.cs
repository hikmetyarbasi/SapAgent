using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Config.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.Dto;
using SapAgent.Entities.Concrete.General.@enum;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Concrete
{
    public class ConfigManager<T> : IManagerConfig<T> where T : class, IEntity, new()
    {
        public readonly IBaseDal<T> Dal;
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _funcFlagBaseDal;
        private readonly IBaseDal<AllNotifyCountView> _bpNotifyDal;
        public int FunctionId { get; set; }
        public ConfigManager(IBaseDal<T> entityRepository, IBaseDal<FuncFlag> funcFlagBaseDal, int functionId)
        {
            Dal = entityRepository;
            _funcFlagBaseDal = funcFlagBaseDal;
            FunctionId = functionId;
        }
        public ConfigManager(IBaseDal<T> entityRepository, IBaseDal<FuncFlag> funcFlagBaseDal, int functionId, IBaseDal<AllNotifyCountView> bpNotifyDal)
        {
            Dal = entityRepository;
            _funcFlagBaseDal = funcFlagBaseDal;
            FunctionId = functionId;
            _bpNotifyDal = bpNotifyDal;
        }
        protected bool IsFlagUp()
        {
            var flag = _funcFlagBaseDal.Get(o => o.Func == FunctionId);
            return flag.Flag == 1;
        }
        protected Guid GetLastExecutionIndex()
        {
            return _funcFlagBaseDal.Get(o => o.Func == FunctionId).SReqIndex;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return await Dal.GetAll(filter);
        }

        public virtual void StartOperation(int customerId, int productId)
        {
            throw new NotImplementedException();
        }

        public void UpFlag(Guid sRIndex)
        {
            try
            {
                var entity = _funcFlagBaseDal.Get(o => o.Func == FunctionId);
                entity.Flag = 1;
                entity.SReqIndex = sRIndex;
                _funcFlagBaseDal.Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void DownFlag()
        {
            try
            {
                var entity = _funcFlagBaseDal.Get(o => o.Func == FunctionId);
                entity.Flag = 0;
                _funcFlagBaseDal.Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<AllNotifyCountViewDto>> GetCurrentStateOfNotify(int customerId)
        {
            var list = await _bpNotifyDal.GetAll(o => o.CustomerId == customerId);

            var productsgroup = list.GroupBy(g => new { g.ProductId, g.ProductName }).Select(s => s.Key).ToList();
            var listDto = new List<AllNotifyCountViewDto>();
            foreach (var product in productsgroup)
            {
                var dto = new AllNotifyCountViewDto();
                dto.CustomerId = customerId;
                var p = new Product()
                {
                    Id = product.ProductId,
                    ProductName = product.ProductName
                };
                var clientsgroup = list.Where(x => x.ProductId == product.ProductId).GroupBy(g => new { g.ClientId, g.ClientName }).Select(s => s.Key).ToList();
                var clientlist = new List<ClientDto>();
                foreach (var client in clientsgroup)
                {
                    var c = new ClientDto()
                    {
                        ClientId = client.ClientId,
                        ClientName = client.ClientName
                    };
                    var notificationlevel = list.Where(y => y.ProductId == product.ProductId && y.ClientId == client.ClientId).ToList();
                    c.NotificationLevel = ClearUnNecessaryNotification(notificationlevel);
                    c.CustomerProductId = notificationlevel[0].CustomerProductId;
                    clientlist.Add(c);
                }

                dto.Product = p;
                dto.Clients = clientlist;
                listDto.Add(dto);
            }
            return listDto;
        }

        private NotificationLevel ClearUnNecessaryNotification(List<AllNotifyCountView> bpNotifyView)
        {
            var errorcount = bpNotifyView.Count(x => x.Level == (int)Level.error && x.Amount > 0);
            if (errorcount > 0)
            {
                return bpNotifyView.Where(x => x.Level == (int)Level.error).Select(y => new NotificationLevel()
                {
                    Category = Level.error,
                    Amount = y.Amount,
                    LevelName = Level.error.ToString()
                }).FirstOrDefault();
            }
            var warningcount = bpNotifyView.Count(x => x.Level == (int)Level.warning && x.Amount > 0);
            if (warningcount > 0)
            {
                return bpNotifyView.Where(x => x.Level == (int)Level.warning).Select(y => new NotificationLevel()
                {
                    Category = Level.warning,
                    Amount = y.Amount,
                    LevelName = Level.warning.ToString()
                }).FirstOrDefault();
            }
            var infocount = bpNotifyView.Count(x => x.Level == (int)Level.info && x.Amount > 0);
            if (infocount > 0)
            {
                return bpNotifyView.Where(x => x.Level == (int)Level.info).Select(y => new NotificationLevel()
                {
                    Category = Level.info,
                    Amount = y.Amount,
                    LevelName = Level.info.ToString()
                }).FirstOrDefault();
            }
            return new NotificationLevel()
            {
                Category = Level.None,
                Amount = 0,
                LevelName = Level.None.ToString()
            };
        }

        public List<AllNotifyCountView> PushNotifyModelToClient(int customerId)
        {
            var puredata = _bpNotifyDal.GetAll(o => o.CustomerId == customerId);
            return puredata.Result;
        }
    }
}
