using System;
using System.Collections.Generic;

namespace SE1726_NET_SWP391_Group5.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Voucher { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Voucher VoucherNavigation { get; set; }
    }
}
