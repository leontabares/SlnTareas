namespace Common.Collection
{
    public class DataResponse<T>
    {
        public string? IdMessage { get; set; }
        public string? BodyResponseMessage { get; set; }
        public IEnumerable<T>? Items { get; set; }
    }
}
