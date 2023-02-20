using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.Models.Base
{
     /// <summary>
     /// Base class for AspNetUsersModel.  Do not make changes to this class,
     /// instead, put additional code in the AspNetUsersModel class 
     /// </summary>
     public class AspNetUsersModelBase
     {
         /// <summary> 
         /// Gets or Sets Id 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [StringLength(450, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Id")]
         public string Id { get; set; } 

         /// <summary> 
         /// Gets or Sets UserName 
         /// </summary> 
         [StringLength(256, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "User Name")]
         public string UserName { get; set; } 

         /// <summary> 
         /// Gets or Sets NormalizedUserName 
         /// </summary> 
         [StringLength(256, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Normalized User Name")]
         public string NormalizedUserName { get; set; } 

         /// <summary> 
         /// Gets or Sets Email 
         /// </summary> 
         [StringLength(256, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Email")]
         public string Email { get; set; } 

         /// <summary> 
         /// Gets or Sets NormalizedEmail 
         /// </summary> 
         [StringLength(256, ErrorMessage = "{0} must be a maximum of {1} characters long!")]
         [Display(Name = "Normalized Email")]
         public string NormalizedEmail { get; set; } 

         /// <summary> 
         /// Gets or Sets EmailConfirmed 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Email Confirmed")]
         public bool EmailConfirmed { get; set; } 

         /// <summary> 
         /// Gets or Sets PasswordHash 
         /// </summary> 
         [Display(Name = "Password Hash")]
         public string PasswordHash { get; set; } 

         /// <summary> 
         /// Gets or Sets SecurityStamp 
         /// </summary> 
         [Display(Name = "Security Stamp")]
         public string SecurityStamp { get; set; } 

         /// <summary> 
         /// Gets or Sets ConcurrencyStamp 
         /// </summary> 
         [Display(Name = "Concurrency Stamp")]
         public string ConcurrencyStamp { get; set; } 

         /// <summary> 
         /// Gets or Sets PhoneNumber 
         /// </summary> 
         [Display(Name = "Phone Number")]
         public string PhoneNumber { get; set; } 

         /// <summary> 
         /// Gets or Sets PhoneNumberConfirmed 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Phone Number Confirmed")]
         public bool PhoneNumberConfirmed { get; set; } 

         /// <summary> 
         /// Gets or Sets TwoFactorEnabled 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Two Factor Enabled")]
         public bool TwoFactorEnabled { get; set; } 

         /// <summary> 
         /// Gets or Sets LockoutEnd 
         /// </summary> 
         [Display(Name = "Lockout End")]
         public DateTimeOffset? LockoutEnd { get; set; } 

         /// <summary> 
         /// Gets or Sets LockoutEnabled 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Lockout Enabled")]
         public bool LockoutEnabled { get; set; } 

         /// <summary> 
         /// Gets or Sets AccessFailedCount 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Range(typeof(Int32), "-2147483648", "2147483647", ErrorMessage = "{0} must be an integer!")]
         [Display(Name = "Access Failed Count")]
         public int AccessFailedCount { get; set; } 

         /// <summary> 
         /// Gets or Sets FirstName 
         /// </summary> 
         [Display(Name = "First Name")]
         public string FirstName { get; set; } 

         /// <summary> 
         /// Gets or Sets LastName 
         /// </summary> 
         [Display(Name = "Last Name")]
         public string LastName { get; set; } 

     }
}
