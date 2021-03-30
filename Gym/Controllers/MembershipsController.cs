using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.Controllers
{
    public class MembershipsController : Controller
    {
        private ApplicationDbContext _context;

        public MembershipsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Memberships
        public ActionResult Index()
        {
            var membershipTypes = _context.Memberships.ToList();

            if (User.IsInRole("Admin"))
            {
                return View(membershipTypes);
            }
            else
            {
                return View("MembershipList",membershipTypes);
            }
            

            
        }

        public ActionResult Create()
        {

            return View("MembershipForm", new Membership());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Membership membership)
        {
            if (!ModelState.IsValid)
            {
                return View("MembershipForm", membership);
            }

            if (membership.Id == 0)
            {
                _context.Memberships.Add(membership);
            }
            else
            {
                var newMembership = _context.Memberships.Single(m => m.Id == membership.Id);

                newMembership.MembershipType = membership.MembershipType;
                newMembership.Price = membership.Price;
                newMembership.DurationInMonths = membership.DurationInMonths;
                newMembership.DiscountRate = membership.DiscountRate;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Memberships");
        }

        public ActionResult Edit(int id)
        {
            var membership = _context.Memberships.SingleOrDefault(m => m.Id == id);

            if (membership == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("MembershipForm", membership);
            }
        }

        public ActionResult Details()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var membership = _context.Memberships.SingleOrDefault(m => m.Id == id);

            if (membership == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Memberships.Remove(membership);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Memberships");
        }
    }
}