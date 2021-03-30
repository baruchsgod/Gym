using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.Controllers
{
    [Authorize(Roles = RoleName.Trainer +","+ RoleName.Admin)]
    public class TrainersController : Controller
    {
        // GET: Trainers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {

            return View();
        }
    }
}