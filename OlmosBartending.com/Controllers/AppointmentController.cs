using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using OlmosBartending.com.Models;
using OlmosBartending.com.Services;
using OlmosBartending.com.ViewModels;
//using OlmosBartending.com.Services;

namespace OlmosBartending.com.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ICaptchaValidator _captchaValidator;
        private ICRUD iCRUD;
        public AppointmentController(ICRUD iCRUD, ICaptchaValidator captchaValidator)
        {
            this.iCRUD = iCRUD;
            this._captchaValidator = captchaValidator;
        }
        //[Authorize(Roles = "ADMIN, admin, aDMIN, Admin, webadmin")]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.AppointmentList = iCRUD.GetAppointmentList();
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Details(int id)
        {
            var apptDetails = iCRUD.GetAppointment(id);
            if(apptDetails == null)
            {
                return NotFound();
            }
            return View(apptDetails);
        }
        //This retrieves the Create view, enabling the Create method below to see the
        //max ID. 
        [HttpGet]
        public IActionResult Create()
        {
            var newAppt = new Appointment();
            newAppt.EventId=iCRUD.GetMaxId();
            return View(newAppt);
        }

        // POST: BookingController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                iCRUD.AddAppointment(appointment);
                ViewBag.Alert = "Success!";
                ViewBag.Message = "Success!";
                return RedirectToRoute(new { Action="Index", Controller="Home"});
            }
            ViewBag.Message = "Error adding appointment. Please try again?";
            return View(appointment);
        }

        //[HttpPost]
        //public IActionResult Create(Appointment appointment, CaptchaViewModel captchaView)
        //{
        //    if (!await _captchaValidator.IsCaptchaPassedAsync(Index.Captcha))
        //    {
        //        return View();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        iCRUD.AddAppointment(appointment);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Message = "Error adding appointment. Please try again?";
        //    return View(appointment);
        //}

        // GET: BookingController/Edit/5
        [Authorize(Roles ="admin")]
        public IActionResult Edit(int id)
        {
            var apptToEdit = iCRUD.GetAppointment(id);
            return View(apptToEdit);
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Appointment appt)
        {
            if(ModelState.IsValid)
            {
                iCRUD.UpdateAppointment(appt);
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Error editing appointment.";
            return View(appt);
        }
        // GET: BookingController/Delete/5
        [HttpGet]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles ="admin")]
        public IActionResult Delete(int id)
        {
            iCRUD.DeleteAppointment(id);
            //ViewBag.Message = "Appointment deleted. Returning to index...";
            return RedirectToAction("Index");
        }
    }
}
