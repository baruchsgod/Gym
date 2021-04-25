using Gym.Models;
using Gym.ViewModel;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private ApplicationDbContext _context;

        public ReportsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
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

        public ActionResult CheckReserves()
        {
            var userLoggedIn = User.Identity.Name;

            var user = _context.Users.SingleOrDefault(m => m.Email == userLoggedIn);

            var date = DateTime.Now;

            var reserves = _context.Reserve.Where(m => m.ApplicationUserId == user.Id);

            var reserveActivity = _context.Reserve.Include(m => m.Activity).ToList();

            var activities = new List<Activity>();

            foreach (var item in reserveActivity)
            {

                if (item.Activity.Date >= date)
                {
                    activities.Add(item.Activity);
                }
            }

            var viewModel = new CustomerReservesViewModel()
            {
                ApplicationUser = user,
                Activities = activities
            };

            return View(viewModel);
        }

        public ActionResult ReserveDetails(int id)
        {
            var activity = _context.Activity.Include(t => t.ApplicationUser).SingleOrDefault(m => m.Id == id);

            if (activity == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("ActivityForm", activity);
            }
        }

        public ActionResult ViewRoutine()
        {
            var userLoggedIn = User.Identity.Name;

            var routines = _context.Routine.Include(u => u.ApplicationUser).ToList();

            var userRoutines = new List<Routine>();

            foreach (var item in routines)
            {
                if (item.ApplicationUser.Email == userLoggedIn)
                {
                    userRoutines.Add(item);
                }
            }

            return View("ViewRoutine", userRoutines);
        }

        public ActionResult RoutineDetails(int id)
        {
            var routine = _context.Routine.Include(u => u.ApplicationUser).SingleOrDefault(m => m.Id == id);

            if (routine == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("RoutineForm", routine);
            }
        }

        public ActionResult ViewPurchases()
        {
            var userLoggedIn = User.Identity.Name;

            var purchases = _context.Purchase.Include(u => u.ApplicationUser).Include(s => s.Supplement).Where(u => u.ApplicationUser.Email == userLoggedIn);

            return View("ViewPurchases", purchases);
        }

        public ActionResult GetMetrics()
        {
            return View("ViewMetrics");
        }

        public ActionResult ViewMetrics()
        {
            var userLoggedIn = User.Identity.Name;

            var user = _context.Users.SingleOrDefault(m => m.Email == userLoggedIn);

            
            var query = _context.Metric.Include(u => u.ApplicationUser).Where(u => u.ApplicationUserId == user.Id)
                .GroupBy(m => m.Month)
                .Select( x => new { 
                    Month = x.Key,
                    MassIndex = x.Select(y => y.MassIndex).Average(),
                    Weight = x.Select(y => y.Weight).Average(),
                    Chest = x.Select(y => y.Chest).Average(),
                    Waist = x.Select(y => y.Waist).Average(),
                    RightBicep = x.Select(y => y.RightBicep).Average(),
                    LeftBicep = x.Select(y => y.LeftBicep).Average(),
                    RightCalf = x.Select(y => y.RightCalf).Average(),
                    LeftCalf = x.Select(y => y.LeftCalf).Average(),
                    User = x.Select(y => y.ApplicationUserId).FirstOrDefault(),
                    Year = x.Select(y => y.Year).FirstOrDefault()
                });

            if (query == null)
            {
                return Json(null, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json(query, JsonRequestBehavior.AllowGet);
            }

            
        }

        public ActionResult ValidateClient()
        {
            return View();
        }

        public ActionResult ValidateClients()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindCustomer(string cedula)
        {
            if (String.IsNullOrEmpty(cedula))
            {
                return Json(null, JsonRequestBehavior.DenyGet);
            }
            else
            {
                var client = _context.Users.SingleOrDefault(m => m.cedula == cedula);


                if (client != null)
                {
                    return Json(client.Email, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.DenyGet);
                }
            }


        }

        public ActionResult GetMetric(string ced)
        {
            ViewBag.ced = ced;

            return View("ViewMetric");
        }

        public ActionResult GetRoutine(string ced)
        {
            var user = _context.Users.SingleOrDefault(m => m.cedula == ced);

            var routine = _context.Routine.Include(u => u.ApplicationUser).SingleOrDefault(m => m.ApplicationUserId == user.Id);

            return View("RoutineForm",routine);
        }

        public ActionResult ViewMetric(string ced)
        {
           

            var user = _context.Users.SingleOrDefault(m => m.cedula == ced);


            var query = _context.Metric.Include(u => u.ApplicationUser).Where(u => u.ApplicationUserId == user.Id)
                .GroupBy(m => m.Month)
                .Select(x => new {
                    Month = x.Key,
                    MassIndex = x.Select(y => y.MassIndex).Average(),
                    Weight = x.Select(y => y.Weight).Average(),
                    Chest = x.Select(y => y.Chest).Average(),
                    Waist = x.Select(y => y.Waist).Average(),
                    RightBicep = x.Select(y => y.RightBicep).Average(),
                    LeftBicep = x.Select(y => y.LeftBicep).Average(),
                    RightCalf = x.Select(y => y.RightCalf).Average(),
                    LeftCalf = x.Select(y => y.LeftCalf).Average(),
                    User = x.Select(y => y.ApplicationUserId).FirstOrDefault(),
                    Year = x.Select(y => y.Year).FirstOrDefault()
                });

            if (query == null)
            {
                return Json(null, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json(query, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult MyActivities()
        {
            var email = User.Identity.Name;

            var user = _context.Users.SingleOrDefault(u => u.Email == email);

            var myActivities = _context.Activity.Include(u => u.ApplicationUser).Where(m => m.ApplicationUserId == user.Id);

            var upcomingActivities = new List<Activity>();

            foreach (var item in myActivities)
            {
                if (item.Date >= DateTime.Now)
                {
                    upcomingActivities.Add(item);
                }
            }

            return View(upcomingActivities);
        }

        public ActionResult GetEvents()
        {
            var activities = _context.Activity.Where(m => m.Date >= DateTime.Now);

            return View(activities);
        }
    }
}