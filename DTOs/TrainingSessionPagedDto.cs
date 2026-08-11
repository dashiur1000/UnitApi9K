namespace UnitApi9K.DTOs
{
    public class TrainingSessionPagedDto
    {
        public object Items { get; set; }
        public int TotalCount { get; set; }
        public int Page {  get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
