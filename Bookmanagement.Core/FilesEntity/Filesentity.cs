using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Core.FilesEntity
{
    public class Filesentity
    {
        public int filesID { get; set; }
        [Required(ErrorMessage ="Filename required")]
        [StringLength(40)]
        //[RegularExpression(@"^[a-zA-Z ]+$",ErrorMessage ="Use albhabets and space only")]
        public string filesname { get; set; }
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.pdf|.tif|.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public IFormFile files { get; set; }

        public byte[] filesview { get; set; }
        public string filesviewstring { get; set; }

    }
}
