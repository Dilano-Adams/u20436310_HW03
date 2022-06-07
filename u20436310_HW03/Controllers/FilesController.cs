using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace u20436310_HW03.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] Files)
        {
            //Ensure model state is valid
            if (ModelState.IsValid)
            {   //iterating through multiple file collection
                foreach (HttpPostedFileBase file in Files)
                {
                    //Checking file is available to save.
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Media/Documents/") + InputFileName);
                        //Save file to server folder
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.
                        ViewBag.UploadStatus = Files.Count().ToString() + " files uploaded successfully.";
                    }
                }
            }
            return View();
        }
    }
}