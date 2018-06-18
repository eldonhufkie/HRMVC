using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HRMVC.DAL;
using HRMVC.Models;

namespace HRMVC.Controllers
{
    public class HomeController : Controller
    {
        private RecruitContext db = new RecruitContext();

        public ActionResult Index()
        {
            var advert = new Advert();
            ViewBag.Adverts = db.Adverts.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ad = db.Adverts.Find(id);


            return View(ad);
        }

        [HttpPost]
        public ActionResult Edit(Advert ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Advert ad)
        {
            db.Adverts.Add(ad);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Upload(CV cv)
        {
            db.Cvs.Add(cv);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public JsonResult GetAdvertList()
        {
            List<Advert> ad = new List<Advert>();

            ad = db.Adverts.ToList();
            return Json(ad, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AjaxGetList(int? Id)
        {
            var ad = db.Adverts.Find(Id);
            
            return Json(ad, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult Index(HttpPostedFileBase file)
        //{
        //    if (file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads/"), fileName);
        //        file.SaveAs(path);
        //    }
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, int adId)
        {


            byte[] bytes;
            using (BinaryReader br = new BinaryReader(file.InputStream))
            {
                bytes = br.ReadBytes(file.ContentLength);
            }

            db.Cvs.Add(new CV
            {
                PDFFile = bytes
                //,
                //Adverts = db.Adverts.Find(adId)

            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult Index(int? adId)
        //{

        //    var ad = db.Adverts.Find(adId);

        //    return RedirectToAction("Index");
        //}

    }
}