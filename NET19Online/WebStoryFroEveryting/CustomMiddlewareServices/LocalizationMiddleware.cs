using Microsoft.AspNetCore.Http;
using StoreData.Repostiroties;
using System.Globalization;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.CustomMiddlewareServices
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authService = context.RequestServices.GetRequiredService<AuthService>();

            if (!authService.IsAuthenticated())
            {
                // call new middleware service
                await _next.Invoke(context);
                return;
            }

            var userId = authService.GetUserId();
            var userRepository = context.RequestServices.GetRequiredService<IUserRepository>();

            var locale = userRepository.GetLocale(userId);
            CultureInfo culture;
            switch (locale)
            {
                case Enums.User.UserLocale.English:
                    culture = new CultureInfo("en-EN");
                    break;
                case Enums.User.UserLocale.Russian:
                    culture = new CultureInfo("ru-RU");
                    break;
                default:
                    throw new Exception($"Uknown local {locale}");
            }

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            await _next.Invoke(context);
        }
    }
}
