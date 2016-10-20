using Buddy.Web.Client;
using Microsoft.AspNetCore.Http;

namespace Buddy.AspNetCore.Web.Client
{
    public class AspNetCorePageConfig : PageConfig
    {
        public AspNetCorePageConfig(HttpRequest request, string version)
        {            
            OriginUrl = $"{request.Scheme}://{request.Host.ToUriComponent()}/";
            RootUrl = $"{OriginUrl.TrimEnd('/')}{request.PathBase.ToUriComponent()}/";
            Version = version;
        }        
    }
}