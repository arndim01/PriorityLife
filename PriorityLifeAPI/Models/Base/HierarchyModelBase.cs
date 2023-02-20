using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriorityLifeAPI.Models.Base
{
     /// <summary>
     /// Base class for HierarchyModel.  Do not make changes to this class,
     /// instead, put additional code in the HierarchyModel class 
     /// </summary>
     public class HierarchyModelBase
     {
         /// <summary> 
         /// Gets or Sets Id 
         /// </summary> 
         [Display(Name = "Id")]
         public int Id { get; set; } 

         /// <summary> 
         /// Gets or Sets SalesPersonId 
         /// </summary> 
         [Required(ErrorMessage = "{0} is required!")]
         [Display(Name = "Sales Person Id")]
         public int SalesPersonId { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline1Id 
         /// </summary> 
         [Display(Name = "Upline1 Id")]
         public int? Upline1Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline2Id 
         /// </summary> 
         [Display(Name = "Upline2 Id")]
         public int? Upline2Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline3Id 
         /// </summary> 
         [Display(Name = "Upline3 Id")]
         public int? Upline3Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline4Id 
         /// </summary> 
         [Display(Name = "Upline4 Id")]
         public int? Upline4Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline5Id 
         /// </summary> 
         [Display(Name = "Upline5 Id")]
         public int? Upline5Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline6Id 
         /// </summary> 
         [Display(Name = "Upline6 Id")]
         public int? Upline6Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline7Id 
         /// </summary> 
         [Display(Name = "Upline7 Id")]
         public int? Upline7Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline8Id 
         /// </summary> 
         [Display(Name = "Upline8 Id")]
         public int? Upline8Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline9Id 
         /// </summary> 
         [Display(Name = "Upline9 Id")]
         public int? Upline9Id { get; set; } 

         /// <summary> 
         /// Gets or Sets Upline10Id 
         /// </summary> 
         [Display(Name = "Upline10 Id")]
         public int? Upline10Id { get; set; } 

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
