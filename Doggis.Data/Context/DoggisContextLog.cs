using Doggis.Data.Models;
using Doggis.Data.Models.Mapping;
using Doggis.Data.Programmability.Functions;
using Doggis.Data.Programmability.Stored_Procedures;
using System;
using System.Configuration;
using System.Data.Entity;

namespace Doggis.Data.Repository
{
    public class DoggisontextLog : DbContext
    {
        public static string GetConnectionString(string connectionString)
        {
            var azureFunctionsConnection = Environment.GetEnvironmentVariable(connectionString);
            var defaultConnection = ConfigurationManager.ConnectionStrings[connectionString]?.ConnectionString;

            return defaultConnection ?? azureFunctionsConnection ?? connectionString;
        }

        public DoggisontextLog(string contextName) : base(GetConnectionString(contextName))
        {
            StoredProcedures = new StoredProcedures(this);
            ScalarValuedFunctions = new ScalarValuedFunctions(this);
            TableValuedFunctions = new TableValuedFunctions(this);
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Models.Service> Service { get; set; }
        public DbSet<ServicePriceHistory> ServicePriceHistory { get; set; }
        public DbSet<ServiceSchedule> ServiceSchedule { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAvaliation> UserAvaliation { get; set; }
        public DbSet<VeterinaryAllowedSpecie> VeterinaryAllowedSpecies { get; set; }

        public StoredProcedures StoredProcedures { get; set; }
        public ScalarValuedFunctions ScalarValuedFunctions { get; set; }
        public TableValuedFunctions TableValuedFunctions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new PetMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new PromotionMap());
            modelBuilder.Configurations.Add(new ServiceMap());
            modelBuilder.Configurations.Add(new ServicePriceHistoryMap());
            modelBuilder.Configurations.Add(new ServiceScheduleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserAvaliationMap());
            modelBuilder.Configurations.Add(new VeterinaryAllowedSpecieMap());
        }
    }
}
