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

        public ActionResult ViewMetrics()
        {
            var userLoggedIn = User.Identity.Name;

            //var query = _context.Metric.Include(u => u.ApplicationUser)
            //    .GroupBy(m => m.Month)
            //    .

            return View("ViewMetrics");
        }
    }
}