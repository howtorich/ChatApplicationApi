namespace SocialCommunicationsApi.Validation
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using System;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuth : Attribute, IAsyncActionFilter
    {
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
