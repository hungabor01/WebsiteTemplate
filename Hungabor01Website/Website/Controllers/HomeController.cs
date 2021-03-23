using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleMvcSitemap;
using System.Collections.Generic;
using System.Text;

namespace Website.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/robots.txt")]
        public ContentResult RobotsTxt()
        {
            var sb = new StringBuilder();
            sb.AppendLine("User-agent: *")
                .AppendLine("Allow: /")
                .AppendLine("Sitemap: https://hungabor01.com/sitemap");

            return Content(sb.ToString(), "text/plain", Encoding.UTF8);
        }

        [Route("/sitemap")]
        public ActionResult SiteMap()
        {
            List<SitemapNode> nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("index","home")),
                new SitemapNode(Url.Action("privacy","home")),
            };

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}
