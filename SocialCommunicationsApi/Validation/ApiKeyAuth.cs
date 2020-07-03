namespace SocialCommunicationsApi.Validation
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Api Key Auth Validation Middleware.
    /// </summary>
    /// <seealso cref="OutputModel"/>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuth : Attribute, IAsyncActionFilter
    {
        /// <summary>
        /// On Action Excution to Api Request. Validate the Headers ApiKeyHeader.
        /// </summary>
        /// <param name="context" cref="ActionExecutingContext">Action Excution Context.</param>
        /// <param name="next" cref="ActionExecutionDelegate">Action Excution Delegte.</param>
        /// <returns cref="OutputModel">Chat Common Output Model.</returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKeyHeader", out var ApikeyHeaderValue))
            {
                context.Result = new UnauthorizedObjectResult(new OutputModel()
                {
                    ExecutionalStatus = SocialCommunicationModels.CommonModels.ExecutionStatusEnums.ExecutionStatus.UnAuthorized
                });
                return;
            }

            var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var ApikeyValue = config.GetValue<string>("ApiKeyValue");


            if (!ApikeyValue.Equals(ApikeyHeaderValue))
            {
                context.Result = new UnauthorizedObjectResult(new OutputModel()
                {
                    ExecutionalStatus = SocialCommunicationModels.CommonModels.ExecutionStatusEnums.ExecutionStatus.UnAuthorized
                });
                return;
            }

            await next();
        }
    }
}
