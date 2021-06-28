using Bookmanagement.Core.BookEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Core.IRepository
{
    public interface IRepositoryBook
    {
        public bool AdminCheck(Adminentity admincheck);
        public void Addbookdetail(Bookentity bookdetail);
        public List<Authorlist> Getauthor();
        public void Deletebook(int bookid);
        public IEnumerable<Bookentity> BookDashboard();

        public Bookentity Getbook(int bookid);
    }
}
