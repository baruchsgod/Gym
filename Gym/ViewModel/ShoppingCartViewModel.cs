using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.ViewModel
{
    public class ShoppingCartViewModel
    {
        public ApplicationUser App_user { get; set; }

        public List<Supplement> Supplement { get; set; }
    }
}