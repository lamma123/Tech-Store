using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Cookies;
using SE1726_NET_SWP391_Group5.Models;
using System.Text.Json;

namespace SE1726_NET_SWP391_Group5.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public Models.Order Order { get; set; }
        public Order order1 { get; set; }
        //[BindProperty]
        //public Models.OrderDetail OrderDetail { get; set; }
        private readonly SWP391Context context;
        public CheckoutModel(SWP391Context context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostCheckout()
        {

            Models.Account account = Class.GetAccountFromSession(HttpContext.Session);
            Order.OrderDate = DateTime.Now;
            Order.Status = 1;

            //Order.CustomerId = account.CustomerId;
            Order.CustomerId = account.CustomerId;

            // Lấy thông tin sản phẩm từ giỏ hàng
            var orderDetailsCard = Class.GetCartInfo(HttpContext);

            foreach (var item in orderDetailsCard)
            {
                Models.Product p = context.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == item.Value.ProductId);
                if (p == null)
                {
                    this.ViewData["Error"] = $"Product '{item.Value.Product.ProductName}' is not exist anymore";
                    return Page();
                }
                if (p.UnitInStock < item.Value.Quantity)
                {
                    this.ViewData["Error"] = $"Product '{item.Value.Product.ProductName}' is out of stock";
                    return Page();
                }
            }

            // Thêm đơn hàng vào bảng Orders
            context.Orders.Add(Order);
            context.SaveChanges();

            // Lấy `OrderID` lớn nhất hiện có và thêm 1
            int maxOrderId = context.Orders.Max(o => (int?)o.OrderId) ?? 0;
            foreach (var item in orderDetailsCard)
            {
                Models.Product p = context.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == item.Value.ProductId);
                // Tạo một bản ghi OrderDetail với các thuộc tính cần thiết
                var orderDetail = new Models.OrderDetail
                {
                    OrderId = maxOrderId,
                    ProductId = item.Value.ProductId,
                    UnitPrice = item.Value.UnitPrice,
                    Quantity = item.Value.Quantity,
                    Voucher = 4     // Đặt giảm giá = 0
                };

                // Thêm sản phẩm vào đơn hàng
                context.OrderDetails.Add(orderDetail);
                // Giảm số lượng sản phẩm có sẵn trong kho
                p.UnitInStock -= item.Value.Quantity;
                context.Products.Update(p);
            }
            context.SaveChanges();
            // Đặt lại giỏ hàng thành một giỏ hàng mới
            HttpContext.Response.Cookies.Append("Cart", JsonSerializer.Serialize(new Dictionary<int, OrderDetail>()), new CookieOptions() { Expires = DateTime.Now.AddDays(1) });

            return RedirectToPage("/Index");
        }

    }
}
