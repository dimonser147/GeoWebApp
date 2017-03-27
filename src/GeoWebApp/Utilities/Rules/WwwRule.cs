using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using System.Text;

namespace GeoWebApp.Utilities.Rules
{
    public class WwwRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;
            var currentHost = req.Host;
            if (!currentHost.Host.StartsWith("www."))
            {
                var newHost = new HostString("www." + currentHost.Host, currentHost.Port ?? 80);
                var newUrl = new StringBuilder()
                    .Append("http://")
                    .Append(newHost)
                    .Append(req.PathBase)
                    .Append(req.Path)
                    .Append(req.QueryString);
                context.HttpContext.Response.Redirect(newUrl.ToString());
                context.Result = RuleResult.EndResponse;
            }
        }
    }
}
