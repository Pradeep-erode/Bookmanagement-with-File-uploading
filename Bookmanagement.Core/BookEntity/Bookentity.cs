using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmanagement.Core.BookEntity
{
    public class Bookentity
    {
        public int BookId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Letters only")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please select Author")]
        public int Author { get; set; }
        
        public string stringAuthor { get; set; }
        public List<Authorlist> Authorlists { get; set; }
        [Required(ErrorMessage = "Please Enter Cost of book")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
    public class Authorlist
    {
        public int AuthorId { get; set; }
        public string Authorname { get; set; }
    }
}
