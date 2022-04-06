using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.Authorization;
using Volo.Abp.Http;

namespace BackendAdminApp.Host
{
    public class AuthorizationExceptionHandler : IAbpAuthorizationExceptionHandler
    {
        private readonly Func<object, Task> _clearCacheHeadersDelegate;

        public AuthorizationExceptionHandler()
        {
            _clearCacheHeadersDelegate = ClearCacheHeaders;
        }

        public Task HandleAsync(AbpAuthorizationException exception, HttpContext httpContext)
        {
            return HandleAndWrapExceptionAsync(exception, httpContext);
        }

        protected virtual async Task HandleAndWrapExceptionAsync(AbpAuthorizationException exception, HttpContext httpContext)
        {
            var errorInfoConverter = httpContext.RequestServices.GetRequiredService<IExceptionToErrorInfoConverter>();
            var statusCodeFinder = httpContext.RequestServices.GetRequiredService<IHttpExceptionStatusCodeFinder>();

            httpContext.Response.Clear();
            httpContext.Response.StatusCode = (int)statusCodeFinder.GetStatusCode(httpContext, exception);
            httpContext.Response.OnStarting(_clearCacheHeadersDelegate, httpContext.Response);
            httpContext.Response.Headers.Add(AbpHttpConsts.AbpErrorFormat, "true");

            await httpContext.Response.WriteAsJsonAsync(new RemoteServiceErrorResponse(errorInfoConverter.Convert(exception)));
        }

        private Task ClearCacheHeaders(object state)
        {
            var response = (HttpResponse)state;

            response.Headers[HeaderNames.CacheControl] = "no-cache";
            response.Headers[HeaderNames.Pragma] = "no-cache";
            response.Headers[HeaderNames.Expires] = "-1";
            response.Headers.Remove(HeaderNames.ETag);

            return Task.CompletedTask;
        }
    }

}
