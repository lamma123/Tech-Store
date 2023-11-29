using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SE1726_NET_SWP391_Group5.Cookies;
using SE1726_NET_SWP391_Group5.Models;
using System.Text.Json;

namespace SE1726_NET_SWP391_Group5.Pages.Cart
{
    public class DeleteModel : PageModel
    {
        public Dictionary<int, OrderDetail> orderDetails { get; set; }
        public IActionResult OnGet(int productId)
        {
            orderDetails = Class.GetCartInfo(HttpContext);

            if (orderDetails.ContainsKey(productId))
            {
                orderDetails.Remove(productId);
            }
            HttpContext.Response.Cookies.Append("Cart", JsonSerializer.Serialize(orderDetails), new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
            return RedirectToPage("Index");
        }
    }
}
