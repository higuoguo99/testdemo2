using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XinguanSys.Models;

namespace XinguanSys.Controllers
{
    public class ReportDetailsController : Controller
    {
        private xinguanEntities db = new xinguanEntities();


        public ActionResult Index()
        {
            int id = 1;
            ReportDetails reportDetails = db.ReportDetails.Find(id);
            return View(reportDetails);
        }
        [HttpPost]
        public ActionResult Show(string tiaojian)
        {
            int id = db.ReportDetails.FirstOrDefault(r => r.AreaName.Contains(tiaojian)).AreaID;
            ReportDetails model = db.ReportDetails.Find(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }



      
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Create( ReportDetails reportDetails,HttpPostedFileBase Image)
        {
            reportDetails.Image = Image.FileName;
            string path = "~/images/" + Image.FileName;
            Image.SaveAs(Server.MapPath(path));
           
                db.ReportDetails.Add(reportDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }

    }
}
