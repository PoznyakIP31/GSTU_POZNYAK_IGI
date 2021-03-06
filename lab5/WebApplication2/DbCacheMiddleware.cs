﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace Lab_1
{
    //Компонент middleware для выполнения кэширования
    public class DbCacheMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _memoryCache;
        private string _cacheKey;

        public DbCacheMiddleware(RequestDelegate next, IMemoryCache memoryCache, string cacheKey = "Entry 10")
        {
            _next = next;
            _memoryCache = memoryCache;
            _cacheKey = cacheKey;
        }

        public Task Invoke(HttpContext httpContext, Service Service)
        {
            HomeViewModel homeViewModel;
            // пытаемся получить элемент из кэша
            if (!_memoryCache.TryGetValue(_cacheKey, out homeViewModel))
            {
                // если в кэше не найден элемент, получаем его от сервиса
                homeViewModel = Service.GetHomeViewModel();
                // и сохраняем в кэше
                _memoryCache.Set(_cacheKey, homeViewModel,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));

            }

            return _next(httpContext);
        }
    }

    // Метод расширения, используемый для добавления промежуточного программного обеспечения в конвейер HTTP-запроса.
    public static class DbCacheMiddlewareExtensions
    {
        public static IApplicationBuilder UseOperatinCache(this IApplicationBuilder builder, string cacheKey)
        {
            return builder.UseMiddleware<DbCacheMiddleware>(cacheKey);
        }
    }
}

