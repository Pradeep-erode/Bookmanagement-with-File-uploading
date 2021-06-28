using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filesmanagement.Controllers
{
    public class FilesController : Controller
    {
        private readonly files _files;
        public IActionResult Index()
        {
            return View();
        }
    }
}
