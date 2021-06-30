using Bookmanagement.Core.FilesEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Core.IRepository
{
    public interface IRepositoryFiles
    {
        public void FilesUpload(Filesentity file);
        public List<Filesentity> Filesdashboard();

        public void FileDelete(int id,string wwwRootPath);

        public string FileDownload(int id, string wwwRootPath);
       
    }
}
