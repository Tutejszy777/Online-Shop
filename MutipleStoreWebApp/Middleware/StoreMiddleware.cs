using MutipleStoreWebApp.Services;

namespace MutipleStoreWebApp.Middleware
{
    public class StoreMiddleware
    {
        private readonly RequestDelegate _next;

        public StoreMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IStoreService storeService)
        {
            var path = context.Request.Path.Value;
            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length > 0)
            {
                var storeSlug = segments[0];
                var store = await storeService.GetStoreBySlug(storeSlug); // Fetch from DB

                if (store != null)
                {
                    context.Items["StoreId"] = store.Id;
                    context.Items["CurrentStore"] = store;
                }
            }

            await _next(context);
        }
    }
}
