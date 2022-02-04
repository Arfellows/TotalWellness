using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.ApplicationServices;
using System.Web.Mvc;
using TotalWellness.Models;
using TotalWellness.Services;

namespace TotalWellness.Controllers
{
    public class ProfileController : Controller
    {
        //GET: Profile
       [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);
            var model = service.GetProfiles();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (ProfileCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);

            object p = service.CreateProfile(model);

            return RedirectToAction("Details");
        }

        public ActionResult Details(int id)
        {
            var service = CreateProfileService();
            var model = service.GetProfileById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateProfileService();
            var detail = service.GetProfileById(id);
            var model =
                new ProfileEdit
                {
                    ProfileId = detail.ProfileId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email
                };

            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProfileEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProfileId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateProfileService();

            if (service.UpdateProfile(model))
            {
                TempData["SaveResult"] = "Your profile was updated successfully!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be updated.");
            return View(model);
        }

      
        public ActionResult Delete(int id)
        {
            var svc = CreateProfileService();
            var model = svc.GetProfileById(id);

            return View(model);
        }

       
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProfileService();

            service.DeleteProfile(id);

            TempData["SaveResult"] = "Your profile was successfully deleted!";

            return RedirectToAction("Index");
        }

        

        private ProfileService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);
            return service;
        }
    }
}