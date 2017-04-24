using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingVisit.Models;

namespace TrainingVisit.Controllers
{
    public class HomeController : Controller
    {
        TraininDbo TrDB = new TraininDbo();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllTrainig()
        {
            return PartialView("Training", TrDB.ListAll());
        }

        public ActionResult EditTrainig(Training training)
        {
            return Json(TrDB.Update(training), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            var Training = TrDB.ListAll().Find(x => x.idTraining.Equals(ID));
            return Json(Training, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int ID)
        {
            return Json(TrDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddTrainig(Training training)
        {
            return Json(TrDB.Add(training), JsonRequestBehavior.AllowGet);
        }

        public ActionResult getbyUser(int id)
        {
            return PartialView("Users", TrDB.ListUserById(id));
        }

        public ActionResult GetLatestTrainings(int id)
        {
            return PartialView("GetLatestTrainings", TrDB.GetLatestTrainings(id));
        }
    }
}