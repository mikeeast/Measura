using System;
using System.Net;
using System.Web.Mvc;
using Measura;

namespace Sample.Controllers
{
    public class ItemController : Controller
    {
        
        public ActionResult Index()
        {
            IPAddress ipAddress;
            IPAddress.TryParse(Request.UserHostAddress, out ipAddress);
            ItemMetric.RegisterView(1337, ipAddress, DateTime.Now);
            return View();
        }
    }
}
