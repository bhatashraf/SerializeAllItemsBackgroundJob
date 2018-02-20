using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sc = Sitecore;
using SitecoreJobCreation.Sitecore.Jobs;

namespace SitecoreJobCreation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            JobService service = new JobService();
            service.StartJob(sc.Context.Item);
           
            if(service.Job != null)
            {
                Response.Write(string.Format("Job status: {0}. Count: {1}",service.Job.Status.State,service.Job.Status.Processed));
            }
            return View();
        }
    }
}