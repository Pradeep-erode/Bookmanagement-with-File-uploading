using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Core.BookEntity
{
    public class Adminentity
    {
        [Required(ErrorMessage ="Admin username required")]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="Use letters only")]
        public string admin { get; set; }
        [Required(ErrorMessage = "Admin password required")]
        [StringLength(4)]
        [Range(0000,9999,ErrorMessage ="Enter number only")]
        public string password { get; set; }
    }
}
