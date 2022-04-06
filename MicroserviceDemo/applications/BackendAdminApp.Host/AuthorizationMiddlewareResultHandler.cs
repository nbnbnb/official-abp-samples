using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.Authorization;

namespace BackendAdminApp.Host
{
    public class AuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly IAbpAuthorizationExceptionHandler _authorizationExceptionHandler;

        public AuthorizationMiddlewareResultHandler(IAbpAuthorizationExceptionHandler authorizationExceptionHandler)
        {
            _authorizationExceptionHandler = authorizationExceptionHandler;
        }

        public async Task HandleAsync(
            RequestDelegate next,
            HttpContext context,
            AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Challenged)
            {
                await context.ChallengeAsync();
                await _authorizationExceptionHandler.HandleAsync(new AbpAuthorizationException(code: AbpAuthorizationErrorCodes.GivenPolicyHasNotGranted), context);

                return;
            }

            if (authorizeResult.Forbidden)
            {
                await context.ForbidAsync();
                await _authorizationExceptionHandler.HandleAsync(new AbpAuthorizationException(code: AbpAuthorizationErrorCodes.GivenPolicyHasNotGranted), context);

                return;
            }

            await next(context);
        }
    }

}

/**
 * 
 * 问题原因：
 * 
 * Abp 5.X 版本，未认证直接访问 API 重定向至登录页
 * 
 * 期望目标：
 * 与 4.x 版本一致，返回 JSON 错误信息
 * 
 * 
 * 如果 Abp5.X 生成模板的时候，选择分离 IdentityServer 则只会返回 401 且无返回值
 * 不分离的话会走 IdentityServer 的 Cookie 认证，就会导致重定向至登录页
 * 
 * 当您调用需要身份验证的控制器时，身份验证中间件会发现当前用户未通过身份验证，并调用 ChallengeAsync（DefaultChallengeScheme 是标识 Cookie）
 * 
 * 此时，请求已被短路
 * 
 * 如果匿名控制器调用应用程序服务方法，它将执行 ABP 筛选器和侦听器。
 * 
 * 框架抛出 AbpAuthorizationException，过滤器将异常包装到 401 中，依此类推
 * 
 ** /