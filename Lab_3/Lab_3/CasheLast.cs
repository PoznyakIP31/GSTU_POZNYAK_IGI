using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Lab_3.Models;

namespace Lab_3
{
    public class CasheLast
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _memoryCache;

        public CasheLast(RequestDelegate next, IMemoryCache memCache)
        {
            _next = next;
            _memoryCache = memCache;
        }

        public async Task Invoke(HttpContext context, SportContext dbContext)
        {
            string path = context.Request.Path.Value.ToLower();
            object data = null;
            if (path == "/")
                data = dbContext.Visitors.Last();
            if (path == "/home/Index")
                data = dbContext.Visitors.Last();
            if (path == "/home/instructor")
                data = dbContext.Instructors.Last();
            if (path == "/home/group")
                data = dbContext.Groups.Last();
            if (path == "/home/timetable")
                data = dbContext.Timetables.Last();

            var dataTmp = data;
            if (!_memoryCache.TryGetValue(path, out dataTmp))
            {
                _memoryCache.Set(path, data, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(272)));
            }

            await _next.Invoke(context);
        }
    }

    public static class DbCacheExtensions
    {
        public static IApplicationBuilder UseLastElementCache(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CasheLast>();
        }
    }
}
