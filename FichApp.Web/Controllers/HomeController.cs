using FichApp.DataAccess.Repository.IRepository;
using FichApp.Models.Models;
using FichApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult CheckIn() {
            Timesheet timesheet = new Timesheet() { Checkin = DateTime.Now, Checkout = DateTime.Now, TimeSpent = new TimeSpan(0, 0, 0) };
            _unitOfWork.TimesheetRepository.Add(timesheet);
            _unitOfWork.Save();
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult CheckOut()
        {
            Timesheet timesheet = new Timesheet() { Checkin = DateTime.Now, Checkout = DateTime.Now, TimeSpent = new TimeSpan(0, 0, 0) };
            _unitOfWork.TimesheetRepository.Add(timesheet);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
