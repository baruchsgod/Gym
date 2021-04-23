using Gym.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gym.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Users
        public ActionResult Index()
        {

            var users = _context.Users.ToList();
            return View("UserList",users);
        }

        public ActionResult Menu()
        {

            return View();
        }

        public ActionResult Create()
        {
            
            return View();
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }
        public ActionResult EditUser(string id)
        {
            var user = _context.Users.SingleOrDefault(m => m.Id == id);

            var role = user.Roles.SingleOrDefault(c => c.UserId == id);

            if (role == null)
            {
                return View("ClientForm", user);
            }
            else
            {
                if (role.RoleId == "1aa6ef9e-d8e2-45f2-b359-4f882d26c250")
                {
                    return View("EmployeeForm", user);
                }
                else
                {
                    return View("EmployeeForm", user);
                }
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> UpdateCustomer(ApplicationUser model)
        {
            if (!ModelState.IsValid)
            {
                return View("ClientForm", model);
            }
            else
            {
                var clientUpdate = _context.Users.SingleOrDefault(m => m.Id == model.Id);

                clientUpdate.cedula = model.cedula;
                clientUpdate.fName = model.fName;
                clientUpdate.lName = model.lName;
                clientUpdate.Telefono = model.Telefono;
                clientUpdate.BirthDate = model.BirthDate;
                clientUpdate.Email = model.Email;

                _context.SaveChanges();

                return RedirectToAction("Index","Users");
                
            }

            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee(ApplicationUser model)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeForm", model);
            }
            else
            {
                var EmployeeUpdate = _context.Users.SingleOrDefault(m => m.Id == model.Id);

                EmployeeUpdate.cedula = model.cedula;
                EmployeeUpdate.fName = model.fName;
                EmployeeUpdate.lName = model.lName;
                EmployeeUpdate.Telefono = model.Telefono;
                EmployeeUpdate.BirthDate = model.BirthDate;
                EmployeeUpdate.BeginDate = model.BeginDate;
                EmployeeUpdate.Email = model.Email;

                _context.SaveChanges();

                return RedirectToAction("Index", "Users");

            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(RegisterViewModelTrainer model)
        {
            if (ModelState.IsValid)
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

                var user = new ApplicationUser { cedula = model.Cedula, fName = model.fName, lName = model.lName, Telefono = model.Telefono, BirthDate = model.BirthDate, BeginDate = model.BeginDate, UserName = model.Email, Email = model.Email };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Trainer");

                    return RedirectToAction("Index", "Users");

            }
        }

            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> SaveCustomer(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

                var user = new ApplicationUser { cedula = model.Cedula, fName = model.fName, lName = model.lName, Telefono = model.Telefono, BirthDate = model.BirthDate, UserName = model.Email, Email = model.Email };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Users");

                }
                
            }
            return View("CreateCustomer", model);
        }

        [HttpPost]

        public ActionResult Delete(string id)
        {
            var user = _context.Users.SingleOrDefault(m => m.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

                return RedirectToAction("Index","Users");
            }
            else
            {
                return HttpNotFound();
            }
        }




    }
}