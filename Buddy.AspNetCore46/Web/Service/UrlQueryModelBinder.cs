using System.Net;
using System.Threading.Tasks;
using Buddy.Web.UrlQuery;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Buddy.AspNetCore.Web.Service
{
    public class UrlQueryModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var queryString = WebUtility.UrlDecode(bindingContext.ActionContext.HttpContext.Request.QueryString.Value.TrimStart('?'));
            bindingContext.Result = ModelBindingResult.Success(queryString.ToQueryObject(bindingContext.ModelType));
            return Task.CompletedTask;
        }
    }
}