using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gym.ViewModel;

namespace Gym.Controllers
{
    public class SupplementsController : Controller
    {
        private ApplicationDbContext _context;

        public SupplementsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Supplements

        [Authorize]
        public ActionResult Index()
        {

            var supplements = _context.Supplements.ToList();

            if (User.IsInRole("Admin") || User.IsInRole("Trainer"))
            {
                
                return View("SupplementList", supplements);
            }
            else
            {
                
                return View("Index", supplements);
            }
            
        }


        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            return View("SupplementForm", new Supplement());
        }

        public ActionResult Edit(int id)
        {
            var supplement = _context.Supplements.SingleOrDefault(m => m.Id == id);

            if (supplement == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("SupplementForm", supplement);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Supplement supplement)
        {
            if (!ModelState.IsValid)
            {
                return View("SupplementForm", supplement);
            }

            if (supplement.Id == 0)
            {
                _context.Supplements.Add(supplement);
            }
            else
            {
                var newSupplement = _context.Supplements.SingleOrDefault(s => s.Id == supplement.Id);
                newSupplement.Description = supplement.Description;
                newSupplement.Price = supplement.Price;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Supplements");
        }

        [HttpPost]
        [Authorize]
        public ActionResult ShopCart(int id)
        {
            
            var supplement = _context.Supplements.SingleOrDefault(m => m.Id == id);

            var user = User.Identity.Name;

            var users = _context.Users.SingleOrDefault(m => m.Email == user);

            var shoppingCart = new ShoppingCart();

            shoppingCart.Name = users.Email;
            shoppingCart.Date = DateTime.Today;
            shoppingCart.ApplicationUserId = users.Id;
            shoppingCart.SupplementId = Convert.ToByte(supplement.Id);
            shoppingCart.Quantity = 1;
            shoppingCart.Description = supplement.Description;
            shoppingCart.Image = supplement.Image;
            shoppingCart.Price = supplement.Price;
            shoppingCart.Total = supplement.Price;
            shoppingCart.State = true;

            _context.ShoppingCart.Add(shoppingCart);

            _context.SaveChanges();

            return RedirectToAction("Index", "Supplements");
            
            
            
        }

        [Authorize]
        public ActionResult MyCart()
        {

            var MyCart = _context.ShoppingCart.Where(m => m.Name == User.Identity.Name).Where(m => m.State == true); 

            return View(MyCart);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var supplement = _context.Supplements.SingleOrDefault(m => m.Id == id);

            if (supplement == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Supplements.Remove(supplement);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Supplements");
        }

        public ActionResult UpdateCart(int id)
        {
            var myCartItem = _context.ShoppingCart.SingleOrDefault(m => m.Id == id);

            if (myCartItem == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(myCartItem);
            }
        }

        public ActionResult Payment()
        {
            var MyCart = _context.ShoppingCart.Where(m => m.Name == User.Identity.Name).Where(m => m.State == true);

            decimal total = 0;

            foreach (var item in MyCart)
            {
                
                total = total + item.Total;
            }

            var payment = new Payment()
            {
                Total = total, 
                DatePurchase = DateTime.Today
            };
            return View("Payment_Form", payment);
        }

        [HttpPost]
        public ActionResult SavePayment(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View("Payment_Form", payment);

            }
            else
            {
                _context.Payment.Add(payment);

                

                var MyCart = _context.ShoppingCart.Where(m => m.Name == User.Identity.Name).Where(m => m.State == true);

                foreach (var item in MyCart)
                {
                    item.State = false;

                    var newPurchase= new Purchase 
                    { 
                        Quantity = item.Quantity,
                        Total = item.Total,
                        Date = DateTime.Today,
                        ApplicationUser = item.ApplicationUser,
                        SupplementId = item.SupplementId
                    };

                    _context.Purchase.Add(newPurchase);
                    _context.SaveChanges();
                }

                return RedirectToAction("SuccessfullPurchase", "Supplements");
            }
            
        }

        public ActionResult SuccessfullPurchase()
        {

            return View("Success");
        }

        [HttpPost]

        public ActionResult SaveCart(ShoppingCart shopCart)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateCart", shopCart);
            }
            else
            {
                var shopItem = _context.ShoppingCart.SingleOrDefault(m => m.Id == shopCart.Id);

                shopItem.Quantity = shopCart.Quantity;
                shopItem.Total = shopCart.Price * shopCart.Quantity;
                _context.SaveChanges();
            }

            return RedirectToAction("MyCart", "Supplements");
            
        }

        [HttpPost]

        public ActionResult DeleteCart (int id)
        {
            var cartItem = _context.ShoppingCart.SingleOrDefault(m => m.Id == id);

            if (cartItem == null)
            {
                return HttpNotFound();
            }else
            {
                _context.ShoppingCart.Remove(cartItem); 
            }
            _context.SaveChanges();
            return RedirectToAction("MyCart", "Supplements");
        }
    }
}