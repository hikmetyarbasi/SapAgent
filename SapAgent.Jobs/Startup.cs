using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework;
using Helpers.Abstract;
using Helpers.Concrete;
using SapAgent.Business.Pure.Concrete;
using SapAgent.Business.Pure.Abstract;
using SapAgent.Business.Config.Concrete;
using SapAgent.Business.Config.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Jobs.Controllers;

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
            services.AddHangfire(x => x.UseSqlServerStorage("Data Source =185.122.201.43,1433;initial catalog=HangFire;User Id=hikmetyarbasi;password=123456;"));
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.BackgroundProcess>, HttpClientHelper<Entities.Concrete.Pure.BackgroundProcess>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.Dump>, HttpClientHelper<Entities.Concrete.Pure.Dump>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.Lock>, HttpClientHelper<Entities.Concrete.Pure.Lock>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.Sm51SysList>, HttpClientHelper<Entities.Concrete.Pure.Sm51SysList>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.UserSession>, HttpClientHelper<Entities.Concrete.Pure.UserSession>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.SystemUsage>, HttpClientHelper<Entities.Concrete.Pure.SystemUsage>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.SystemVersion>, HttpClientHelper<Entities.Concrete.Pure.SystemVersion>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.RtmInfo>, HttpClientHelper<Entities.Concrete.Pure.RtmInfo>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.RtmInfoBase>, HttpClientHelper<Entities.Concrete.Pure.RtmInfoBase>>();
            services.AddScoped<IHttpClientHelper<Entities.Concrete.Pure.SystemUsage>, HttpClientHelper<Entities.Concrete.Pure.SystemUsage>>();
            services.AddScoped<IHttpClientHelper<BackgroundProcessNotify>, HttpClientHelper<BackgroundProcessNotify>>();

            services.AddScoped<IManager<Entities.Concrete.Pure.BackgroundProcess>, BackgroundProcessManager>();
            services.AddScoped<IManagerConfig<Entities.Concrete.Config.BackgroundProcess>, BackgroundProcessConfigManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.Dump>, DumpManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.Lock>, LockManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.Sm51SysList>, SysListManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.UserSession>, UserSessionManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.SystemUsage>, SysUsageManager>();
            services.AddScoped<IManagerConfig<Entities.Concrete.Config.FuncFlag>, FuncFlagManager>();

            services.AddScoped<IBaseDal<Entities.Concrete.Pure.BackgroundProcess>, BackgroundProcessDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.BackgroundProcess>, BackgroundProcessConfigDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.FuncFlag>, FuncFlagDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.Dump>, DumpDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.Lock>, LockDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.Sm51SysList>, SysListDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.UserSession>, UserSessionDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Pure.SystemUsage>, SysUsageDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.BackgroundProcessNotify>, NotificationDal>();
            services.AddScoped<IBaseDal<Entities.Concrete.Spa.BpNotifyView>, BpNotifyViewDal>();

            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.BackgroundProcess>, EfEntityRepositoryBase<Entities.Concrete.Pure.BackgroundProcess, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.BackgroundProcess>, EfEntityRepositoryBase<Entities.Concrete.Config.BackgroundProcess, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.Dump>, EfEntityRepositoryBase<Entities.Concrete.Pure.Dump, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.Lock>, EfEntityRepositoryBase<Entities.Concrete.Pure.Lock, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.Sm51SysList>, EfEntityRepositoryBase<Entities.Concrete.Pure.Sm51SysList, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.UserSession>, EfEntityRepositoryBase<Entities.Concrete.Pure.UserSession, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Pure.SystemUsage>, EfEntityRepositoryBase<Entities.Concrete.Pure.SystemUsage, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.FuncFlag>, EfEntityRepositoryBase<Entities.Concrete.Config.FuncFlag, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.BackgroundProcessNotify>, EfEntityRepositoryBase<Entities.Concrete.Config.BackgroundProcessNotify, SapAgentContext>>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Spa.BpNotifyView>, EfEntityRepositoryBase<Entities.Concrete.Spa.BpNotifyView, SapAgentContext>>();


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
