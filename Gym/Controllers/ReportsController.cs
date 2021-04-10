using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {

                return View("MenuAdmin");
            }
            else if(User.IsInRole("Trainer"))
            {

                return View("MenuTrainer");
            }
            else
            {
                return View("Menu");
            }
            
        }
    }
}