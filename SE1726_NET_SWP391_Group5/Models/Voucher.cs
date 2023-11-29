using System;
using System.Collections.Generic;

namespace SE1726_NET_SWP391_Group5.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public float? Discount { get; set; }
        public DateTime? ExpDateFrom { get; set; }
        public DateTime? ExpDateTo { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
