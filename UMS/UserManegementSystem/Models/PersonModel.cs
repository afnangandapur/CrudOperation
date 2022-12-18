using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManegementSystem.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        [Required]
        public string First { get; set; }
        [Required]
        public string Last { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string About { get; set; }
    }
}