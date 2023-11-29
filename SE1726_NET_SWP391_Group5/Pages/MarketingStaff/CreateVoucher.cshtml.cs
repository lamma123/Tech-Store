using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages
{
    public class CreateVoucherModel : PageModel
    {
        private readonly SWP391Context context = new SWP391Context();
        public CreateVoucherModel(SWP391Context db)
        {
            this.context = db;
        }
        public IActionResult OnPost()
        {
            string vouchercode = Request.Form["vouchercode"];
            float discount = float.Parse(Request.Form["discount"]);
            DateTime startDate = DateTime.Parse(Request.Form["startDate"]);
            DateTime endDate = DateTime.Parse(Request.Form["endDate"]);
            Voucher voucher = new Voucher()
            {
                Discount = discount,
                VoucherCode = vouchercode,
                ExpDateFrom = startDate,
                ExpDateTo = endDate,
            };
            context.Vouchers.Add(voucher);
            context.SaveChanges();
            return RedirectToPage("Voucher");
        }
    }
}
