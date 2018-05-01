using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Lab_1.Models;

namespace Lab_1.Controllers
{
    public class CashedHomeController : Controller
    {
        private IMemoryCache _cache;
        public CashedHomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public IActionResult Index()
        {
            //считывание данных из кэша
            HomeViewModel cacheEntry = _cache.Get<HomeViewModel>("Entry 10");

            return View("~/Views/Home/Index.cshtml", cacheEntry);
        }


    }
}
