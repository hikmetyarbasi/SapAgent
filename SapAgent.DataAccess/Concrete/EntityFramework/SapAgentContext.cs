using Microsoft.EntityFrameworkCore;
using SapAgent.Entities.Concrete;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.Pure;
using SapAgent.Entities.Concrete.Spa;
using SysUsage = SapAgent.Entities.Concrete.Config.SysUsage;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class SapAgentContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =185.122.201.43,1433;initial catalog=SAPAGENT;User Id=hikmetyarbasi;password=123456;");
        }
        public virtual DbSet<Entities.Concrete.Pure.RtmInfo> RtmInfo { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.RtmInfoBase> RtmInfoBase { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.BackgroundProcess> BackgroundProcess { get; set; }
        public virtual DbSet<Entities.Concrete.Config.BackgroundProcess> BackgroundProcessConfig { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.Dump> Dump { get; set; }
        public virtual DbSet<Entities.Concrete.Config.Dump> ConfigDump { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.KernelCompat> KernelCompat { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.Lock> Lock { get; set; }
        public virtual DbSet<Entities.Concrete.Config.Lock> ConfigLock { get; set; }
        public virtual DbSet<SysUsage> ConfigSysUsage { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.SysUsage> SystemUsage { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.SysList> SysList { get; set; }
        public virtual DbSet<Entities.Concrete.Config.SysList> ConfigSysList { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.SysFile> PureSysFile { get; set; }
        public virtual DbSet<Entities.Concrete.Config.SysFile> ConfigSysFile { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.SysInfo> SysInfo { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.SystemVersion> SystemVersion { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.UserSession> UserSession { get; set; }
        public virtual DbSet<Entities.Concrete.Config.FuncFlag> FuncFlag { get; set; }

        public virtual DbSet<Entities.Concrete.Config.BackgroundProcessNotify> BackgroundNotification { get; set; }
        public virtual DbSet<Entities.Concrete.Config.LockNotify> LockNotify { get; set; }
        public virtual DbSet<Entities.Concrete.Config.DumpNotify> DumpNotifys { get; set; }
        public virtual DbSet<Entities.Concrete.Config.SysListNotify> SysListNotifys { get; set; }
        public virtual DbSet<SysUsageNotify> SysUsageNotifys { get; set; }
        public virtual DbSet<Entities.Concrete.Config.SysFileNotify> SysFileNotifys { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerProductRl> CustomerProductRls { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<BpNotifyCountView> BpNotifyCountViews { get; set; }
        public virtual DbSet<BpNotifyDetailView> BpNotifyDetailViews { get; set; }
        public virtual DbSet<AllNotifyCountView> AllNotifyCountViews { get; set; }
        public virtual DbSet<LockNotifyDetailView> LockNotifyDetailViews { get; set; }
        public virtual DbSet<LockNotifyCountView> LockNotifyCountViews { get; set; }
        public virtual DbSet<DumpNotifyDetailView> DumpNotifyDetailViews { get; set; }
        public virtual DbSet<DumpNotifyCountView> DumpNotifyCountViews { get; set; }
        public virtual DbSet<SysUsageNotifyDetailView> SysUsageNotifyDetailViews { get; set; }
        public virtual DbSet<SysUsageNotifyCountView> SysUsageNotifyCountViews { get; set; }
        public virtual DbSet<SysListNotifyDetailView> SysListNotifyDetailViews { get; set; }
        public virtual DbSet<SysListNotifyCountView> SysListNotifyCountViews { get; set; }
        public virtual DbSet<SysFileNotifyDetailView> SysFileNotifyDetailViews { get; set; }
        public virtual DbSet<SysFileNotifyCountView> SysFileNotifyCountViews { get; set; }

        public virtual DbSet<CustomerProductView> CustomerProductViews { get; set; }
        public virtual DbSet<ClientMonitoringView> ClientMonitoringViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuncFlag>().Property(u => u.Id).Metadata.IsReadOnlyAfterSave = true;
            base.OnModelCreating(modelBuilder);
        }
    }
}
