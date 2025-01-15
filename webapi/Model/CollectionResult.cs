namespace webapi.Model
{
    public class CollectionResult<T>
    {
        public required List<T> Items { get; set; }
        public required int TotalCount { get; set; }
    }
}
