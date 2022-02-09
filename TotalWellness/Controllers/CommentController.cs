﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalWellness.Models;
using TotalWellness.Services;

namespace TotalWellness.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        [Authorize]
        public ActionResult Index()
        {
            var service = new CommentService();
            var model = service.GetComments();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }
            var service = new CommentService();

            service.CreateComment(comment);

            return RedirectToAction("Details");
        }

        public ActionResult Details(int id)
        {
            var service = CreateCommentService();
            var model = service.GetCommentById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateCommentService();
            var detail = service.GetCommentById(id);
            var model =
                new CommentEdit
                {
                    CommentId = detail.CommentId,
                    Message = detail.Message
                };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CommentId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateCommentService();

            if (service.UpdateComment(model))
            {
                TempData["SaveResult"] = "Your comment was updated successfully!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your comment could not be updated.");
            return View(model);
        }



        public ActionResult Delete(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentById(id);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id)
        {
            var service = CreateCommentService();

            service.DeleteComment(id);

            TempData["SaveResult"] = "Your comment was successfully deleted!";

            return RedirectToAction("Index");
        }

        private CommentService CreateCommentService()
        {
            var service = new CommentService();
            return service;
        }
    }
}