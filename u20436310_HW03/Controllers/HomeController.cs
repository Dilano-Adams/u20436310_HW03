using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u20436310_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string btnchoice, HttpPostedFileBase myfile)
        {
            if (btnchoice == "Document")
            {
                string docName = Path.GetFileName(myfile.FileName);
                string docpath = Path.Combine(Server.MapPath("~/Media/Documents"), docName);

                myfile.SaveAs(docpath);
            }
            if (btnchoice == "Image")
            {
                string picName = Path.GetFileName(myfile.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/Media/Images"), picName);

                myfile.SaveAs(imgpath);
            }
            if (btnchoice == "Video")
            {
                string vidName = Path.GetFileName(myfile.FileName);
                string vidpath = Path.Combine(Server.MapPath("~/Media/Videos"), vidName);

                myfile.SaveAs(vidpath);
            }
            ViewBag.Status = btnchoice + " was uploaded successfully";
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}