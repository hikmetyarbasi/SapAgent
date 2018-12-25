using Microsoft.EntityFrameworkCore;
using SapAgent.Entities.Concrete;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.Pure;
using SapAgent.Entities.Concrete.Spa;

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
        public virtual DbSet<Entities.Concrete.Pure.KernelCompat> KernelCompat { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.Lock> Lock { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.Sm51SysList> Sm51SysList { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.SysInfo> SysInfo { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.SystemUsage> SystemUsage { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.SystemVersion> SystemVersion { get; set; }
        public virtual DbSet<Entities.Concrete.Pure.UserSession> UserSession { get; set; }
        public virtual DbSet<Entities.Concrete.Config.FuncFlag> FuncFlag { get; set; }

        public virtual DbSet<Entities.Concrete.Config.BackgroundProcessNotify> BackgroundNotification { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerProductRl> CustomerProductRls { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<BpNotifyView> BpNotifyViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuncFlag>().Property(u => u.Id).Metadata.IsReadOnlyAfterSave = true;
            base.OnModelCreating(modelBuilder);
        }
    }
}
