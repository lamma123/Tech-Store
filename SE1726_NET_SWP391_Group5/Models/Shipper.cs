﻿namespace SE1726_NET_SWP391_Group5.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Accounts = new HashSet<Account>();
            Orders = new HashSet<Order>();
        }

        public int ShipperId { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
