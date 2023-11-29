using System;
using System.Collections.Generic;

namespace SE1726_NET_SWP391_Group5.Models
{
    public partial class Post
    {
        public int? PostId { get; set; }
        public string? PostTitle { get; set; }
        public string? PostContent { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? PublishedDate { get; set; }

        public virtual Emloyee Employee { get; set; }
    }
}
