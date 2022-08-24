using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tournaments.DAL;
using Tournaments.Models;
using Tournaments.ViewModels;

namespace Tournaments.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private RepositoryWrapper repositorywrapper;

        private static AppDbContext DbContext = new AppDbContext();
        public EventController() : this(new RepositoryWrapper(DbContext)) { }

        public EventController(RepositoryWrapper _repository) => repositorywrapper = _repository;


        [AllowAnonymous]
        // GET: Event
        public ActionResult List(int id)
        {
            
            //Tournament tName =  repositorywrapper.Tournament.GetById(id);
            //ViewBag.Title = tName.TournamentName ;

            //return View(repositorywrapper.Event.FindByCondition(p => p.TournamentID == (long)id).OrderBy(p => p.EventID).ToList());

            //try
            //{

            EventDetailsViewModel edVM = new EventDetailsViewModel()
            {
                Tournament = repositorywrapper.Tournament.GetById(id),
                Event = repositorywrapper.Event.FindByCondition(p => p.TournamentID == (long)id).OrderBy(p => p.EventID)
                


            };

            

            return View(edVM);

            //);


            //}
            //catch (Exception)
            //{
            //    //need to fix
            //    return View();
            //}
            //return View();
        }

        [AllowAnonymous]
        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            EventEventDetailsViewModel _eedVM = new EventEventDetailsViewModel()
            {
                //model for Event details much like th model for Tournament events
                Event = repositorywrapper.Event.GetById(id),
                EventDetail = repositorywrapper.EventDetail.FindByCondition(p => p.EventID == id),
                EventDetailStatus = repositorywrapper.EventDetailStatus.FindAll(),

                
            };
            

            return View(_eedVM);
        }

        
        // GET: Event/Create
        public ActionResult Create(int id)
        {
            EventTourIDViewModel etVM = new EventTourIDViewModel()
            {
                Tournament = repositorywrapper.Tournament.GetById(id)

            };

            return View(etVM);
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventTourIDViewModel _etVM, int id)
        {
            try
            {
                _etVM.Event.TournamentID = id;
                repositorywrapper.Event.Create(_etVM.Event);
                repositorywrapper.Event.Save();
                TempData["AlertMessage"] = "Event created succesfully";
                // TODO: Add insert logic here

                return RedirectToAction("List", new { id = id  });
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            

            return View(repositorywrapper.Event.GetById(id));
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Event _event)
        {
            try
            {
                repositorywrapper.Event.Update(_event);
               
                repositorywrapper.Event.Save();

                TempData["AlertMessage"] = "Event updated succesfully";
                // TODO: Add update logic here

                return RedirectToAction("List", new { id = _event.TournamentID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
              Event _event = repositorywrapper.Event.GetById(id);

            

            return View(_event);
        }

        // POST: Event/Delete/5
      
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection collection)
        {
            Event _event = repositorywrapper.Event.GetById(id);

            try
            {

                DAL_StoredProcedure dAL_StoredProcedure = new DAL_StoredProcedure();
                List<EventDetail> _eventDetail = repositorywrapper.EventDetail.FindByCondition(x => x.EventID == id).ToList();
                dAL_StoredProcedure.DeleteFromEvent(id);



                TempData["AlertMessageDel"] = "Event delete succesfully";

            }
            catch
            {
                return View();
            }
            return RedirectToAction("List", "Event", new { id = _event.TournamentID});
        }

       









    }
    }

