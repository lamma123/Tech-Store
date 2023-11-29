using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages.PostController
{
    public class EditPostModel : PageModel
    {
        private readonly SWP391Context context;
        public SE1726_NET_SWP391_Group5.Models.Post post { get; set; }

        public EditPostModel(SWP391Context db)
        {
            context = db;
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await context.Posts.FindAsync(id);

            if (Post == null)
            {
                return NotFound();
            }
            
            return Page();
            
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (HttpContext.Session.GetString("marketing") != null)
            {
                if (id == null)
                    return Page();
                var post = await context.Posts.FindAsync(id);
                if (post == null)
                    return BadRequest();

                post.PostTitle = Post.PostTitle;
                post.PostContent = Post.PostContent;
                post.EmployeeId = Post.EmployeeId;
                post.PublishedDate = Post.PublishedDate;
                

                await context.SaveChangesAsync();
                //return Redirect("Detail?pid=" + id);

            }
            return RedirectToPage("/MarketingStaff/PostController/Post");
        }
        /*public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (HttpContext.Session.GetString("admin") != null)
            {
                if (id == null)
                    return Page();
                var post = await context.Posts.FindAsync(id);
                if (post == null)
                    return BadRequest();

                if (string.IsNullOrEmpty(Post.PostTitle))
                {
                    ModelState.AddModelError("Post.PostTitle", "Tiêu đề không được để trống.");
                }

                if (string.IsNullOrEmpty(Post.PostContent))
                {
                    ModelState.AddModelError("Post.PostContent", "Nội dung không được để trống.");
                }
                else if (Post.PostContent.Length > 200)
                {
                    ModelState.AddModelError("Post.PostContent", "Độ dài nội dung đã đạt giới hạn (200 ký tự).");
                }

                if (Post.PublishedDate == null)
                {
                    ModelState.AddModelError("Post.PublishedDate", "Vui lòng chọn ngày đăng.");
                }

                if (Post.EmployeeId == null)
                {
                    ModelState.AddModelError("Post.EmployeeId", "Employee ID không được để trống.");
                }
                else
                {
                    // Kiểm tra xem EmployeeId có tồn tại trong cơ sở dữ liệu không
                    var employee = await context.Posts.FindAsync(Post.EmployeeId);
                    if (employee == null)
                    {
                        ModelState.AddModelError("Post.EmployeeId", "Employee ID không hợp lệ.");
                    }
                }

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                post.PostTitle = Post.PostTitle;
                post.PostContent = Post.PostContent;
                post.EmployeeId = Post.EmployeeId;
                post.PublishedDate = Post.PublishedDate;
                post.Description = Post.Description;

                await context.SaveChangesAsync();

                // Redirect đến trang chi tiết (Detail) sau khi chỉnh sửa xong.
                return RedirectToPage("Detail", new { id = id });
            }
            return RedirectToPage("/PostController/Post");
        }*/
    }
}

