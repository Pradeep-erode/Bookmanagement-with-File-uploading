using Bookmanagement.Core.BookEntity;
using Bookmanagement.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmanagement_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private readonly IServiceBook _Ibook;
        public BookAPIController(IServiceBook Ibookservice)
        {
            _Ibook = Ibookservice;
        }
        [HttpPost]
        public ActionResult Adminlogin(Adminentity admincheck)
        {
            bool check = _Ibook.AdminCheck(admincheck);
            if (check==true)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpGet]
        public ActionResult BookDashboard()
        {
            var booklist = _Ibook.BookDashboard();
            var bookcount = booklist.Count();
            if (bookcount > 0)
            {
                return Ok(booklist);
            }
            return NotFound();
           
        }
        [HttpGet]
        public ActionResult Getauthor()
        {
            var authorlist =_Ibook.Getauthor();
            return Ok(authorlist);
        }
        [HttpPost]
        public ActionResult Addbookdetail(Bookentity bookdetail)
        {
            _Ibook.Addbookdetail(bookdetail);
            return Ok();
        }
        [HttpDelete]
        public ActionResult Deletebook(int bookid)
        {
            _Ibook.Deletebook(bookid);
            return Ok();
        }
        [HttpGet]
        public ActionResult GetBook(int bookid)
        {
            var booklist = _Ibook.Getbook(bookid);
            booklist.Authorlists = _Ibook.Getauthor();
            return Ok(booklist);
        }
    }
}
