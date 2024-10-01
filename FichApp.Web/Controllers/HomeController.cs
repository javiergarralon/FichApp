using FichApp.DataAccess.Repository.IRepository;
using FichApp.Models.Models;
using FichApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace FichApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            Timesheet? todayTimesheets = _unitOfWork.TimesheetRepository.GetAll().Where(x => x.Checkin.HasValue && x.Checkin.Value.Date == DateTime.Today).LastOrDefault();
            return View(todayTimesheets);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckIn(string lastTimeSpent)
        {
            Timesheet timesheet = new Timesheet() { Checkin = DateTime.Now, Checkout = null, TimeSpent = lastTimeSpent != null ? TimeSpan.Parse(lastTimeSpent) : null };
            _unitOfWork.TimesheetRepository.Add(timesheet);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Check-in successful!" });
        }

        [HttpPost]
        public JsonResult CheckOut(string lastTimeSpent, string checkIn)
        {
            Timesheet timesheet = new Timesheet() { Checkin = DateTime.Parse(checkIn), Checkout = DateTime.Now, TimeSpent = calculateTimeSpent(lastTimeSpent, checkIn) };
            _unitOfWork.TimesheetRepository.Add(timesheet);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Check-out successful!" });
        }

        private TimeSpan? calculateTimeSpent(string lastTimeSpent, string checkIn)
        {
            return lastTimeSpent.IsNullOrEmpty() ? DateTime.Now - DateTime.Parse(checkIn) : DateTime.Now - DateTime.Parse(checkIn) + TimeSpan.Parse(lastTimeSpent);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
