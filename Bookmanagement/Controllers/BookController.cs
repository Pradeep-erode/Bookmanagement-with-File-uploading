using Bookmanagement.Core.BookEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;



namespace Bookmanagement.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Adminlogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Admincheck(Adminentity admincheck)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44390/api/BookAPI/Adminlogin");
                    var Posttask = client.PostAsJsonAsync<Adminentity>(client.BaseAddress, admincheck);
                    Posttask.Wait();
                    var checkresult = Posttask.Result;
                    if (checkresult.IsSuccessStatusCode)
                    {
                        HttpContext.Session.SetString("admin", "mydata");
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        TempData["failed"] = "Wrong credentials";
                        return RedirectToAction("Adminlogin");
                    }
                }
            }
            else 
            {
                TempData["failed"] = "Enter valid credentials";
                return RedirectToAction("Adminlogin");
            }

        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("admin") != null)
            {
                List<Bookentity> book = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44390/api/BookAPI/");
                    var Gettask = client.GetAsync("BookDashboard");
                    Gettask.Wait();

                    var result = Gettask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        //var readtask = result.Content.ReadAsAsync<IList<Bookentity>>();
                        //readtask.Wait();

                        var responseData = result.Content.ReadAsStringAsync().Result;
                        book = JsonConvert.DeserializeObject<List<Bookentity>>(responseData);
                        return View(book);
                    }
                    else
                    {
                        TempData["nodata"] = "You have no book Click to add new book";
                        return RedirectToAction("Newbook");
                    }
                }
            }
            TempData["session"] = "Session out please login again";
            return RedirectToAction("Adminlogin");
            //return View("Sessionout");
        }
        public IActionResult Newbook(int bookid)
        {
            if (HttpContext.Session.GetString("admin") != null)
            {
                if (bookid > 0)
                {
                    Bookentity books = new Bookentity();
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("https://localhost:44390/api/BookAPI/");
                        var gettask = client.GetAsync("Getbook?bookid=" + bookid);
                        gettask.Wait();

                        var result = gettask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var bookdetail = result.Content.ReadAsAsync<Bookentity>();
                            bookdetail.Wait();

                            books = bookdetail.Result;
                            TempData["updated"] = "Books detail updated successfully";
                            return View(books);
                        }
                        else
                        {
                            TempData["failed"] = "failed";
                            return RedirectToAction("Dashboard");
                        }
                    }

                }
                else
                {
                    List<Authorlist> authors = null;
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("https://localhost:44390/api/BookAPI/Getauthor");
                        var gettask = client.GetAsync(client.BaseAddress);
                        gettask.Wait();

                        var result = gettask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var responseData = result.Content.ReadAsStringAsync().Result;
                            authors = JsonConvert.DeserializeObject<List<Authorlist>>(responseData);

                            Bookentity books = new Bookentity();
                            books.Authorlists = authors;
                            //TempData["pricezero"] = "GetRidZerovalue";
                            return View(books);
                        }
                        else
                        {
                            return RedirectToAction("Adminlogin");
                        }
                    }
                }
            }
            TempData["session"] = "Session out please login again";
            return RedirectToAction("Adminlogin"); 
        }
        [HttpPost]
        public IActionResult Addbookdetail(Bookentity bookdetail)
        {
            if (HttpContext.Session.GetString("admin") != null)
            {
                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44390/api/BookAPI/Addbookdetail");
                        var posttask = client.PostAsJsonAsync<Bookentity>(client.BaseAddress, bookdetail);
                        posttask.Wait();

                        var getbook = posttask.Result;
                        if (getbook.IsSuccessStatusCode)
                        {
                            TempData["bookadded"]= "New Book added successfully!!!";
                            return RedirectToAction("Dashboard");
                        }

                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                        return View("Newbook");
                    }
                }
                else
                {
                    TempData["validfailed"] = "Please enter correct format";
                    return RedirectToAction("Newbook");
                }
            }
            TempData["session"] = "Session out please login again";
            return RedirectToAction("Adminlogin");
                
        }
        public IActionResult Deletebook(int bookid)
        {
            if (HttpContext.Session.GetString("admin") != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44390/api/BookAPI/Deletebook");
                    var deletetask = client.DeleteAsync("?bookid=" + bookid);
                    deletetask.Wait();

                    var result = deletetask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        ViewBag.APIerror = true;
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            TempData["session"] = "Session out please login again";
            return RedirectToAction("Adminlogin");
            
        }

    }
}
