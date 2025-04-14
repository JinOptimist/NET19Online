namespace StoreData.CustomQueryModels
{
    public class PagginatorModel<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
}
