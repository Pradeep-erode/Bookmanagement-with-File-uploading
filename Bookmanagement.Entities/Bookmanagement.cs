﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bookmanagement.Entities
{
    public partial class Bookmanagement
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int Author { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Column("Is_deleted")]
        public bool IsDeleted { get; set; }
        [Column("Created_Time_Stamp", TypeName = "datetime")]
        public DateTime CreatedTimeStamp { get; set; }
        [Column("Updated_Time_Stamp", TypeName = "datetime")]
        public DateTime UpdatedTimeStamp { get; set; }
    }
}