using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute: Attribute, IActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var receivedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var regPharmacyRepository = context.HttpContext.RequestServices.GetService<IPharmacyRepository>();
            if (!regPharmacyRepository.ExistsByApiKey(receivedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
