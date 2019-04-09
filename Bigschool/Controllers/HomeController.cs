using Bigschool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Bigschool.ViewModels;
using Microsoft.AspNet.Identity;

namespace Bigschool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCoures = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);

            var userId = User.Identity.GetUserId();
            var fl = _dbContext.Followings
               .Include(c => c.Followee)
               .Where(c => c.FollowerId == userId);

            var att = _dbContext.Attendances
               .Include(c => c.Attendee)
               .Where(c => c.AttendeeId == userId);
            var viewModel = new CoursesViewModel
            {
                attandence = att,
                following = fl,
                UpcomingCourses = upcommingCoures,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Nguyễn Quang Trung - 1611060303";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}