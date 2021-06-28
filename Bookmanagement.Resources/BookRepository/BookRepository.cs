using Bookmanagement.Core.BookEntity;
using Bookmanagement.Core.IRepository;
using Bookmanagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookmanagement.Resources.BookRepository
{
    public class BookRepository : IRepositoryBook
    {
        #region Admincheck
        public bool AdminCheck(Adminentity admincheck)
        {
            using (var entity = new BookContext())
            {
                var check = entity.Employeelogin.Where(a => a.Username == admincheck.admin && a.Password == admincheck.password).Count();
                if (check > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region Dashboard
        public IEnumerable<Bookentity> BookDashboard()
        {
            List<Bookentity> booklists = new List<Bookentity>();
            using (var entity = new BookContext())
            {
                var innerjoin = from a in entity.Bookmanagement join
                            b in entity.BookAuthors on a.Author equals b.AuthorId where a.IsDeleted==false
                                select new Bookentity
                                {
                                    BookId = a.BookId,
                                    Title = a.Title,
                                    stringAuthor = b.AuthorName,
                                    Price=a.Price
                                };
                var listofbooks=innerjoin.ToList();
                //foreach (var book in innerjoin)
                //{
                //    Bookentity books = new Bookentity();
                //    books.BookId = book.Bookid;
                //    books.Title = book.title;
                //    books.stringAuthor = book.author;
                //    books.Price = book.price;
                //    booklists.Add(books);
                //}
                
                return listofbooks;
            }
        }
        #endregion

        #region Addbookdetail
        public void Addbookdetail(Bookentity bookdetail)
        {
            if (bookdetail.BookId > 0)
            {
                using (var entity = new BookContext())
                {
                    var booklist = entity.Bookmanagement.Where(a => a.BookId == bookdetail.BookId).SingleOrDefault();
                    
                        booklist.Title = bookdetail.Title;
                        booklist.Author = bookdetail.Author;
                        booklist.Price = bookdetail.Price;
                        entity.SaveChanges();
                    
                }
            }
            else
            {
                using (var entity = new BookContext())
                {
                    Entities.Bookmanagement bookdd = new Entities.Bookmanagement();
                    bookdd.Title = bookdetail.Title;
                    bookdd.Author = bookdetail.Author;
                    bookdd.Price = bookdetail.Price;
                    entity.Add(bookdd);
                    entity.SaveChanges();
                }
            
            }
        }
        #endregion

        #region Getauthor
        public List<Authorlist> Getauthor()
        {
            List<Authorlist> authorlist = new List<Authorlist>();
            using (var entity = new BookContext())
            {
                var authorentity = entity.BookAuthors.ToList();
                foreach (var baseitm in authorentity)
                {
                    Authorlist author = new Authorlist();
                    author.AuthorId = baseitm.AuthorId;
                    author.Authorname = baseitm.AuthorName;
                    authorlist.Add(author);
                }
            }
            return authorlist;
        }
        #endregion

        #region Getbookforedit
        public Bookentity Getbook(int bookid)
        {
            using (var entity = new BookContext())
            {
                var getforedit = entity.Bookmanagement.Where(a => a.BookId == bookid).SingleOrDefault();
                Bookentity book = new Bookentity();
                book.BookId = getforedit.BookId;
                book.Title = getforedit.Title;
                book.Author = getforedit.Author;
                book.Price = getforedit.Price;
                return book;
            }
        }
        #endregion

        #region Deletebook
        public void Deletebook(int bookid)
        {
            using (var entity = new BookContext())
            {
                var getbook = entity.Bookmanagement.Where(a => a.BookId == bookid).SingleOrDefault();
                getbook.IsDeleted = true;
                getbook.UpdatedTimeStamp = DateTime.Now;
                entity.SaveChanges();
            }
        }
        #endregion

    }
}
