using Bookmanagement.Core.FilesEntity;
using Bookmanagement.Core.IRepository;
using Bookmanagement.Core.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Services.Filesservice
{
    public class FilesService : IServiceFiles
    {
        IRepositoryFiles _repositoryfiles;
        public FilesService(IRepositoryFiles filIrepo)
        {
            _repositoryfiles = filIrepo;
        }
        public void FilesUpload(Filesentity files)
        {
            _repositoryfiles.FilesUpload(files);
        }
        public List<Filesentity> Filesdashboard()
        {
            return _repositoryfiles.Filesdashboard();
        }
        public void FileDelete(int id, string wwwRootPath)
        {
            _repositoryfiles.FileDelete(id, wwwRootPath);
        }
        public string FileDownload(int id, string wwwRootPath)
        {
            return _repositoryfiles.FileDownload(id, wwwRootPath);
        }
    }
}
