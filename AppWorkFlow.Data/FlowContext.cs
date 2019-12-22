using AppWorkFlow.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppWorkFlow.Data
{
    public class FlowContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }
        public DbSet<FlowRequest> FlowRequests { get; set; }
        public DbSet<FlowRequestAction> FlowRequestActions { get; set; }

        public FlowContext(DbContextOptions<FlowContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (OnBeforeSaving())
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            return null;

        }
        private bool OnBeforeSaving()
        {
            try
            {
                if (true)
                {
                    var entries = ChangeTracker.Entries();
                    foreach (var entry in entries)
                    {
                        if (entry.Entity is Entitybase trackable)
                        {
                            var now = DateTime.UtcNow.AddHours(3);
                            var user = GetCurrentUser();
                            switch (entry.State)
                            {
                                case EntityState.Modified:
                                    entry.Property("ModifiedAt").CurrentValue = now;
                                    entry.Property("ModifiedBy").CurrentValue = user;
                                    entry.Property("CreatedAt").IsModified = false;
                                    break;
                                case EntityState.Added:
                                    entry.Property("CreatedAt").CurrentValue = now;
                                    entry.Property("ModifiedAt").IsModified = false;
                                    entry.Property("ModifiedBy").IsModified = false;
                                    break;
                                case EntityState.Deleted:
                                    entry.Property("DeletedAt").CurrentValue = now;
                                    entry.Property("DeletedBy").CurrentValue = user;
                                    entry.Property("ModifiedAt").IsModified = false;
                                    entry.Property("ModifiedBy").IsModified = false;
                                    entry.Property("CreatedAt").IsModified = false;

                                    break;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        private string GetCurrentUser()
        {
            return "demo";
        }
    }
}
