using Gym.Models;
using Gym.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.Controllers
{
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext _context;

        public ActivitiesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Activities
        public ActionResult Index()
        {
            var allActivities = _context.Activity.ToList();

            var activities = new List<Activity>();

            var now = DateTime.Now;

            var month = 0;

            foreach (var item in allActivities)
            {
                if (item.Year >= now.Year && item.Date >= now)
                {
                    switch (item.Month)
                    {
                        case "January": month = 1; break;
                        case "February": month = 2; break;
                        case "March": month = 3; break;
                        case "April": month = 4; break;
                        case "May": month = 5; break;
                        case "June": month = 6; break;
                        case "July": month = 7; break;
                        case "August": month = 8; break;
                        case "September": month = 9; break;
                        case "October": month = 10; break;
                        case "November": month = 11; break;
                        case "December": month = 12; break;
                        default:
                            break;
                    }
                    if (item.Year == now.Year && month < now.Month)
                    {

                    }
                    else
                    {
                        

                        if (item.Reserve == null)
                        {
                            item.Reserve = 0;
                        }   
                        activities.Add(new Activity() { 
                            Id = item.Id,
                            Year = item.Year,
                            Month = item.Month,
                            day = item.day,
                            Description = item.Description,
                            Quantity = item.Quantity,
                            Hour = item.Hour,
                            Minutes = item.Minutes,
                            Shift = item.Shift,
                            ApplicationUserId = item.ApplicationUserId,
                            Price = item.Price,
                            Reserve = item.Quantity - item.Reserve,
                            MonthNum = month
                        });
                    }
                }

            }
            if (User.IsInRole("Admin"))
            {
                return View("CalendarAdmin", activities);
            }
            else if (User.IsInRole("Trainer"))
            {
                return View("CalendarTrainer",activities);
            }
            else
            {
                return View(activities);
            }
            
        }


        public ActionResult Create()
        {
            var exercises = _context.Exercise.ToList();

            var users = _context.Users.ToList();

            var trainers = users.Where(x => x.Roles.Select(role => role.RoleId).Contains("1aa6ef9e-d8e2-45f2-b359-4f882d26c250")).ToList();

            var viewModel = new ActivityViewModel()
            {
                Activity = new Activity(),
                Exercises = exercises,
                Trainers = trainers
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                if (activity.Id == 0)
                {
                    var users = _context.Users.ToList();
                    var viewModel = new ActivityViewModel()
                    {
                        Activity = new Activity(),
                        Exercises = _context.Exercise.ToList(),
                        Trainers = users.Where(x => x.Roles.Select(role => role.RoleId).Contains("1aa6ef9e-d8e2-45f2-b359-4f882d26c250")).ToList()
                    };

                    return View("Create", viewModel);
                }
                else
                {
                    var exercises = _context.Exercise.ToList();

                    var users = _context.Users.ToList();

                    var trainers = users.Where(x => x.Roles.Select(role => role.RoleId).Contains("1aa6ef9e-d8e2-45f2-b359-4f882d26c250")).ToList();

                    var viewModel = new ActivityViewModel()
                    {
                        Activity = _context.Activity.SingleOrDefault(m => m.Id == activity.Id),
                        Exercises = exercises,
                        Trainers = trainers
                    };

                    return View("Create", viewModel);
                }
                
            }

            var month = 0;
            switch (activity.Month)
            {
                case "January": month = 1; break;
                case "February": month = 2; break;
                case "March": month = 3; break;
                case "April": month = 4; break;
                case "May": month = 5; break;
                case "June": month = 6; break;
                case "July": month = 7; break;
                case "August": month = 8; break;
                case "September": month = 9; break;
                case "October": month = 10; break;
                case "November": month = 11; break;
                case "December": month = 12; break;
                default:
                    break;
            }

            if (activity.Id == 0)
            {
                

                DateTime value = new DateTime(activity.Year, month, activity.day);

                activity.Date = value;
                _context.Activity.Add(activity);
            }
            else
            {
                var Event = _context.Activity.SingleOrDefault(m => m.Id == activity.Id);

                
                Event.Hour = activity.Hour;
                Event.Year = activity.Year;
                Event.Month = activity.Month;
                Event.day = activity.day;
                Event.Description = activity.Description;
                Event.Quantity = activity.Quantity;
                Event.Minutes = activity.Minutes;
                Event.Shift = activity.Shift;
                Event.ApplicationUserId = activity.ApplicationUserId;
                Event.Price = activity.Price;
                Event.Quantity = activity.Quantity;
                Event.Reserve = activity.Reserve;
                Event.Date = new DateTime(activity.Year, month, activity.day);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Activities");
        }

        public ActionResult Exercise()
        {
            return View("ExerciseForm", new Exercise());
        }

        public ActionResult ListExercise()
        {
            var listExercises = _context.Exercise.ToList();
            return View(listExercises);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult SaveExercise(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return View("ExerciseForm", exercise);
            }

            if (exercise.Id == 0)
            {
                _context.Exercise.Add(exercise);
            }
            else
            {
                var exercises = _context.Exercise.SingleOrDefault(m => m.Id == exercise.Id);
                exercises.Name = exercise.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("ListExercise", "Activities");
        }

        public  ActionResult EditExercise(int id)
        {
            var exercises = _context.Exercise.SingleOrDefault(m => m.Id == id);
            if (exercises == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("ExerciseForm", exercises);
            }
            
        }

        public ActionResult DeleteExercise(int id)
        {
            var exercises = _context.Exercise.SingleOrDefault(m => m.Id == id);

            if (exercises == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Exercise.Remove(exercises);
            }

            _context.SaveChanges();
            return RedirectToAction("ListExercise", "Activities");
        }

        [HttpPost]
        public ActionResult Reserve(int id)
        {
            var activity = _context.Activity.SingleOrDefault(m => m.Id == id);

            var reserve = new ReserveViewModel()
            {
                Activity = activity,
                Payment = new Payment()
                {
                    Total = activity.Price,
                    DatePurchase = DateTime.Today
                }
            };
            return View("Payment_Form", reserve);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReservePayment()
        {
            return View();
        }

        public ActionResult EditActivity(int id)
        {
            var exercises = _context.Exercise.ToList();

            var users = _context.Users.ToList();

            var trainers = users.Where(x => x.Roles.Select(role => role.RoleId).Contains("1aa6ef9e-d8e2-45f2-b359-4f882d26c250")).ToList();

            var viewModel = new ActivityViewModel()
            {
                Activity = _context.Activity.SingleOrDefault(m =>m.Id == id),
                Exercises = exercises,
                Trainers = trainers
            };

            return View("Create",viewModel);
        }

        [HttpPost]
        public ActionResult DeleteActivity(int id)
        {
            var activity = _context.Activity.SingleOrDefault(m => m.Id == id);

            if (activity == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Activity.Remove(activity);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Activities");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReserveActivity(PaymentActivityViewModel paymentActivity)
        {
            if (!ModelState.IsValid)
            {
                return View("Payment_Form", paymentActivity);
            }

            var activity = _context.Activity.SingleOrDefault(m => m.Id == paymentActivity.Activity.Id);

            if (activity == null)
            {
                return HttpNotFound();
            }
            else
            {
                var userEmail = User.Identity.Name;

                var user = _context.Users.SingleOrDefault(m => m.Email == userEmail);

                var reserve = new Reserve()
                {
                    ActivityId = paymentActivity.Activity.Id,
                    ApplicationUserId = user.Id,
                    Date = DateTime.Today
                };

                _context.Payment.Add(paymentActivity.Payment);
                _context.Reserve.Add(reserve);

                if (activity.Reserve == null)
                {
                    activity.Reserve = 1;
                }
                else
                {
                    activity.Reserve = activity.Reserve + 1;
                }

                _context.SaveChanges();
                return RedirectToAction("SuccessfullReserve", "Activities", new { id = paymentActivity.Activity.Id });
            }
            
        }

        [HttpGet]
        public ActionResult ReserveEvent(int id)
        {
            var activity = _context.Activity.SingleOrDefault(m => m.Id == id);

            var viewModel = new PaymentActivityViewModel()
            {
                Payment = new Payment()
                {
                    Total = activity.Price,
                    DatePurchase = DateTime.Today
                },
                Activity = activity
            };

            return View("Payment_Form", viewModel);

        }

        [HttpGet]
        public ActionResult SuccessfullReserve(int id)
        {
            var activity = _context.Activity.SingleOrDefault(m => m.Id == id);

            if (activity == null)
            {
                return HttpNotFound();
            }
            else
            {

                return View("Success", activity);
            }
            
        }
    }
}