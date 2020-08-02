using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ConfiguringMiddleware
{
    public class LocationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<MessageOptions> _options;

        public LocationMiddleware(RequestDelegate next, IOptions<MessageOptions> options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/location/middleware/class")
            {
                var (city, country) = _options.Value;
                await context.Response.WriteAsync($"{city},{country}");
            }
            else
            {
                await _next(context);
            }
        }

    }
}
