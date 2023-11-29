using System;
using System.Collections.Generic;

namespace SE1726_NET_SWP391_Group5.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? EmployeeId { get; set; }
        public int? ShipperId { get; set; }
        public string? CustomerId { get; set; }
        public int? Role { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Emloyee? Employee { get; set; }
        public virtual Shipper? Shipper { get; set; }
    }
}
