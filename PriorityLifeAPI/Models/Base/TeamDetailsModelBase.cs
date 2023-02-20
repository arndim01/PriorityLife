using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.Models.Base
{
     /// <summary>
     /// Base class for TeamDetailsModel.  Do not make changes to this class,
     /// instead, put additional code in the TeamDetailsModel class 
     /// </summary>
     public class TeamDetailsModelBase
     {
         /// <summary> 
         /// Gets or Sets Id 
         /// </summary> 
         [Display(Name = "Id")]
         public int Id { get; set; } 

         /// <summary> 
         /// Gets or Sets TeamId 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Team Id")]
         public int TeamId { get; set; } 

         /// <summary> 
         /// Gets or Sets TeamMemberId 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Team Member Id")]
         public int TeamMemberId { get; set; } 

         /// <summary> 
         /// Gets or Sets Activate 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Activate")]
         public bool Activate { get; set; } 

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
