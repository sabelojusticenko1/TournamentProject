using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tournaments.DAL;
using Tournaments.Models;

namespace Tournaments.Controllers
{
    [Authorize]
    public class TournamentController : Controller
    {
        private RepositoryWrapper repositorywrapper;

        private static AppDbContext DbContext = new AppDbContext();

        public TournamentController() : this(new RepositoryWrapper(DbContext)) { }
        public TournamentController(RepositoryWrapper _repository) => repositorywrapper = _repository;

        // GET: Tournament
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(repositorywrapper.Tournament.FindAll());
        }

        // GET: Tournament/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tournament/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tournament/Create
        [HttpPost]
        public ActionResult Create(Tournament tournament)
        {
            try
            {
                // TODO: Add insert logic here
                repositorywrapper.Tournament.Create(tournament);
                repositorywrapper.Tournament.Save();

                TempData["AlertMessage"] = "Tournament created succesfully";

                return RedirectToAction("Index");
            }
            catch
            {
                //Need to do some work here
                return View();
            }
        }

        // GET: Tournament/Edit/5
        public ActionResult Edit(int id)
        {
            Tournament tournament = repositorywrapper.Tournament.GetById(id);
            return View(tournament);
        }

        // POST: Tournament/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "TournamentID, TournamentName")]Tournament tournament)
        {

            Tournament tour = repositorywrapper.Tournament.GetById((int)tournament.TournamentID);
            tour.TournamentName = tournament.TournamentName;

            repositorywrapper.Tournament.Save();
            TempData["AlertMessageUpdated"] = "Tournament succesfully updated";
            return RedirectToAction("Index");



            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        repositorywrapper.Tournament.Update(tournament);
            //        repositorywrapper.Tournament.Save();
            //        TempData["AlertMessageUpdated"] = "Tournament succesfully updated";
            //        return RedirectToAction("Index");

            //    }
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch (DataException)
            //{
            //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");

            //}

            //return View(tournament);
        }

        // GET: Tournament/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Tournament tournament = repositorywrapper.Tournament.GetById((int)id);
            

            
            return View(tournament);
            
        }

        // POST: Tournament/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int iDel2) 
        {

            try
            {



                DAL_StoredProcedure dAL_StoredProcedure = new DAL_StoredProcedure();
                List<Event> _events =repositorywrapper.Event.FindByCondition(x => x.TournamentID == iDel2).ToList();

                dAL_StoredProcedure.DeleteFromTournament(iDel2, _events);

                //foreach (var _event in _events)
                //{
                //    dAL_StoredProcedure.DeleteFromTournament(iDel2, _event.EventID);
                //};





                //Tournament tournament = repositorywrapper.Tournament.GetById(iDel2);
                //repositorywrapper.Tournament.Delete(tournament);
                //repositorywrapper.Tournament.Save();
              
                TempData["AlertMessageDel"] = "Tournament delete succesfully";
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary {
                     { "id", iDel2 },
                     { "saveChangesError", true } });

            }
            return RedirectToAction("Index", "Tournament");

        }
    }
}
