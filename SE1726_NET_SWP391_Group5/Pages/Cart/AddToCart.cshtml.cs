using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SE1726_NET_SWP391_Group5.Models;
using SE1726_NET_SWP391_Group5.Cookies;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SE1726_NET_SWP391_Group5.Pages.Cart
{
    public class AddToCartModel : PageModel
    {
        private readonly SWP391Context context;
        public AddToCartModel(SWP391Context context)
        {
            this.context = context;
        }
        public Customer Customer { get; set; }
        public Dictionary<int, OrderDetail> orderDetailsCard;

        public IActionResult OnGet(int productId, bool isBuyNow)
        {
            Models.Account account = Class.GetAccountFromSession(HttpContext.Session);
            if (account == null)
            {
                Customer = new Customer();
            }
            else
            {
                Customer = context.Customers.Find(account.CustomerId);
            }
            if (productId == 0)
            {
                return RedirectToPage("Index");
            }
            orderDetailsCard = Class.GetCartInfo(HttpContext);
            Models.Product productFromDB = context.Products.Find(productId);
            if (productFromDB == null)
            {
                return null;
            }
            if (orderDetailsCard == null)
            {
                orderDetailsCard = new Dictionary<int, OrderDetail>();
            }
            if (!orderDetailsCard.ContainsKey(productId))
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Product = productFromDB,
                    ProductId = productId,
                    Quantity = 1,
                    UnitPrice = (decimal)productFromDB.UnitPrice
                };
                orderDetailsCard.Add(productId, orderDetail);
            }
            else
            {
                orderDetailsCard[productId].Quantity++;
            }
            HttpContext.Response.Cookies.Append("Cart", JsonSerializer.Serialize(orderDetailsCard), new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
            return RedirectToPage("/Cart/Index");
        }
    }
}
