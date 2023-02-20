using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.Models.Base
{
     /// <summary>
     /// Base class for AspNetRolesModel.  Do not make changes to this class,
     /// instead, put additional code in the AspNetRolesModel class 
     /// </summary>
     public class AspNetRolesModelBase
     {
         /// <summary> 
         /// Gets or Sets Id 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(450, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Id")]
         public string Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Name 
         /// </summary> 
         [StringLength(256, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Name")]
         public string Name { get; set; } 

         /// <summary> 
         /// Gets or Sets NormalizedName 
         /// </summary> 
         [StringLength(256, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Normalized Name")]
         public string NormalizedName { get; set; } 

         /// <summary> 
         /// Gets or Sets ConcurrencyStamp 
         /// </summary> 
         [Display(Name = "Concurrency Stamp")]
         public string ConcurrencyStamp { get; set; } 

     }
}
