using Ecommerce.WebApi.Middlewares;

namespace Ecommerce.WebApi.Extensions
{
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomAuth(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthMiddleware>();
        }
    }

}
