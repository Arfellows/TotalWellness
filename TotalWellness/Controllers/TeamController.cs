using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalWellness.Data;
using TotalWellness.Models;
using TotalWellness.Services;

namespace TotalWellness.Controllers
{
    public class TeamController : Controller
    {
        

        // GET: Team
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateTeamService();
            var model = service.GetTeams();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreate team)
        {
            if (!ModelState.IsValid)
            {
                return View(team);
            }
            var service = CreateTeamService();

            service.CreateTeam(team);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var service = CreateTeamService();
            var model = service.GetTeamById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateTeamService();
            var detail = service.GetTeamById(id);
            var model =
                new TeamEdit
                {
                    TeamId = detail.TeamId,
                    TeamName = detail.TeamName
                };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeamEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TeamId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateTeamService();

            if (service.UpdateTeam(model))
            {
                TempData["SaveResult"] = "Your team name was updated successfully!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your team name could not be updated.");
            return View(model);
        }



        public ActionResult Delete(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeam(int id)
        {
            var service = CreateTeamService();

            service.DeleteTeam(id);

            TempData["SaveResult"] = "Your team was successfully deleted!";

            return RedirectToAction("Index");
        }

        private TeamService CreateTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamService(userId);
            return service;
        }

    }
}