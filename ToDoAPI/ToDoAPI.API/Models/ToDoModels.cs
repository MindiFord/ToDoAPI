using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ToDoAPI.DATA.EF;

namespace ToDoAPI.API.Models
{
    public class ToDoViewModel
    {
        [Key]
        public int TodoId { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        public bool Done { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }

    public class CategoryViewModel
    {

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = " ** Cannot exceed 50 characters")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = " ** Cannot exceed 100 characters")]
        public string Description { get; set; }

    }
}