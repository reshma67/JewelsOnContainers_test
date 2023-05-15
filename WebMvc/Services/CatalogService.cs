using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _httpClient;
        public CatalogService(IConfiguration config, IHttpClient client) {
            _baseUrl = $"{config["CatalogUrl"]}/api/catalog";
            _httpClient = client ;
        }
        public async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
        {
            var brandUri = APIPath.Catalog.GetAllBrands(_baseUrl);
            var datastring = await _httpClient.GetStringAsync(brandUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected= true
                }

            };
            var brands = JArray.Parse(datastring);
            foreach(var item in brands)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<String>("id"),
                    Text = item.Value<String>("brand")

                }) ;
            }
            return items;
        }



        public async Task<Catalog> GetCatalogItemsAsync(int page, int size, int? brand, int? type)
        {
            var itemUri = APIPath.Catalog.GetAllCatalogItems(_baseUrl, page, size, brand, type);
            var dataString = await _httpClient.GetStringAsync(itemUri);
            return JsonConvert.DeserializeObject<Catalog>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetTypeAsync()
        {
            var typeUri = APIPath.Catalog.GetAllTypes(_baseUrl);
            var datastring = await _httpClient.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected= true
                }
            };
            var types = JArray.Parse(datastring);
            foreach( var item in types)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<String>("id"),
                    Text = item.Value<String>("type")
                });
            }
            return items;
        }
    }
}
