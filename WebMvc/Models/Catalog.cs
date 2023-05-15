namespace WebMvc.Models
{
    public class Catalog
    {
        public int PageIndex;
        public int PageSize;
        public long count;
        public IEnumerable<CatalogItem> Data { get; set; }
    }
}
