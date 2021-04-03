﻿using Gym.Models;
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
                if (item.Year >= now.Year)
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
                            MonthNum = month
                        });
                    }
                }

            }

            return View(activities);
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
                return View("Create", activity);
            }


            return View();
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
    }
}