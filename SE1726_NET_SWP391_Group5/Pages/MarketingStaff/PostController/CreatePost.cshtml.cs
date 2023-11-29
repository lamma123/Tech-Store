using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;
using System.Threading.Tasks;

namespace SE1726_NET_SWP391_Group5.Pages.PostController
{
    public class CreatePostModel : PageModel
    {
        private readonly SWP391Context context;

        public CreatePostModel(SWP391Context db)
        {
            context = db;
        }

        [BindProperty]
        public Post Post { get; set; }

        public void OnGet()
        {
            // Không cần thực hiện gì cả khi trang được tải lần đầu.
        }

        /*public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("admin") != null)
            {

                if (string.IsNullOrEmpty(Post.PostTitle))
                {
                    ModelState.AddModelError("Post.PostTitle", "Vui lòng điền vào trường này.");
                }

                if (string.IsNullOrEmpty(Post.PostContent))
                {
                    ModelState.AddModelError("Post.PostContent", "Vui lòng điền vào trường này.");
                }
                // Kiểm tra độ dài của PostContent
                else if (Post.PostContent.Length > 200)
                {
                    ModelState.AddModelError("Post.PostContent", "Độ dài nội dung đã đạt giới hạn (200 ký tự).");
                }
                if (Post.PublishedDate == default(DateTime))
                {
                    ModelState.AddModelError("Post.PublishedDate", "Vui lòng chọn ngày đăng.");
                }

                /*if (Post.EmployeeId == null || Post.EmployeeId <= 0)
                {
                    ModelState.AddModelError("Post.EmployeeId", "Vui lòng điền vào trường này.");
                }*/
        /*else
        {
            // Kiểm tra xem EmployeeId có tồn tại trong cơ sở dữ liệu không
            var employee = await context.Emloyees.FindAsync(Post.EmployeeId);
            if (employee == null)
            {
                ModelState.AddModelError("Post.EmployeeId", "Employee ID không tồn tại trong cơ sở dữ liệu.");
            }
        }
        */

        /*if (!ModelState.IsValid)
        {
            return Page();
        }*/

        // Thêm bài viết mới vào cơ sở dữ liệu



        /* context.Posts.Add(Post);
         await context.SaveChangesAsync();

         return RedirectToPage("/PostController/Post");
     }

 return Page();
}*/

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("marketing") != null)
            {
                // Kiểm tra độ dài của PostContent
                if (!string.IsNullOrEmpty(Post.PostContent) && Post.PostContent.Length > 200)
                {
                    ModelState.AddModelError("Post.PostContent", "Độ dài nội dung đã đạt giới hạn (200 ký tự).");
                    return Page();
                }

                // Thêm bài viết mới vào cơ sở dữ liệu
                context.Posts.Add(Post);
                await context.SaveChangesAsync();

                return RedirectToPage("/MarketingStaff/PostController/Post");
            }

            return Page();
        }
    }
}