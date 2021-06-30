using Bookmanagement.Core.FilesEntity;
using Bookmanagement.Core.IService;
using Bookmanagement.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filesmanagement.Controllers
{
    public class FilesController : Controller
    {
        private readonly IServiceFiles _files;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FilesController(IServiceFiles serviceFiles, IWebHostEnvironment hostEnvironment)
        {
            _files = serviceFiles;
            _hostEnvironment = hostEnvironment;
        }
        public ActionResult Files()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FilesUpload(Filesentity myfiles)
        {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(myfiles.files.FileName);
                string extension = Path.GetExtension(myfiles.files.FileName);
                myfiles.filesname = fileName = fileName + DateTime.Now.ToString("yyyy") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                   myfiles.files.CopyToAsync(fileStream);
                }
              _files.FilesUpload(myfiles);
              return RedirectToAction("Filesdashboard");

        }
        public ActionResult Filesdashboard()
        {
            var fileslist =_files.Filesdashboard();
            return View(fileslist);
        }
        public ActionResult FileDelete(int id)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            _files.FileDelete(id,wwwRootPath);
            return RedirectToAction("Filesdashboard");
        }
        public ActionResult FileDownload(int id)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            var downloadtask= _files.FileDownload(id, wwwRootPath);
            string store = "~/Image/" + downloadtask;
            return File(store, "Image/jpg");
        }
        
        public ActionResult Filelist()
        {
            return View();
        }
    }
}
