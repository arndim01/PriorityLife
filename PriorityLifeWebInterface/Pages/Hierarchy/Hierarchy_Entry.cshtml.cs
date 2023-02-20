using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PriorityLifeWebInterface.Helper;
using PriorityLifeWebInterface.Models;

namespace PriorityLifeWebInterface.Pages.Hierarchy
{
    public class Hierarchy_EntryModel : PageModel
    {
        [BindProperty]
        public IFormFile Upload { get; set; }
        [BindProperty]
        public HierarchyExtracted HierarchyExtracted { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; }
        
        public void OnGet(string returnUrl)
        {
            LoadPage(returnUrl);
        }
        
        private PageResult LoadPage(string returnUrl)
        {


            ReturnUrl = returnUrl;

            return Page();
        }
        
        public IActionResult OnPostSave()
        {
            HierarchyExtracted = null;

            var displayUrl = UriHelper.GetDisplayUrl(Request);
            var urlBuilder =
            new UriBuilder(displayUrl)
            {
                Query = null,
                Fragment = null
            };

            return LoadPage(urlBuilder.ToString());
        }


        public IActionResult OnPost()
        {
            try
            {
                if (Path.GetExtension(Upload.FileName) == ".pdf")
                {
                    using (Stream stream = Upload.OpenReadStream())
                    {
                        PdfDocument pdf = new PdfDocument();
                        pdf.LoadFromStream(stream);
                        PdfPageBase page = pdf.Pages[0];
                        string firstName = page.ExtractText(new RectangleF(111, 78, 80, 10)).CleanExtractedText();
                        string middleName = page.ExtractText(new RectangleF(196, 78, 80, 10)).CleanExtractedText();
                        string lastName = page.ExtractText(new RectangleF(273, 78, 80, 10)).CleanExtractedText();
                        string phone = page.ExtractText(new RectangleF(418, 75, 80, 10)).CleanExtractedPhone();
                        string email = page.ExtractText(new RectangleF(127, 105, 80, 10)).CleanExtractedEmail();
                        string upline1 = page.ExtractText(new RectangleF(197, 394, 80, 10)).CleanExtractedText();
                        string upline2 = page.ExtractText(new RectangleF(197, 420, 80, 10)).CleanExtractedText();
                        string upline3 = page.ExtractText(new RectangleF(197, 448, 80, 10)).CleanExtractedText();
                        string upline4 = page.ExtractText(new RectangleF(197, 475, 80, 10)).CleanExtractedText();
                        string upline5 = page.ExtractText(new RectangleF(197, 500, 80, 10)).CleanExtractedText();
                        string upline6 = page.ExtractText(new RectangleF(197, 530, 80, 10)).CleanExtractedText();
                        string upline7 = page.ExtractText(new RectangleF(197, 558, 80, 10)).CleanExtractedText();
                        string upline8 = page.ExtractText(new RectangleF(197, 579, 80, 10)).CleanExtractedText();
                        string upline9 = page.ExtractText(new RectangleF(197, 610, 80, 10)).CleanExtractedText();
                        string upline10 = page.ExtractText(new RectangleF(197, 638, 80, 10)).CleanExtractedText();

                        HierarchyExtracted = new HierarchyExtracted()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            MiddleName = middleName,
                            Phone = phone,
                            Email = email,
                            Upline1 = upline1,
                            Upline2 = upline2,
                            Upline3 = upline3,
                            Upline4 = upline4,
                            Upline5 = upline5,
                            Upline6 = upline6,
                            Upline7 = upline7,
                            Upline8 = upline8,
                            Upline9 = upline9,
                            Upline10 = upline10
                        };


                        Console.WriteLine(firstName);
                        return Page();

                    }
                }
                else
                {
                    return Page();
                }
            }
            catch
            {
                return Page();
            }
           


           

        }
    }
}