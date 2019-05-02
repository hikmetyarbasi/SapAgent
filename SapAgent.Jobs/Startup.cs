﻿using Hangfire;
using Helpers.Abstract;
using Helpers.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SapAgent.API.Model;
using SapAgent.Business.Config.Abstract;
using SapAgent.Business.Config.Concrete;
using SapAgent.Business.General.Abstract;
using SapAgent.Business.General.Concrete;
using SapAgent.Business.Pure.Abstract;
using SapAgent.Business.Pure.Concrete;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework;
using SapAgent.DataAccess.Concrete.EntityFramework.Config;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.DataAccess.Concrete.EntityFramework.Pure;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.Pure;
using SapAgent.Entities.Concrete.Spa;
using SapAgent.Jobs.Controllers;
using BackgroundProcess = SapAgent.Entities.Concrete.Pure.BackgroundProcess;
using Dump = SapAgent.Entities.Concrete.Pure.Dump;
using SysList = SapAgent.Entities.Concrete.Pure.SysList;
using SysUsage = SapAgent.Entities.Concrete.Pure.SysUsage;

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



            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.SystemVersion>, HttpClientHelper<Entities.Concrete.Pure.SystemVersion>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.RtmInfo>, HttpClientHelper<Entities.Concrete.Pure.RtmInfo>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.RtmInfoBase>, HttpClientHelper<Entities.Concrete.Pure.RtmInfoBase>>();

            services.AddScoped<IManagerBackgroundProcess, BackgroundProcessManager>();
            services.AddScoped<IManagerConfigBpManager, ConfigBackgroundProcessManager>();
            services.AddScoped<IHttpClientHelper<SapAgent.Entities.Concrete.Config.BackgroundProcessNotify>, HttpClientHelper<SapAgent.Entities.Concrete.Config.BackgroundProcessNotify>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.BackgroundProcess>, HttpClientHelper<Entities.Concrete.Pure.BackgroundProcess>>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.BackgroundProcess>, BackgroundProcessConfigDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.BackgroundProcessNotify>, BackgroundProcessNotifyDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.BackgroundProcess>, BackgroundProcessDal>();
            services.AddScoped<IBaseDal<BpNotifyCountView>, BpNotifyCountViewDal>();
            services.AddScoped<IBaseDal<BpNotifyDetailView>, BpNotifyDetailViewDal>();
            services.AddScoped<IEntityRepository<BpNotifyCountView>, EfEntityRepositoryBase<BpNotifyCountView, SapAgentContext>>();
            services.AddScoped<IEntityRepository<BpNotifyDetailView>, EfEntityRepositoryBase<BpNotifyDetailView, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.BackgroundProcess>, EfEntityRepositoryBase<Entities.Concrete.Config.BackgroundProcess, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.BackgroundProcess>, EfEntityRepositoryBase<Entities.Concrete.Pure.BackgroundProcess, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.BackgroundProcess>, EfEntityRepositoryBase<Entities.Concrete.Config.BackgroundProcess, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.BackgroundProcessNotify>, EfEntityRepositoryBase<Entities.Concrete.Config.BackgroundProcessNotify, SapAgentContext>>();

            services.AddScoped<IManagerDump, DumpManager>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.Dump>, HttpClientHelper<Entities.Concrete.Pure.Dump>>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.Dump>, DumpDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.Dump>, DumpConfigDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.DumpNotify>, DumpNotifyDal>();
            services.AddScoped<IBaseDal<DumpNotifyDetailView>, DumpNotifyDetailViewDal>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.Dump>, EfEntityRepositoryBase<Entities.Concrete.Pure.Dump, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.Dump>, EfEntityRepositoryBase<Entities.Concrete.Config.Dump, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.DumpNotify>, EfEntityRepositoryBase<Entities.Concrete.Config.DumpNotify, SapAgentContext>>();
            services.AddScoped<IEntityRepository<SapAgent.Entities.Concrete.Spa.DumpNotifyDetailView>, EfEntityRepositoryBase<DumpNotifyDetailView, SapAgentContext>>();
            services.AddScoped<IManagerConfigDmpManager, ConfigDumpManager>();

            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.Lock>, HttpClientHelper<Entities.Concrete.Pure.Lock>>();
            services.AddScoped<IManager<Entities.Concrete.Pure.Lock>, LockManager>();
            services.AddScoped<IManagerConfigLockManager, ConfigLockManager>();
            services.AddScoped<IManagerLock, LockManager>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.LockNotify>, LockNotifyDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.Lock>, LockDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.Lock>, LockConfigDal>();
            services.AddScoped<IBaseDal<LockNotifyDetailView>, LockNotifyDetailViewDal>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.Lock>, EfEntityRepositoryBase<Entities.Concrete.Pure.Lock, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.Lock>, EfEntityRepositoryBase<Entities.Concrete.Config.Lock, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.LockNotify>, EfEntityRepositoryBase<Entities.Concrete.Config.LockNotify, SapAgentContext>>();
            services.AddScoped<IEntityRepository<SapAgent.Entities.Concrete.Spa.LockNotifyDetailView>, EfEntityRepositoryBase<LockNotifyDetailView, SapAgentContext>>();

            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.SysUsage>, HttpClientHelper<Entities.Concrete.Pure.SysUsage>>();
            services.AddScoped<IManagerConfigSysUsageManager, ConfigSysUsageManager>();
            services.AddScoped<IManagerSysUsage, SysUsageManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.SysUsage>, SysUsageManager>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.SysUsage>, HttpClientHelper<Entities.Concrete.Pure.SysUsage>>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.SysUsage>, SysUsageDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.SysUsage>, SysUsageConfigDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.SysUsageNotify>, SysUsageNotifyDal>();
            services.AddScoped<IBaseDal<SysUsageNotifyDetailView>, SysUsageNotifyDetailViewDal>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.SysUsage>, EfEntityRepositoryBase<Entities.Concrete.Pure.SysUsage, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.SysUsage>, EfEntityRepositoryBase<Entities.Concrete.Config.SysUsage, SapAgentContext>>();
            services.AddScoped<IEntityRepository<SapAgent.Entities.Concrete.Spa.SysUsageNotifyDetailView>, EfEntityRepositoryBase<SysUsageNotifyDetailView, SapAgentContext>>();
            services.AddScoped<IEntityRepository<SapAgent.Entities.Concrete.Spa.SysUsageNotifyCountView>, EfEntityRepositoryBase<SysUsageNotifyCountView, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.SysUsageNotify>, EfEntityRepositoryBase<Entities.Concrete.Config.SysUsageNotify, SapAgentContext>>();

            services.AddScoped<IBaseDal<Entities.Concrete.Pure.SysList>, SysListDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.SysList>, SysListConfigDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.SysListNotify>, SysListNotifyDal>();
            services.AddScoped<IBaseDal<SysListNotifyDetailView>, SysListNotifyDetailViewDal>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.SysList>, EfEntityRepositoryBase<Entities.Concrete.Pure.SysList, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.SysList>, EfEntityRepositoryBase<Entities.Concrete.Config.SysList, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.SysListNotify>, EfEntityRepositoryBase<Entities.Concrete.Config.SysListNotify, SapAgentContext>>();
            services.AddScoped<IEntityRepository<SapAgent.Entities.Concrete.Spa.SysListNotifyDetailView>, EfEntityRepositoryBase<SysListNotifyDetailView, SapAgentContext>>();
            services.AddScoped<IEntityRepository<SapAgent.Entities.Concrete.Spa.SysListNotifyCountView>, EfEntityRepositoryBase<SysListNotifyCountView, SapAgentContext>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.SysList>, HttpClientHelper<Entities.Concrete.Pure.SysList>>();
            services.AddScoped<IManagerConfigSysListManager, ConfigSysListManager>();
            services.AddScoped<IManagerSysList, SysListManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.SysList>, SysListManager>();

            services.AddScoped<IBaseDal<Entities.Concrete.Pure.SysFile>, SysFileDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.SysFile>, SysFileConfigDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.SysFileNotify>, SysFileNotifyDal>();
            services.AddScoped<IBaseDal<SysFileNotifyDetailView>, SysFileNotifyDetailViewDal>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.SysFile>, EfEntityRepositoryBase<Entities.Concrete.Pure.SysFile, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.SysFile>, EfEntityRepositoryBase<Entities.Concrete.Config.SysFile, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.SysFileNotify>, EfEntityRepositoryBase<Entities.Concrete.Config.SysFileNotify, SapAgentContext>>();
            services.AddScoped<IEntityRepository<SapAgent.Entities.Concrete.Spa.SysFileNotifyDetailView>, EfEntityRepositoryBase<SysFileNotifyDetailView, SapAgentContext>>();
            services.AddScoped<IEntityRepository<SapAgent.Entities.Concrete.Spa.SysFileNotifyCountView>, EfEntityRepositoryBase<SysFileNotifyCountView, SapAgentContext>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.SysFile>, HttpClientHelper<Entities.Concrete.Pure.SysFile>>();
            services.AddScoped<IManagerConfigSysFileManager, ConfigSysFileManager>();
            services.AddScoped<IManagerSysFile, SysFileManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.SysFile>, SysFileManager>();


            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.UserSession>, EfEntityRepositoryBase<Entities.Concrete.Pure.UserSession, SapAgentContext>>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.UserSession>, UserSessionDal>();
            services.AddScoped<IManager<Entities.Concrete.Pure.UserSession>, UserSessionManager>();
            services.AddScoped<IManagerUserSession, UserSessionManager>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.UserSession>, HttpClientHelper<Entities.Concrete.Pure.UserSession>>();



            services.AddScoped<IBaseDal<Entities.Concrete.General.CustomerProductRl>, CustomerProductRlDal>();
            services.AddScoped<IEntityRepository<Entities.Concrete.General.CustomerProductRl>, EfEntityRepositoryBase<Entities.Concrete.General.CustomerProductRl, SapAgentContext>>();

            services.AddScoped<IBaseDal<Entities.Concrete.General.CustomerProductView>, CustomerProductViewDal>();
            services.AddScoped<IEntityRepository<Entities.Concrete.General.CustomerProductView>, EfEntityRepositoryBase<Entities.Concrete.General.CustomerProductView, SapAgentContext>>();

            services.AddScoped<IBaseDal<Entities.Concrete.General.ClientMonitoringView>, ClientMonitoringDal>();
            services.AddScoped<IEntityRepository<Entities.Concrete.General.ClientMonitoringView>, EfEntityRepositoryBase<Entities.Concrete.General.ClientMonitoringView, SapAgentContext>>();

            services.AddScoped<IBaseDal<AllNotifyCountView>, DashboardDal>();
            services.AddScoped<IEntityRepository<AllNotifyCountView>, EfEntityRepositoryBase<AllNotifyCountView, SapAgentContext>>();

            services.AddScoped<IEntityRepository<Entities.Concrete.Config.FuncFlag>, EfEntityRepositoryBase<Entities.Concrete.Config.FuncFlag, SapAgentContext>>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.FuncFlag>, FuncFlagDal>();

            services.AddScoped<IHttpClientHelper<DashboardSignalRModel>, HttpClientHelper<DashboardSignalRModel>>();
            services.AddScoped<IManagerGeneralCustomerProduct, GeneralCustomerProductViewManager>();
            services.AddScoped<IManagerGeneralClientMonitoring, GeneralClientMonitoringManager>();
            services.AddScoped<IManagerGeneralDashboard, GeneralDashboardManager>();

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
