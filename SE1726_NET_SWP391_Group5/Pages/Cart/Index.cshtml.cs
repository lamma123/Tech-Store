using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SE1726_NET_SWP391_Group5.Cookies;
using SE1726_NET_SWP391_Group5.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace SE1726_NET_SWP391_Group5.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly SWP391Context db;
        private Dictionary<int, OrderDetail> orderDetails;

        [BindProperty]
        public bool HasItemsInCart { get; set; }
        public IndexModel(SWP391Context db)
        {
            this.db = db;

        }
        [BindProperty]
        public Customer Customer { get; set; }
        public Dictionary<int, OrderDetail> OrderDetails { get; set; }
        public async Task<IActionResult> OnGetAsync(int productId)
        {
            //Models.Account account = Class.GetAccountFromSession(HttpContext.Session);

            //if (account == null)
            //{
            //    return RedirectToPage("/Account/Login");
            //}

            orderDetails = Class.GetCartInfo(HttpContext);
            HasItemsInCart = orderDetails.Any();
            return Page();
        }

        public IActionResult OnPostChangeQuantity(int productId, short quantity)
        {
            Models.Product p = db.Products.Find(productId);
            if (p.UnitInStock < quantity)
            {
                this.ViewData["Error"] = $"Out of stock. This product has only {p.UnitInStock} items";
                return Page();
            }
            orderDetails = Class.GetCartInfo(HttpContext);
            orderDetails[productId].Quantity = quantity;
            HttpContext.Response.Cookies.Append("Cart", JsonSerializer.Serialize(orderDetails), new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
            return RedirectToAction("");
        }
        public IActionResult OnPostDelete(int productId)
        {
            orderDetails = Class.GetCartInfo(HttpContext);
            orderDetails.Remove(productId);
            HttpContext.Response.Cookies.Append("Cart", JsonSerializer.Serialize(orderDetails), new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
            return RedirectToAction("");
        }
    }
}
