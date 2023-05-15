using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<SelectListItem>> GetBrandsAsync();
        Task<IEnumerable<SelectListItem>> GetTypeAsync();
        Task<Catalog> GetCatalogItemsAsync(int page, int size, int? brand, int?type);
        
    }
}
