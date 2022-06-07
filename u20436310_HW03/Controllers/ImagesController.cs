using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u20436310_HW03.Models;

namespace u20436310_HW03.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            string[] filePath = Directory.GetFiles(Server.MapPath("~/Media/Images"));
            List<FileModel> files = new List<FileModel>();
            foreach(string filePaths in filePath)
            {
                Files.Add(new FileModel { FileName = Path.GetFileName(filePaths) });
            }
            return View(files);
        }
    }
}