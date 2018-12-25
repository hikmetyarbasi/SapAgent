using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using PrdBackgroundProcess;
using PrdCheckDumps;
using PrdCheckLocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SapAgent.ExternalServices.Abstract;
using SapAgent.ExternalServices.Concrete;
using SystemList;
using SystemUsages;
using AutoMapper;
using SapAgent.API.Helper;
using PrdUserSession;
using SapAgent.Business.Config.Concrete;
using SapAgent.Business.Config.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework;
using Helpers.Abstract;
using Helpers.Concrete;
using SapAgent.API.Model;
using SapAgent.Business.Pure.Abstract;
using SapAgent.Business.Pure.Concrete;

namespace SapAgent.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("Environments\\appsettings.json", optional: false, reloadOnChange: true);

            switch (env.EnvironmentName)
            {
                case "Development":
                    builder.AddJsonFile($"Environments\\appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                    break;
                case "Qa":
                    builder.AddJsonFile($"Environments\\appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                    break;
                case "Staging":
                    builder.AddJsonFile($"Environments\\appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                    break;
                case "Production":
                    builder.AddJsonFile($"Environments\\appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                    break;
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Sap Agent API Service", Version = "v1.0", Description = "Sap Ajan Api Servisi" });
            });

            services.AddScoped<IHttpClientHelper<SapAgent.Entities.Concrete.Config.BackgroundProcessNotify>, HttpClientHelper<SapAgent.Entities.Concrete.Config.BackgroundProcessNotify>>();
            services.AddScoped<IBaseDal<Entities.Concrete.Config.BackgroundProcess>, BackgroundProcessConfigDal>();
            services.AddScoped<IEntityRepository<Entities.Concrete.Config.BackgroundProcess>, EfEntityRepositoryBase<Entities.Concrete.Config.BackgroundProcess, SapAgentContext>>();
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
            

            services.AddScoped<IManager<Entities.Concrete.Pure.BackgroundProcess>, BackgroundProcessManager>();
            services.AddScoped<IManagerConfig<Entities.Concrete.Config.BackgroundProcess>, BackgroundProcessConfigManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.Dump>, DumpManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.Lock>, LockManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.Sm51SysList>, SysListManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.UserSession>, UserSessionManager>();
            services.AddScoped<IManager<Entities.Concrete.Pure.SystemUsage>, SysUsageManager>();

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
            services.AddScoped<IBaseDal<Entities.Concrete.General.CustomerProductRl>, CustomerProductRlDal>();

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
            services.AddScoped<IEntityRepository<Entities.Concrete.General.CustomerProductRl>, EfEntityRepositoryBase<Entities.Concrete.General.CustomerProductRl, SapAgentContext>>();


            var backgroundProcessEndPoint = Configuration.GetSection("Endpoints:SapClientBackGroundProcessEndpointAddress").Value;
            var checkDumpsEndPoint = Configuration.GetSection("Endpoints:SapClientCheckDumpsEndpointAddress").Value;
            var checkLocksEndPoint = Configuration.GetSection("Endpoints:SapClientCheckLocksEndpointAddress").Value;
            var systemListEndPoint = Configuration.GetSection("Endpoints:SapClientSystemListEndpointAddress").Value;
            var systemUsageEndPoint = Configuration.GetSection("Endpoints:SapClientSystemUsageEndpointAddress").Value;
            var userSessionEndPoint = Configuration.GetSection("Endpoints:SapClientUserSessionEndpointAddress").Value;

            services.AddSingleton<zaygbcsys_ws_bckgprc>(new zaygbcsys_ws_bckgprcClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.BackgroundProcess",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri(backgroundProcessEndPoint))));

            //services.AddSingleton<zaygbcsys_ws_systlst>(new zaygbcsys_ws_systlstClient(new CustomBinding()
            //{
            //    SendTimeout = new TimeSpan(0, 0, 2, 30),
            //    CloseTimeout = new TimeSpan(0, 0, 2, 30),
            //    OpenTimeout = new TimeSpan(0, 0, 2, 30),
            //    ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
            //    Name = "prd",
            //    Namespace = "SapAgentApi.SystemList",
            //    Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            //}, new EndpointAddress(new Uri(systemListEndPoint))));

            services.AddSingleton<zaygbcsys_ws_chklocks>(new zaygbcsys_ws_chklocksClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.CheckLock",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri(checkLocksEndPoint))));

            services.AddSingleton<zaygbcsys_ws_sysusage>(new zaygbcsys_ws_sysusageClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.SystemUsage",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri(systemUsageEndPoint))));

            services.AddSingleton<zaygbcsys_ws_userses>(new zaygbcsys_ws_usersesClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.UserSession",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri(userSessionEndPoint))));



            services.AddSingleton<zaygbcsys_ws_chkdumps>(new zaygbcsys_ws_chkdumpsClient(new CustomBinding()
            {
                SendTimeout = new TimeSpan(0, 0, 2, 30),
                CloseTimeout = new TimeSpan(0, 0, 2, 30),
                OpenTimeout = new TimeSpan(0, 0, 2, 30),
                ReceiveTimeout = new TimeSpan(0, 0, 2, 30),
                Name = "prd",
                Namespace = "SapAgentApi.CheckDumps",
                Elements = { new TextMessageEncodingBindingElement() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11, ReaderQuotas = XmlDictionaryReaderQuotas.Max }, new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue } }
            }, new EndpointAddress(new Uri(checkDumpsEndPoint))));

            if (true)
            {
                services.AddScoped<IBackgroundProcessClientWrapper, BackgroundProcessClientWrapper>();
                services.AddScoped<ICheckDumpsClientWrapper, CheckDumpsClientWrapper>();
                services.AddScoped<IUserSessionClientWrapper, UserSessionClientWrapper>();
                services.AddScoped<ISystemUsageClientWrapper, SystemUsageClientWrapper>();
                services.AddScoped<ICheckLocksClientWrapper, CheckLocksClientWrapper>();
                services.AddScoped<ISystemListClientWrapper, SystemListClientWrapper>();

            }
            else
            {
                services.AddScoped<IUserSessionClientWrapper, UserSessionClientWrapperWithMockData>();
                services.AddScoped<ISystemUsageClientWrapper, SystemUsageClientWrapperWithMockData>();
                services.AddScoped<ICheckLocksClientWrapper, CheckLocksClientWrapperWithMockData>();
                services.AddScoped<ISystemListClientWrapper, SystemListClientWrapperWithMockData>();
                services.AddScoped<ICheckDumpsClientWrapper, CheckDumpsClientWrapperWithMockData>();
                services.AddScoped<IBackgroundProcessClientWrapper, BackgroundProcessClientWrapperWithMockData>();
            }

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
            }));
            services.AddSignalR();
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddControllersAsServices();
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
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseSignalR(routes =>
            {
                routes.MapHub<AlertHub>("/notify");
            });

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sap Agent Api Service v1.0");
            });
        }
    }
}
