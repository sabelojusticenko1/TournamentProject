using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tournaments.DAL;
using Tournaments.Models;
using Tournaments.ViewModels;

namespace Tournaments.Controllers
{
    [Authorize]
    public class EventDetailController : Controller
    {

        private RepositoryWrapper repositorywrapper;

        private static AppDbContext DbContext = new AppDbContext();

        public EventDetailController() : this(new RepositoryWrapper(DbContext)) { }

        public EventDetailController(RepositoryWrapper _repository) => repositorywrapper = _repository;


        // GET: EventDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventDetail/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventDetail/Create
        public ActionResult Create(int id)
        {

            EventDetailCreateViewModel edcViewModel = new EventDetailCreateViewModel()
            {
                Event = repositorywrapper.Event.GetById(id),
                EventDetailStatus = repositorywrapper.EventDetailStatus.FindAll().ToList()
                
            };

            //var edsList = new List<EventDetailStatus>();

            //IEnumerable<EventDetailStatus> edsALL = repositorywrapper.EventDetailStatus.FindAll().ToList();

            //edsList.AddRange(edsALL.Select(p => new SelectListItem
            //{
            //    Value = p.EventDetailStatusID.ToString()

            //    Text = p.EventDetailStatusName

            //})) ;
            //ViewBag.StatusList = new SelectList(edsList);

            ViewBag.Title = "Create Event Detail";
            ViewBag.StatusList = new SelectList(repositorywrapper.EventDetailStatus.FindAll().ToList(), "EventDetailStatusID", "EventDetailStatusName");


            return View(edcViewModel);
        }

        // POST: EventDetail/Create
        [HttpPost]
        public ActionResult Create(EventDetailCreateViewModel edcViewModel)
        {
            try
            {
                edcViewModel.EventDetail.EventID = edcViewModel.Event.EventID;
                repositorywrapper.EventDetail.Create(edcViewModel.EventDetail);
                repositorywrapper.EventDetail.Save();

                TempData["AlertMessage"] = "Event detail created succesfully";
                // TODO: Add insert logic here

                EventEventDetailsViewModel _eedVM = new EventEventDetailsViewModel()
                {
                    //model for Event details much like th model for Tournament events
                    Event = repositorywrapper.Event.GetById((int)edcViewModel.Event.EventID),
                    EventDetail = repositorywrapper.EventDetail.FindByCondition(p => p.EventID == (int)edcViewModel.Event.EventID),
                    EventDetailStatus = repositorywrapper.EventDetailStatus.FindAll(),


                };

                return View("../Event/Details", _eedVM);
                //return RedirectToAction("Details", "Event", new { id = edcViewModel.Event.TournamentID } );
            }
            catch
            {
                return View();
            }
        }

        // GET: EventDetail/Edit/5
        public ActionResult Edit(int id, int id2)
        {


            EventDetailCreateViewModel edcViewModel = new EventDetailCreateViewModel()
            {
                Event = repositorywrapper.Event.GetById(id),
                EventDetail = repositorywrapper.EventDetail.GetById(id2),
                EventDetailStatus = repositorywrapper.EventDetailStatus.FindAll().ToList()
            };

            ViewBag.Title = "Edit Event Detail";
            ViewBag.StatusList = new SelectList(repositorywrapper.EventDetailStatus.FindAll().ToList(), "EventDetailStatusID", "EventDetailStatusName");

            return View(edcViewModel);
        }

        // POST: EventDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventDetailCreateViewModel edcViewModel)
        {
            //try
            //{
                edcViewModel.EventDetail.EventID = edcViewModel.Event.EventID;
                EventDetail edToBeUpdated = edcViewModel.EventDetail;
                repositorywrapper.EventDetail.Update(edToBeUpdated);
                repositorywrapper.EventDetail.Save();

                TempData["AlertMessage"] = "Event detail updated succesfully";

                EventEventDetailsViewModel _eedVM = new EventEventDetailsViewModel()
                {
                    //model for Event details much like th model for Tournament events
                    Event = repositorywrapper.Event.GetById((int)edcViewModel.Event.EventID),
                    EventDetail = repositorywrapper.EventDetail.FindByCondition(p => p.EventID == (int)edcViewModel.Event.EventID),
                    EventDetailStatus = repositorywrapper.EventDetailStatus.FindAll(),


                };

                return View("../Event/Details", _eedVM);
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: EventDetail/Delete/5
        public ActionResult Delete(int id)
        {
            

            return View(repositorywrapper.EventDetail.GetById(id));
        }

        // POST: EventDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, EventDetail eventDetail)
        {
            try
            {
                repositorywrapper.EventDetail.Delete(repositorywrapper.EventDetail.GetById(id));
                repositorywrapper.EventDetail.Save();
                TempData["AlertMessageDel"] = "Event detail deleted succesfully";


                EventEventDetailsViewModel _eedVM = new EventEventDetailsViewModel()
                {
                    //model for Event details much like th model for Tournament events
                    Event = repositorywrapper.Event.GetById((int)eventDetail.EventID),
                    EventDetail = repositorywrapper.EventDetail.FindByCondition(p => p.EventID == (int)eventDetail.EventID),
                    EventDetailStatus = repositorywrapper.EventDetailStatus.FindAll(),


                };


                // TODO: Add delete logic here

                return View("../Event/Details", _eedVM);
            }
            catch
            {
                return View();
            }

           
        }
    }
}
