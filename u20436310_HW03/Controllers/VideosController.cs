using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u20436310_HW03.Models;

namespace u20436310_HW03.Controllers
{
    public class VideosController : Controller
    {
        // GET: Videos
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Videos/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] Files)
        {
            if (ModelState.IsValid)
            {
                foreach (HttpPostedFileBase file in Files)
                {
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Media/Videos/") + InputFileName);
                        file.SaveAs(ServerSavePath);
                        ViewBag.UploadStatus = Files.Count().ToString() + " files uploaded successfully.";
                    }
                }
            }
            return View();
        }
        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Videos/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}