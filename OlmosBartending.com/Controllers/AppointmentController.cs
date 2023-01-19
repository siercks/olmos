using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
