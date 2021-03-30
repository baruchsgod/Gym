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


    }
}