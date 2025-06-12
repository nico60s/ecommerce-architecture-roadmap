using Ecommerce.Contracts.Auth.Services;

namespace Ecommerce.WebApi.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ITokenValidator tokenValidator)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader?.StartsWith("Bearer ") == true)
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();
                var principal = tokenValidator.Validate(token);

                if (principal is not null)
                {
                    context.User = principal;
                }
            }

            await _next(context);
        }
    }
}
