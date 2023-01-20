using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OlmosBartending.com.Models;
using OlmosBartending.com.Services;
//using OlmosBartending.com.Services;

namespace OlmosBartending.com.Controllers
{
    public class AppointmentController : Controller
    {
        private ICRUD iCRUD;
        public AppointmentController(ICRUD iCRUD)
        {
            this.iCRUD = iCRUD;
        }
        // GET: BookingController
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.AppointmentList = iCRUD.GetAppointmentList();
            return View(model);
        }

        // GET: BookingController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }
        //[HttpPost]
        //[Authorize(Roles ="admin, sierx, client")]
        public IActionResult Create()
        {
            var newAppt = new Appointment();
            newAppt.EventId=iCRUD.GetMaxId();
            return View(newAppt);
        }

        // POST: BookingController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Appointment appointment)
        {
            if(ModelState.IsValid)
            {
                iCRUD.AddAppointment(appointment);
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Error adding appointment. Please try again?";
            return View(appointment);
        }

        // GET: BookingController/Edit/5
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
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
