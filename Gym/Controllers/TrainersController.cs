using Gym.Models;
using Gym.ViewModel;
using System.Data.Entity;
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
        private ApplicationDbContext _context;

        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Trainers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {

            return View();
        }

        public ActionResult RoutineList()
        {
            var routines = _context.Routine.Include(c => c.ApplicationUser).ToList();

            return View(routines);
        }

        public ActionResult MetricList()
        {
            var metrics = _context.Metric.Include(c => c.ApplicationUser).ToList();

            return View(metrics);
        }

        public ActionResult CreateRoutine(string ced)
        {
            var viewModel = new CustomerRoutineViewModel()
            {
                User = _context.Users.SingleOrDefault(m => m.cedula == ced),
                Routine = new Routine()
                {
                    Date = DateTime.Now
                }
            };
            

            return View("RoutineForm", viewModel);
        }

        public ActionResult CreateMetric(string ced)
        {
            var user = _context.Users.SingleOrDefault(m => m.cedula == ced);
            var viewModel = new CustomerMetricViewModel()
            {
                User = user,
                Metric = new Metric()
                {

                    Date = DateTime.Now,
                    ApplicationUserId = user.Id
                }
            };


            return View("MetricForm", viewModel);
        }



        public ActionResult ValidateClient()
        {
            return View();
        }

        public ActionResult ValidateMetric()
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

        public ActionResult EditRoutine(int id, string ced)
        {
            var viewModel = new CustomerRoutineViewModel()
            {
                User = _context.Users.SingleOrDefault(m => m.cedula == ced),
                Routine = _context.Routine.SingleOrDefault(m => m.Id == id)
            };


            return View("RoutineForm", viewModel);
        }

        public ActionResult EditMetric(int id, string ced)
        {
            var viewModel = new CustomerMetricViewModel()
            {
                User = _context.Users.SingleOrDefault(m => m.cedula == ced),
                Metric = _context.Metric.SingleOrDefault(m => m.Id == id)
            };


            return View("MetricForm", viewModel);
        }

        public ActionResult ViewRoutine(int id, string ced)
        {
            var routine = _context.Routine.Include(c => c.ApplicationUser).SingleOrDefault(m => m.Id == id);

            return View(routine);
        }

        public ActionResult ViewMetric(int id, string ced)
        {
            var metric = _context.Metric.Include(c => c.ApplicationUser).SingleOrDefault(m => m.Id == id);

            return View(metric);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult SaveRoutine(CustomerRoutineViewModel customerRoutine)
        {
            if (!ModelState.IsValid)
            {
                if (customerRoutine.Routine.Id == 0)
                {
                    var viewModel = new CustomerRoutineViewModel()
                    {
                        User = _context.Users.SingleOrDefault(m => m.cedula == customerRoutine.User.cedula),
                        Routine = new Routine()
                        {
                            Date = DateTime.Now
                        }

                    };
                    return View("RoutineForm", viewModel);
                }
                else
                {
                    var viewModel = new CustomerRoutineViewModel()
                    {
                        User = _context.Users.SingleOrDefault(m => m.cedula == customerRoutine.User.cedula),
                        Routine = _context.Routine.SingleOrDefault(m => m.Id == customerRoutine.Routine.Id)

                    };
                    return View("RoutineForm", viewModel);
                }
                
                
            }
            else
            {
                if (customerRoutine.Routine.Id == 0)
                {
                    var newRoutine = customerRoutine.Routine;

                    newRoutine.ApplicationUserId = customerRoutine.User.Id;

                    _context.Routine.Add(newRoutine);
                }
                else
                {
                    var updateRoutine = _context.Routine.SingleOrDefault(m => m.Id == customerRoutine.Routine.Id);
                    updateRoutine.Type = customerRoutine.Routine.Type;
                    updateRoutine.BeginWeek = customerRoutine.Routine.BeginWeek;
                    updateRoutine.EndWeek = customerRoutine.Routine.EndWeek;
                    updateRoutine.WarmUp = customerRoutine.Routine.WarmUp;
                    updateRoutine.CoreBody = customerRoutine.Routine.CoreBody;
                    updateRoutine.UpperBody = customerRoutine.Routine.UpperBody;
                    updateRoutine.LowerBody = customerRoutine.Routine.LowerBody;
                    updateRoutine.CoolDown = customerRoutine.Routine.CoolDown;
                }
                
                _context.SaveChanges();

                return RedirectToAction("RoutineList", "Trainers");
            }
            
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult SaveMetric(CustomerMetricViewModel customerMetric)
        {
            if (!ModelState.IsValid)
            {
                if (customerMetric.Metric.Id == 0)
                {
                    var user = _context.Users.SingleOrDefault(m => m.cedula == customerMetric.User.cedula);

                    var viewModel = new CustomerMetricViewModel()
                    {
                        User = user,
                        Metric = new Metric()
                        {

                            Date = DateTime.Now,
                            ApplicationUserId = user.Id
                        }

                    };
                    return View("MetricForm", viewModel);
                }
                else
                {
                    var viewModel = new CustomerMetricViewModel()
                    {
                        User = _context.Users.SingleOrDefault(m => m.cedula == customerMetric.User.cedula),
                        Metric = _context.Metric.SingleOrDefault(m => m.Id == customerMetric.Metric.Id)

                    };
                    return View("MetricForm", viewModel);
                }


            }
            else
            {
                if (customerMetric.Metric.Id == 0)
                {
                    var newMetric = customerMetric.Metric;

                    newMetric.ApplicationUserId = customerMetric.User.Id;

                    _context.Metric.Add(newMetric);
                }
                else
                {
                    var updateMetric = _context.Metric.SingleOrDefault(m => m.Id == customerMetric.Metric.Id);
                    updateMetric.MassIndex = customerMetric.Metric.MassIndex;
                    updateMetric.Weight = customerMetric.Metric.Weight;
                    updateMetric.Chest = customerMetric.Metric.Chest;
                    updateMetric.RightBicep = customerMetric.Metric.RightBicep;
                    updateMetric.LeftBicep = customerMetric.Metric.LeftBicep;
                    updateMetric.RightCalf = customerMetric.Metric.RightCalf;
                    updateMetric.LeftCalf = customerMetric.Metric.LeftCalf;
                    updateMetric.Month = customerMetric.Metric.Month;
                    updateMetric.Year = customerMetric.Metric.Year;
                    
                }

                _context.SaveChanges();

                return RedirectToAction("MetricList", "Trainers");
            }
        }

        [HttpPost]
        public ActionResult DeleteRoutine(int id)
        {
            var routine = _context.Routine.SingleOrDefault(m => m.Id == id);

            if (routine == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Routine.Remove(routine);
            }

            _context.SaveChanges();
            return RedirectToAction("RoutineList", "Trainers");
        }

        [HttpPost]
        public ActionResult DeleteMetric(int id)
        {
            var metric = _context.Metric.SingleOrDefault(m => m.Id == id);

            if (metric == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Metric.Remove(metric);
            }

            _context.SaveChanges();
            return RedirectToAction("MetricList", "Trainers");
        }

    }
}

