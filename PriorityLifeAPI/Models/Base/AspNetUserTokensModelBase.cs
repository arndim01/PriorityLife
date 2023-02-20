using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.Models.Base
{
     /// <summary>
     /// Base class for AspNetUserTokensModel.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUserTokensModel class 
     /// </summary>
     public class AspNetUserTokensModelBase
     {
         /// <summary> 
         /// Gets or Sets UserId 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(450, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "User Id")]
         public string UserId { get; set; } 

         /// <summary> 
         /// Gets or Sets LoginProvider 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(128, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Login Provider")]
         public string LoginProvider { get; set; } 

         /// <summary> 
         /// Gets or Sets Name 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(128, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Name")]
         public string Name { get; set; } 

         /// <summary> 
         /// Gets or Sets Value 
         /// </summary> 
         [Display(Name = "Value")]
         public string Value { get; set; } 

     }
}
