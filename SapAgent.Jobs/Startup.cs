using Hangfire;
using Helpers.Abstract;
using Helpers.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SapAgent.Business.Config.Abstract;
using SapAgent.Business.Config.Concrete;
using SapAgent.Business.Config.Concrete.Dmp;
using SapAgent.Business.General.Abstract;
using SapAgent.Business.General.Concrete;
using SapAgent.Business.Pure.Abstract;
using SapAgent.Business.Pure.Concrete;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.Pure;
using SapAgent.Entities.Concrete.Spa;
using SapAgent.Jobs.Controllers;
using BackgroundProcess = SapAgent.Entities.Concrete.Pure.BackgroundProcess;
using BackgroundProcessNotify = SapAgent.Entities.Concrete.Config.BackgroundProcessNotify;
using Dump = SapAgent.Entities.Concrete.Pure.Dump;

namespace SapAgent.Jobs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<SapAgentContext>();
            services.AddHangfire(x =>
                x.UseSqlServerStorage("Data Source =185.122.201.43,1433;initial catalog=HangFire;User Id=hikmetyarbasi;password=123456;")
            //x.UseSqlServerStorage("Data Source =(localdb)\\mssqllocaldb;initial catalog=HangFire;Integrated Security=true;")
                );
            services.AddScoped<IHttpClientHelper<BackgroundProcess>, HttpClientHelper<BackgroundProcess>>();
            services.AddScoped<IHttpClientHelper<Dump>, HttpClientHelper<Dump>>();
            services.AddScoped<IHttpClientHelper<Lock>, HttpClientHelper<Lock>>();
            services.AddScoped<IHttpClientHelper<Sm51SysList>, HttpClientHelper<Sm51SysList>>();
            services.AddScoped<IHttpClientHelper<UserSession>, HttpClientHelper<UserSession>>();
            services.AddScoped<IHttpClientHelper<SystemUsage>, HttpClientHelper<SystemUsage>>();
            services.AddScoped<IHttpClientHelper<SystemVersion>, HttpClientHelper<SystemVersion>>();
            services.AddScoped<IHttpClientHelper<RtmInfo>, HttpClientHelper<RtmInfo>>();
            services.AddScoped<IHttpClientHelper<RtmInfoBase>, HttpClientHelper<RtmInfoBase>>();
            services.AddScoped<IHttpClientHelper<SystemUsage>, HttpClientHelper<SystemUsage>>();
            services.AddScoped<IHttpClientHelper<BackgroundProcessNotify>, HttpClientHelper<BackgroundProcessNotify>>();

            services.AddScoped<IManager<BackgroundProcess>, BackgroundProcessManager>();
            services.AddScoped<IManagerConfig<Entities.Concrete.Config.BackgroundProcess>, BackgroundProcessConfigManager>();
            services.AddScoped<IManagerConfig<Entities.Concrete.Config.Dump>, DumpConfigManager>();
            services.AddScoped<IManagerGeneral<Client>,ClientManager>();
            services.AddScoped<IManager<Dump>, DumpManager>();
            services.AddScoped<IManager<Lock>, LockManager>();
            services.AddScoped<IManager<Sm51SysList>, SysListManager>();
            services.AddScoped<IManager<UserSession>, UserSessionManager>();
            services.AddScoped<IManager<SystemUsage>, SysUsageManager>();

            services.AddScoped<IBaseDal<BackgroundProcess>, BackgroundProcessDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.BackgroundProcess>, BackgroundProcessConfigDal>();
            services.AddScoped<IBaseDal<FuncFlag>, FuncFlagDal>();
            services.AddScoped<IBaseDal<Client>, ClientDal>();
            services.AddScoped<IBaseDal<Dump>, DumpDal>();
            services.AddScoped<IBaseDal<Lock>, LockDal>();
            services.AddScoped<IBaseDal<Sm51SysList>, SysListDal>();
            services.AddScoped<IBaseDal<UserSession>, UserSessionDal>();
            services.AddScoped<IBaseDal<SystemUsage>, SysUsageDal>();
            services.AddScoped<IBaseDal<BackgroundProcessNotify>, NotificationDal>();
            services.AddScoped<IBaseDal<BpNotifyView>, BpNotifyViewDal>();

            services.AddScoped<IEntityRepository<BackgroundProcess>, EfEntityRepositoryBase<BackgroundProcess, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.BackgroundProcess>, EfEntityRepositoryBase<Entities.Concrete.Config.BackgroundProcess, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Dump>, EfEntityRepositoryBase<Dump, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Lock>, EfEntityRepositoryBase<Lock, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Sm51SysList>, EfEntityRepositoryBase<Sm51SysList, SapAgentContext>>();
            services.AddScoped<IEntityRepository<UserSession>, EfEntityRepositoryBase<UserSession, SapAgentContext>>();
            services.AddScoped<IEntityRepository<SystemUsage>, EfEntityRepositoryBase<SystemUsage, SapAgentContext>>();
            services.AddScoped<IEntityRepository<FuncFlag>, EfEntityRepositoryBase<FuncFlag, SapAgentContext>>();
            services.AddScoped<IEntityRepository<BackgroundProcessNotify>, EfEntityRepositoryBase<BackgroundProcessNotify, SapAgentContext>>();
            services.AddScoped<IEntityRepository<BpNotifyView>, EfEntityRepositoryBase<BpNotifyView, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Client>, EfEntityRepositoryBase<Client, SapAgentContext>>();


            services.AddTransient<Engine2Controller, Engine2Controller>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseMvc();
            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}
