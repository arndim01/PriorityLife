using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.Models.Base
{
     /// <summary>
     /// Base class for AspNetUserClaimsModel.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUserClaimsModel class 
     /// </summary>
     public class AspNetUserClaimsModelBase
     {
         /// <summary> 
         /// Gets or Sets Id 
         /// </summary> 
         [Display(Name = "Id")]
         public int Id { get; set; } 

         /// <summary> 
         /// Gets or Sets UserId 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(450, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "User Id")]
         public string UserId { get; set; } 

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
