using Bookmanagement.Core.BookEntity;
using Bookmanagement.Core.IRepository;
using Bookmanagement.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Services.Bookservice
{
    public class BookService: IServiceBook
    {
        IRepositoryBook _Repositoryservice;
        public BookService(IRepositoryBook Irepo)
        {
            _Repositoryservice = Irepo;
        }
        public bool AdminCheck(Adminentity admincheck)
        {
            return _Repositoryservice.AdminCheck(admincheck);
        }
        public void Addbookdetail(Bookentity bookdetail)
        {
            _Repositoryservice.Addbookdetail(bookdetail);
        }
        public List<Authorlist> Getauthor()
        {
            return _Repositoryservice.Getauthor();
        }
        public void Deletebook(int bookid)
        {
            _Repositoryservice.Deletebook(bookid);
        }
        public IEnumerable<Bookentity> BookDashboard()
        {
            return _Repositoryservice.BookDashboard();
        }
        public Bookentity Getbook(int bookid)
        {
            return _Repositoryservice.Getbook(bookid);
        }
    }
}
