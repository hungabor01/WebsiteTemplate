using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using Shared.Resources;

namespace Website.Helpers.RedirectingRules
{
    public class RedirectEndingSlashCaseRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            var host = context.HttpContext.Request.Host;
            var path = request.Path.ToString();

            if (path.Length > 1 && path.EndsWith("/"))
            {
                request.Path = path.Remove(path.Length - 1, 1);
                var response = context.HttpContext.Response;
                response.StatusCode = Constants.MovedPermanently;
                response.Headers[HeaderNames.Location] = (request.Scheme + "://" + host.Value + request.PathBase + request.Path).ToLower() + request.QueryString;
                context.Result = RuleResult.EndResponse;
            }
            else
            {
                context.Result = RuleResult.ContinueRules;
            }
        }
    }
}
