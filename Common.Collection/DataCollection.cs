namespace Common.Collection
{
    public class DataCollection<T>
    {
        public string? IdMessage { get; set; }
        public string? BodyResponseMessage { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
        public bool HasItems
        { 
            get 
            { 
                return Items != null && Items.Any(); 
            } 
        }

    }
}
