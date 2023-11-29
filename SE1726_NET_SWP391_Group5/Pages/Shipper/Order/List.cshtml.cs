using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages.Shipper.Order
{
    public class ListModel : PageModel
    {
        private readonly SWP391Context _db;
        public ListModel(SWP391Context db)
        {
            _db = db;
        }
        public IList<Models.Order> Order { get; set; } = default!;
        public List<Models.Order> orderList { get; set; }

        [BindProperty(SupportsGet = true, Name = "currentPage")]
        public int currentPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? dateFrom { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime? dateTo { get; set; }
        public int totalPages { get; set; }
        public const int pageSize = 10;
        public void OnGet()
        {
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            int totalOrders = getTotalOrders();
            totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);
            orderList = getAllOrders();
            foreach (Models.Order order in orderList)
            {
                Models.Customer cus = _db.Customers.Where(x => x.CustomerId == order.CustomerId).FirstOrDefault();
                Models.Emloyee em = _db.Emloyees.Where(x => x.EmployeeId == order.EmployeeId).FirstOrDefault();
                Models.Shipper ship = _db.Shippers.Where(x => x.ShipperId == order.ShipperId).FirstOrDefault();
                order.Shipper = ship;
                order.Employee = em;
                order.Customer = cus;
            }

        }
        private int getTotalOrders()
        {
            var list = from order in _db.Orders orderby order.OrderDate ascending select order;
            if (dateFrom == null || dateTo == null
               || (dateFrom == null && dateTo == null))
            {
                return list.Count();
            }
            else if (dateFrom > dateTo)
            {
                TempData["msg"] = "Date From must be greater than Date To";
                return list.Count();
            }
            else
            {

                return list.Where(o => DateTime.Compare(o.OrderDate.Value, dateFrom.Value) >= 0
                        && DateTime.Compare(o.OrderDate.Value, dateTo.Value) <= 0).ToList().Count();
            }
        }

        private List<Models.Order> getAllOrders()
        {

            List<Models.Order> orders;
            if (dateFrom == null || dateTo == null
                || (dateFrom == null && dateTo == null))
            {
                orders = _db.Orders.Where(X => X.Status == 2).Skip((currentPage - 1) * pageSize).Take(pageSize)
                            .OrderByDescending(c => c.OrderDate).ToList();
            }
            else
            {
                orders = _db.Orders.Where(o => DateTime.Compare(o.OrderDate.Value, dateFrom.Value) >= 0
                    && DateTime.Compare(o.OrderDate.Value, dateTo.Value) <= 0 && o.Status == 2)
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize).ToList();
            }
            return orders;
        }
    }
}
