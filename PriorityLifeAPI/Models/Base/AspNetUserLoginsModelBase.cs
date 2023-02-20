using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.Models.Base
{
     /// <summary>
     /// Base class for AspNetUserLoginsModel.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUserLoginsModel class 
     /// </summary>
     public class AspNetUserLoginsModelBase
     {
         /// <summary> 
         /// Gets or Sets LoginProvider 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(128, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Login Provider")]
         public string LoginProvider { get; set; } 

         /// <summary> 
         /// Gets or Sets ProviderKey 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(128, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Provider Key")]
         public string ProviderKey { get; set; } 

         /// <summary> 
         /// Gets or Sets ProviderDisplayName 
         /// </summary> 
         [Display(Name = "Provider Display Name")]
         public string ProviderDisplayName { get; set; } 

         /// <summary> 
         /// Gets or Sets UserId 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(450, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "User Id")]
         public string UserId { get; set; } 

     }
}
