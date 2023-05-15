namespace WebMvc.Infrastructure
{
    public static class APIPath
    {
        public static class Catalog
        {
            public static string GetAllTypes(string BaseUrl)
            {
                return $"{BaseUrl}/CatalogTypes";
            }
            public static string GetAllBrands(string BaseUrl)
            {
                return $"{BaseUrl}/CatalogBrands";
            }
            public static string GetAllCatalogItems(string BaseUrl, int page, int take, int? brand, int? type) 
            {
                var preUri = string.Empty;
                var filterQs = string.Empty;
                if (brand.HasValue)
                {
                    filterQs = $"CatalogBrandId={brand.Value}";
                }
                if (type.HasValue)
                {
                    filterQs = filterQs== string.Empty ? $"CatalogTypeId={type.Value}": $"{filterQs}&CatalogTypeId={type.Value}";
                }
                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri =  $"{BaseUrl}/items?pageIndex={page}&pageSize={take}";
                }
                else
                {
                    preUri = $"{BaseUrl}/items/filter?pageIndex={page}&pageSize={take}&{filterQs}";
                }

                return preUri ;
            }
        }
    }
}
