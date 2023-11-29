using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages
{
    public class VoucherModel : PageModel
    {
        private readonly SWP391Context context = new SWP391Context();
        [BindProperty]
        public List<Voucher> voucherList { set; get; }
        public VoucherModel(SWP391Context db)
        {
            this.context = db;
        }
        public void OnGet()
        {
            voucherList = context.Vouchers.ToList();
        }

        public IActionResult OnPost()
        {
            int voucherID = Int32.Parse(Request.Form["voucherID"]);
            string vouchercode = Request.Form["vouchercode"];
            float discount = float.Parse(Request.Form["discount"]);
            DateTime startDate = DateTime.Parse(Request.Form["startDate"]);
            DateTime endDate = DateTime.Parse(Request.Form["endDate"]);
            Voucher voucher = context.Vouchers.FirstOrDefault(n => n.VoucherId == voucherID);
            voucher.ExpDateFrom = startDate;
            voucher.ExpDateTo = endDate;
            voucher.Discount = discount;
            voucher.VoucherCode = vouchercode;
            context.SaveChanges();
            return RedirectToPage();
        }

        public IActionResult OnGetDeleteVoucher(int id)
        {
            
            Voucher voucher = context.Vouchers.FirstOrDefault(n => n.VoucherId == id);
            context.Remove(voucher);
            context.SaveChanges();
            return RedirectToPage();
        }
    }
}
