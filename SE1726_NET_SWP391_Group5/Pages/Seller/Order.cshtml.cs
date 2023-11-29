using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Cookies;
using SE1726_NET_SWP391_Group5.Models;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace SE1726_NET_SWP391_Group5.Pages.Seller
{
    public class OrderModel : PageModel
    {
        private readonly SWP391Context context;
        public List<Models.Order> Orders { get; set; }
        public List<Models.Account> Accounts { get; set; }

        public OrderModel(SWP391Context context)
        {
            this.context = context;
        }


        public async Task<IActionResult> OnGetAsync(int? SelectedId)
        {
            if (HttpContext.Session.GetString("seller") == null)
            {
                return RedirectToPage("/Account/Login");
            }

            string Status;
            if (SelectedId != 2 && SelectedId != 6)
            {
                Orders = await context.Orders.Include(e => e.Customer).Include(e => e.Employee).Include(e => e.Shipper).Where(e => e.Status == 1).ToListAsync();
            }
            else
            {
                Orders = await context.Orders.Include(e => e.Customer).Include(e => e.Employee).Include(e => e.Shipper).Where(e => e.Status == SelectedId).ToListAsync();
            }

            if (SelectedId == 1)
            {
                Status = "Pending";
            }
            else if (SelectedId == 6)
            {
                Status = "Cancel";
            }
            else
            {
                Status = "Done";
            }
            TempData["SelectedId"] = SelectedId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int orderId, int newStatus, int status)
        {
            Orders = await context.Orders.Include(e => e.Customer).Include(e => e.Employee).Include(e => e.Shipper).Where(e => e.Status == 1).ToListAsync();
            string toEmail = "";
            string CusId = "";
            Accounts = await context.Accounts.ToListAsync();
            foreach (var o in Orders)
            {
                if (o.OrderId == orderId)
                {
                    CusId = o.CustomerId;
                    break;
                }
            }
            foreach (var a in Accounts)
            {
                if (a.CustomerId == CusId)
                {
                    toEmail = a.Email;
                }
            }
            if (ModelState.IsValid)
            {
                var od = await context.Orders.FindAsync(orderId);
                od.Status = newStatus;
                od.AcceptedDate = DateTime.Now;
                // Trong trang mục tiêu
                var customerInfoJson = HttpContext.Session.GetString("seller"); // Lấy giá trị từ session

                if (!string.IsNullOrEmpty(customerInfoJson))
                {
                    var sellerInfo = JsonSerializer.Deserialize<Models.Account>(customerInfoJson); // Chuyển đổi từ JSON về đối tượng

                    od.EmployeeId = sellerInfo.EmployeeId; // Lấy giá trị EmployeeId
                                                           // Bây giờ bạn có thể sử dụng biến "employeeId" trong trang của bạn.
                }
                await context.SaveChangesAsync();
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("hlongriot2301@gmail.com");
                    mail.To.Add(new MailAddress(toEmail));
                    if (newStatus == 2)
                    {
                        mail.Subject = "Thông báo kết quả xử lý đơn hàng";
                        mail.Body = "Xin chào quý khách\n"
                            + "Lời đầu tiên xin chân thành cảm ơn bạn đã đặt hàng từ chúng tôi. Chúng tôi xin thông báo rằng đơn hàng của bạn đã được chấp nhận và đang được tiến hành xử lý.\n\n"
                            + "Chúng tôi sẽ thông báo cho bạn về trạng thái và thông tin vận chuyển cụ thể trong thời gian sớm nhất. Nếu bạn có bất kỳ câu hỏi hoặc yêu cầu bổ sung, vui lòng liên hệ với chúng tôi qua email này.\n\n"
                            + "Chúng tôi rất mong được phục vụ bạn một cách tốt nhất.\n\n"
                            + "Trân trọng,\n"
                            + "Nhân viên bán hàng"
                            ;
                    }
                    else if (newStatus == 6)
                    {
                        mail.Subject = "Thông báo kết quả xử lý đơn hàng";
                        mail.Body = "Xin chào quý khách\n"
                            + "Lời đầu tiên xin chân thành cảm ơn bạn đã đặt hàng từ chúng tôi. Chúng tôi rất tiếc vì phải thông báo nhưng vì 1 số lý do mà đơn hàng của bạn đã bị từ chối.\n\n"
                            + "Chúng tôi rất lấy làm tiếc và mong bạn sẽ tiếp tục ủng hộ chúng tôi trong thời gian tới.\n"
                            + "Để biết thêm tri tiết xin liên hệ với chúng tôi qua email này. Chúng tôi sẽ giải đáp mọi thắc mắc của bạn.\n"
                            + "Trân trọng,\n"
                            + "Nhân viên bán hàng"
                            ;
                    }
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential("hlongriot2301@gmail.com", "ghbwbjrdgdafzgar");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                TempData["SelectedId"] = status;
                Orders = await context.Orders.Include(e => e.Customer).Include(e => e.Employee).Include(e => e.Shipper).Where(e => e.Status == 1).ToListAsync();
                return Page();
            }
            else
            {
                return Page();
            }

        }
    }
}