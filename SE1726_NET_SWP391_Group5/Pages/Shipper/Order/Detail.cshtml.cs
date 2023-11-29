using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages.Shipper.Order
{
    public class DetailModel : PageModel
    {
        private readonly SWP391Context _db;
        public DetailModel(SWP391Context db)
        {
            _db = db;
        }
        public void OnGet(int? id, int? status)
        {
            Models.Shipper sp = new Models.Shipper();
            Models.Order order = new Models.Order();
            if (status == null)
            {
                if (id == null)
                {
                    RedirectToPage("/Shipper/Order/List");
                }
                order = GetOrderById(id);
                if (order.ShipperId != null)
                {
                    sp = _db.Shippers.Where(x => x.ShipperId == order.ShipperId).FirstOrDefault();
                }
                ViewData["spname"] = sp.Name;
                ViewData["od"] = order;
            }
            else
            {
                Models.Order od = _db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
                od.Status = status;
                switch (status)
                {
                    case 3:
                        od.DeliveryDateFrom = DateTime.Now;
                        break;
                    case 4:
                        od.DeliveryDateTo = DateTime.Now;
                        break;
                }
                // sau hoàn thiện lấy shipper id và update vào dtb ở đây
                // od.ShipperId = HttpContext.Session.GetString("id");
                _db.Update(od);
                _db.SaveChanges();
                order = GetOrderById(id);
                if (order.ShipperId != null)
                {
                    sp = _db.Shippers.Where(x => x.ShipperId == order.ShipperId).FirstOrDefault();

                }
                ViewData["spname"] = sp.Name;
                ViewData["od"] = order;
            }

        }
        public void OnPost(int? id, string? note)
        {
            Models.Shipper sp = new Models.Shipper();
            Models.Order order = new Models.Order();
            Models.Order od = _db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            //od.Note = note;
            _db.Update(od);
            _db.SaveChanges();
            order = GetOrderById(id);
            if (order.ShipperId != null)
            {
                sp = _db.Shippers.Where(x => x.ShipperId == order.ShipperId).FirstOrDefault();

            }
            ViewData["spname"] = sp.Name;
            ViewData["od"] = order;
        }

        public Models.Order GetOrderById(int? id)
        {
            Models.Order order = new Models.Order();
            order = _db.Orders.Include(o => o.Employee).Include(o => o.Customer).Where(o => o.OrderId == id).FirstOrDefault();
            order.OrderDetails = _db.OrderDetails.Where(x => x.OrderId == id).ToList();
            foreach (var o in order.OrderDetails)
            {
                o.Product = _db.Products.FirstOrDefault(p => p.ProductId == o.ProductId);
            }
            return order;
        }
    }
}
