using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Pannexus.PsNutrac.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SampleLTEControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}