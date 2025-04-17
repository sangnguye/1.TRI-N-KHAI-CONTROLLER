using Microsoft.AspNetCore.Mvc;

namespace _1.TRIỂN_KHAI_CONTROLLER.Controllers
{
    public class StudentController : Controller
    {
        [Route("HomeStudent")]// định danh Action ListAll bằng HomeStudent
        [Route("Student")]
        [Route("Student/ListAll")]
        [Route("Liet-ke-danh-sach-sinh-vien")]

        public string ListAll()
        {
            return "Liệt kê danh sách sinh viên";
        }

        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "Welcom to Student page",
                ContentType = "text/plain",
            };
        }

        [Route("File/download-file")]

        public FileResult DownloadFile()
        {
            return File("/Linq.pdf", "application/pdf");
        }

        [Route("Student/List")]

        public IActionResult ListOnlyStudent()
        {
            if (!Request.Query.ContainsKey("id"))
            {
                return BadRequest("Student ID is not Provided");
            }
            
            int id = Convert.ToInt32(Request.Query["id"]);
            if (id < 1 || id > 1000)
            {
                return NotFound("Student ID not match");
            }
            return Content("Thong tin sinh vien:" + id, "text/html");
        }

        public string ListOnlyOne(int id)
        {
            return "Liệt kê một sinh viên có id cụ thể";
        }

        public string EditStudent()
        {
            return "Chỉnh sửa thông tin một sinh viên có id cụ thể";
        }

        public string AddStudent()
        {
            return "Thêm thông tin một sinh viên";
        }

        public string DelStudent()
        {
            return "Xóa thông tin một sinh viên";
        }

        [Route("Edit-Student")]

        public IActionResult EditStudent1()
        {
            //return RedirectToAction("Index","Home");//chuyển hướng về Controller = Home, Action = Index
            return LocalRedirect("~/Home/Index");
        }

        public IActionResult ListOnlyStudent([FromQuery] int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("Student ID is not provided");
            }
            return Content($"Thong tin sinh vien {id}");
        }
    }
}
