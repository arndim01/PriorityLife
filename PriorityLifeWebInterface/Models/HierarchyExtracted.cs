using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Models
{
    public class HierarchyExtracted
    {
        [Required(ErrorMessage ="{0} is required!")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Upline 1")]
        public string Upline1 { get; set; }
        [Display(Name = "Upline 2")]
        public string Upline2 { get; set; }
        [Display(Name = "Upline 3")]
        public string Upline3 { get; set; }
        [Display(Name = "Upline 4")]
        public string Upline4 { get; set; }
        [Display(Name = "Upline 5")]
        public string Upline5 { get; set; }
        [Display(Name = "Upline 6")]
        public string Upline6 { get; set; }
        [Display(Name = "Upline 7")]
        public string Upline7 { get; set; }
        [Display(Name = "Upline 8")]
        public string Upline8 { get; set; }
        [Display(Name = "Upline 9")]
        public string Upline9 { get; set; }
        [Display(Name = "Upline 10")]
        public string Upline10 { get; set; }
    }
}
