using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {

            var MyCart = _context.ShoppingCart.Where(m => m.Name == User.Identity.Name).Where(m => m.State == true);

            if (MyCart.Count() > 0)
            {
                
                Session["Cart"] = MyCart.Count();
            }
            else
            {
                Session["Cart"] = 0;
            }
            


            return View();
        }

        
    }
}