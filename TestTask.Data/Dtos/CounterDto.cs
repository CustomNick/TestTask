namespace TestTask.Data.Dtos {
    public class CounterDto {
        public long Id { get; set; }
        public long CounterNumber { get; set; }
        public CounterTypeDto CounterType { get; set; }
        public long CounterCheckDateTimestamp { get; set; }
    }
}