using Microsoft.EntityFrameworkCore;
using TestTask.Data.Entities;

namespace TestTask.Core.EF {
    public class TestTaskContext : DbContext {
        public TestTaskContext(DbContextOptions<TestTaskContext> opt) :
            base(opt) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {   
            modelBuilder.Entity<Measure>()
                .HasKey(
                    measure => new {
                        measure.MeasureDate,
                        measure.MeasuringPointId,
                        measure.DeliveryPointId,
                    }
                );

            modelBuilder.FillOrganisations();
            modelBuilder.FillConsumerObjects();
            modelBuilder.FillMeasuringPoints();
            modelBuilder.FillDeliveryPoints();
            modelBuilder.FillMeasures();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ConsumerObject> ConsumerObjects { get; set; } = null!;

        public DbSet<DeliveryPoint> DeliveryPoints { get; set; } = null!;

        public DbSet<MeasuringPoint> MeasuringPoints { get; set; } = null!;

        public DbSet<Organisation> Organisations { get; set; } = null!;

        public DbSet<Measure> Measures { get; set; } = null!;
    }
}