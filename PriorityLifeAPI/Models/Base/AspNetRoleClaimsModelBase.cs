using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.Models.Base
{
     /// <summary>
     /// Base class for AspNetRoleClaimsModel.  Do not make changes to this class,
     /// instead, put additional code in the AspNetRoleClaimsModel class 
     /// </summary>
     public class AspNetRoleClaimsModelBase
     {
         /// <summary> 
         /// Gets or Sets Id 
         /// </summary> 
         [Display(Name = "Id")]
         public int Id { get; set; } 

         /// <summary> 
         /// Gets or Sets RoleId 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(450, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Role Id")]
         public string RoleId { get; set; } 

         /// <summary> 
         /// Gets or Sets ClaimType 
         /// </summary> 
         [Display(Name = "Claim Type")]
         public string ClaimType { get; set; } 

         /// <summary> 
         /// Gets or Sets ClaimValue 
         /// </summary> 
         [Display(Name = "Claim Value")]
         public string ClaimValue { get; set; } 

     }
}
