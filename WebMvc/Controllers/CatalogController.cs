﻿using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service) 
        {
            _service= service;
        }
        public async  Task<IActionResult> Index(int? page, int? brandFilterApplied, int? typesFilterApplied)
        {
            int itemsOnPage = 10;
            var catalog = await _service.GetCatalogItemsAsync(page ?? 0,itemsOnPage, brandFilterApplied, typesFilterApplied);

            var vm = new CatalogIndexViewModel
            {
                Brands = await _service.GetBrandsAsync(),
                Types = await _service.GetTypeAsync(),
                CatalogItems = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = catalog.PageIndex,
                    TotalItems = catalog.count,
                    ItemsPerPage = catalog.PageSize,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.count / itemsOnPage)
                },
                BrandFilterApplied = brandFilterApplied,
                TypesFilterApplied = typesFilterApplied
            };
            return View(vm);
        }
    }
}
