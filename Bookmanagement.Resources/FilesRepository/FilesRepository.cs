using Bookmanagement.Core.FilesEntity;
using Bookmanagement.Core.IRepository;
using Bookmanagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bookmanagement.Resources.FilesRepository
{
    public class FilesRepository: IRepositoryFiles
    {
        #region Filesupload
        public async void FilesUpload(Filesentity myfile)
        {
            using (var _context = new BookContext())
            {
                Filesmanagement manage = new Filesmanagement();
                //type conversion
                string stringfiles = myfile.files.ToString();
                byte[] fileasbyte = Encoding.ASCII.GetBytes(stringfiles);


                manage.Filesname = myfile.filesname;
                manage.Files = fileasbyte;
                _context.Filesmanagement.Add(manage);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Dashboard
        public List<Filesentity> Filesdashboard()
        {
            List<Filesentity> listoffiles = new List<Filesentity>();
            using (var _context = new BookContext())
            {
                var listtask = _context.Filesmanagement.Where(a => a.IsDeleted == false).ToList();
                foreach (var fileitm in listtask)
                {
                    Filesentity filelist = new()
                    {
                        filesID = fileitm.FilesId,
                        filesname = fileitm.Filesname,
                        filesview = fileitm.Files
                    };

                    string imgSrc = Convert.ToBase64String(fileitm.Files);

                    //var imgSrc = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(fileitm.Files));
                    //var base64 = Convert.ToBase64String(fileitm.Files);
                    //var imgSrc = string.Format("data:image/gif;base64,{0}", base64);
                    //filelist.filesviewstring = imgSrc;

                    listoffiles.Add(filelist);
                }
                return listoffiles;
            }
        }
        #endregion

        public async void FileDelete(int id,string wwwRootPath)
        {
            using (var _context = new BookContext())
            {
                var imageModel = await _context.Filesmanagement.FindAsync(id);
                //delete image from wwwroot/image
                var imagePath = Path.Combine(wwwRootPath, "Image", imageModel.Filesname);
                //var imagePath = Path.Combine("~/Image/" + imageModel.Filesname);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                    //delete the record
                    imageModel.IsDeleted = true;
                    imageModel.UpdatedTimeStamp = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                
            }
        }
        public string FileDownload(int id, string wwwRootPath)
        {
            using (var _context = new BookContext())
            {
                var downloadimage = _context.Filesmanagement.Where(a => a.FilesId == id).SingleOrDefault();
                var image =downloadimage.Filesname;
                //var filepath = Path.Combine(wwwRootPath,"Image", image);
                return image;
            }
        }


    }
}
