namespace FitForLife.Data
{
    using FitForLife.Data.Common.Models;
    using FitForLife.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    public class FitForLifeDbContext : IdentityDbContext<FitForLifeUser,FitForLifeRole,string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
           typeof(FitForLifeDbContext).GetMethod(
               nameof(SetIsDeletedQueryFilter),
               BindingFlags.NonPublic | BindingFlags.Static);
        public FitForLifeDbContext(DbContextOptions<FitForLifeDbContext> options)
            : base(options)
        {
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClientTrainer> ClientsTrainers { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<TrainingDay> TrainingDays { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();
            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable Cascade Delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            builder
                .Entity<ClientTrainer>()
                .HasOne(ct => ct.Client)
                .WithMany(c => c.Trainers)
                .HasForeignKey(ct => ct.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ClientTrainer>()
                .HasOne(ct => ct.Trainer)
                .WithMany(t => t.Clients)
                .HasForeignKey(ct => ct.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ClientTrainer>()
                .HasKey(k => new { k.ClientId, k.TrainerId });
            
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);
        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        
        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
