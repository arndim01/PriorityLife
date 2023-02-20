    using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.Models.Base
{
     /// <summary>
     /// Base class for SalespersonModel.  Do not make changes to this class,
     /// instead, put additional code in the SalespersonModel class 
     /// </summary>
     public class SalespersonModelBase
     {
         /// <summary> 
         /// Gets or Sets Id 
         /// </summary> 
         [Display(Name = "Id")]
         public int Id { get; set; } 

         /// <summary> 
         /// Gets or Sets FirstName 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "First Name")]
         public string FirstName { get; set; } 

         /// <summary> 
         /// Gets or Sets MiddleName 
         /// </summary> 
         //[Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Middle Name")]
         public string MiddleName { get; set; } 

         /// <summary> 
         /// Gets or Sets LastName 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Last Name")]
         public string LastName { get; set; } 

         /// <summary> 
         /// Gets or Sets Initials 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Initials")]
         public string Initials { get; set; } 

         /// <summary> 
         /// Gets or Sets Email 
         /// </summary> 
         [Display(Name = "Email")]
         public string Email { get; set; } 

         /// <summary> 
         /// Gets or Sets Phone 
         /// </summary> 
         [Display(Name = "Phone")]
         public string Phone { get; set; } 

         /// <summary> 
         /// Gets or Sets Active 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Active")]
         public bool Active { get; set; } 

         /// <summary> 
         /// Gets or Sets AddedBy 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Added By")]
         public string AddedBy { get; set; } 

         /// <summary> 
         /// Gets or Sets AddedDate 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         //[RegularExpression(@"^(((((0[13578])|([13578])|(1[02]))[\-\/\s]?((0[1-9])|([1-9])|([1-2][0-9])|(3[01])))|((([469])|(11))[\-\/\s]?((0[1-9])|([1-9])|([1-2][0-9])|(30)))|((02|2)[\-\/\s]?((0[1-9])|([1-9])|([1-2][0-9]))))[\-\/\s]?\d{4})(\s(((0[1-9])|([1-9])|(1[0-2]))\:([0-5][0-9])((\s)|(\:([0-5][0-9])\s))([AM|PM|am|pm]{2,2})))?$", ErrorMessage = "{0} must be a valid date!")]
         [DisplayFormat(DataFormatString = "{0:M/d/yyyy}", ApplyFormatInEditMode = true)]
         [Display(Name = "Added Date")]
         public DateTime AddedDate { get; set; } 

         /// <summary> 
         /// Gets or Sets UpdatedBy 
         /// </summary> 
         [Display(Name = "Updated By")]
         public string UpdatedBy { get; set; } 

         /// <summary> 
         /// Gets or Sets UpdatedDate 
         /// </summary> 
         //[RegularExpression(@"^(((((0[13578])|([13578])|(1[02]))[\-\/\s]?((0[1-9])|([1-9])|([1-2][0-9])|(3[01])))|((([469])|(11))[\-\/\s]?((0[1-9])|([1-9])|([1-2][0-9])|(30)))|((02|2)[\-\/\s]?((0[1-9])|([1-9])|([1-2][0-9]))))[\-\/\s]?\d{4})(\s(((0[1-9])|([1-9])|(1[0-2]))\:([0-5][0-9])((\s)|(\:([0-5][0-9])\s))([AM|PM|am|pm]{2,2})))?$", ErrorMessage = "{0} must be a valid date!")]
         [DisplayFormat(DataFormatString = "{0:M/d/yyyy}", ApplyFormatInEditMode = true)]
         [Display(Name = "Updated Date")]
         public DateTime? UpdatedDate { get; set; } 

     }
}
