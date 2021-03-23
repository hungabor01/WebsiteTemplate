using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using Shared.Resources;
using System.Linq;

namespace Website.Helpers.RedirectingRules
{
    public class RedirectLowerCaseRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            var path = context.HttpContext.Request.Path;
            var pathbase = context.HttpContext.Request.PathBase;
            var host = context.HttpContext.Request.Host;

            if ((path.HasValue && path.Value.Any(char.IsUpper)) ||
                (host.HasValue && host.Value.Any(char.IsUpper)) ||
                (pathbase.HasValue && pathbase.Value.Any(char.IsUpper)))
            {
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
