using System.Linq;
using Microsoft.AspNetCore.Mvc;
using recruitment.Models;

namespace recruitment.Controllers
{
    public class CandidateController : Controller
    {
        private TuyenCTVContext db = new TuyenCTVContext();

        // Trang chủ hiển thị tất cả công việc
        public ActionResult Index(string keyword, string location)
        {
            var jobs = db.Jobs.Where(j => j.Status == "Active");

            // Lọc theo từ khóa và địa điểm nếu có
            if (!string.IsNullOrEmpty(keyword))
                jobs = jobs.Where(j => j.Title.Contains(keyword) || j.Description.Contains(keyword));

            if (!string.IsNullOrEmpty(location))
                jobs = jobs.Where(j => j.Location.Contains(location));

            // Chuyển danh sách công việc vào View
            return View(jobs.ToList());
        }
    }
}
