using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages.PostController
{
    public class PostModel : PageModel
    {
        private readonly SWP391Context context;

        public PostModel(SWP391Context db)
        {
            context = db;
        }
        [BindProperty]
        public List<Post> Posts { get; set; }
        // Số bài viết trên mỗi trang
        /*public int PageSize { get; set; } = 10;

        public int TotalPages { get; set; }
        public int PageIndex { get; set; } = 1;
        */
        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy danh sách bài viết từ cơ sở dữ liệu
            //Posts = context.Posts.ToList();
            Posts = context.Posts.Where(p => p.EmployeeId != null && p.EmployeeId != 0).ToList();
            return Page();
        }
    }

}