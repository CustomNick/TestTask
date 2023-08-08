using System;
using Microsoft.EntityFrameworkCore;
using TestTask.Data.Entities;

namespace TestTask.Core.EF {
    public static class DataFiller {
        public static void FillOrganisations(
            this ModelBuilder builder
        ) {
            builder.Entity<Organisation>()
                .HasData(
                    new Organisation[] {
                        new Organisation {
                            Id = 1,
                            ParentOrganisation = null,
                            Name = "Organisation 1",
                            Address = "Address 1",
                        },
                        new Organisation {
                            Id = 2,
                            ParentOrganisationId = 1,
                            Name = "Organisation 1",
                            Address = "Address 1",
                        },
                    }
                );
        }
        public static void FillConsumerObjects(
            this ModelBuilder builder
        ) {
            builder.Entity<ConsumerObject>()
                .HasData(
                    new ConsumerObject[] {
                        new ConsumerObject {
                            Id = 1,
                            OrganisationId = 2,
                            Name = "ПС 110/10 Весна",
                            Address = "Consumer object 1 address",
                        },
                    }
                );
        }
        public static void FillMeasuringPoints(
            this ModelBuilder builder
        ) {
            builder.Entity<MeasuringPoint>()
                .HasData(
                    new MeasuringPoint[] {
                        new MeasuringPoint {
                            Id = 1,
                            ConsumerObjectId = 1,
                            Name = "Measuring point 1",
                            CounterNumber = 1,
                            CounterType = 1,
                            CounterCheckDate = DateTimeOffset.UtcNow,
                            CurrentTransformatorNumber = 1,
                            CurrentTransformatorType = 1,
                            CurrentTransormatorCheckDate = DateTimeOffset.UtcNow,
                            CurrentTransformatorCoefficient = 0.8f,
                            VoltageTransformatorNumber = 1,
                            VoltageTransformatorType = 1,
                            VoltageTransormatorCheckDate = DateTimeOffset.UtcNow,
                            VoltageTransformatorCoefficient = 0.7f,
                        },
                        new MeasuringPoint {
                            Id = 2,
                            ConsumerObjectId = 1,
                            Name = "Measuring point 2",
                            CounterNumber = 1,
                            CounterType = 2,
                            CounterCheckDate = DateTimeOffset.FromUnixTimeMilliseconds(0),
                            CurrentTransformatorNumber = 1,
                            CurrentTransformatorType = 2,
                            CurrentTransormatorCheckDate = DateTimeOffset.FromUnixTimeMilliseconds(0),
                            CurrentTransformatorCoefficient = 0.8f,
                            VoltageTransformatorNumber = 1,
                            VoltageTransformatorType = 2,
                            VoltageTransormatorCheckDate = DateTimeOffset.FromUnixTimeMilliseconds(0),
                            VoltageTransformatorCoefficient = 0.7f,
                        },
                    }
                );
        }
        public static void FillDeliveryPoints(
            this ModelBuilder builder
        ) {
            builder.Entity<DeliveryPoint>()
                .HasData(
                    new DeliveryPoint[] {
                        new DeliveryPoint {
                            Id = 1,
                            Name = "Delivery point 1",
                            MaxPower = 1000,
                            MeteringDeviceName = "Metering device 1",
                        },
                        new DeliveryPoint {
                            Id = 2,
                            Name = "Delivery point 2",
                            MaxPower = 2000,
                            MeteringDeviceName = "Metering device 2",
                        },
                    }
                );
        }
        public static void FillMeasures(
            this ModelBuilder builder
        ) {
            builder.Entity<Measure>()
                .HasData(
                    new Measure[] {
                        new Measure {
                            DeliveryPointId = 1,
                            MeasuringPointId = 1,
                            MeasureDate = DateTimeOffset.UtcNow,
                        },
                        new Measure {
                            DeliveryPointId = 2,
                            MeasuringPointId = 2,
                            MeasureDate = DateTimeOffset.FromUnixTimeMilliseconds(1528243200000),
                        },
                    }
                );
        }
    }
}