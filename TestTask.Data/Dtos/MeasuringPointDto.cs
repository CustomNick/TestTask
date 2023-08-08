namespace TestTask.Data.Dtos {
    public class MeasuringPointDto {
        public long ConsumerObjectId { get; set; }

        public string Name { get; set; } = string.Empty;

        public long CounterNumber { get; set; }
        public CounterTypeDto CounterType { get; set; }
        public long CounterCheckDateTimestamp { get; set; }

        public long CurrentTransformatorNumber { get; set; }
        public CurrentTransformatorTypeDto CurrentTransformatorType { get; set; }
        public long CurrentTransormatorCheckDateTimestamp { get; set; }
        public float CurrentTransformatorCoefficient { get; set; }

        public long VoltageTransformatorNumber { get; set; }
        public VoltageTransformatorTypeDto VoltageTransformatorType { get; set; }
        public long VoltageTransormatorCheckDateTimestamp { get; set; }
        public float VoltageTransformatorCoefficient { get; set; }
    }
}