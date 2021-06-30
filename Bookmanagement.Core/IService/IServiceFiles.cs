using Bookmanagement.Core.FilesEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Core.IService
{
    public interface IServiceFiles
    {
        public void FilesUpload(Filesentity filesa);
        public List<Filesentity> Filesdashboard();
        public void FileDelete(int id,string wwwRootPath);

        public string FileDownload(int id, string wwwRootPath);
    }
}
