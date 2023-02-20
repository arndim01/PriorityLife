using ClosedXML.Excel;
using PriorityLifeDataLoader.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader.Build
{
    public class TemplateProperties: IDisposable
    {
        public TemplateProperties(Carrier carrier,  Stream blob)
        {
            var pattern = new PatternXML();
            FilePath = blob;
            XMLProperties = pattern.GetXMLProperties(carrier);
            Workbook = new XLWorkbook(blob);
            TemplateSheets = new TemplateSheetsCollection(this);
        }
        public TemplateProperties(Carrier carrier, string path)
        {
            var pattern = new PatternXML();
            Path = path;
            XMLProperties = pattern.GetXMLProperties(carrier);
            Workbook = new XLWorkbook(path);
            TemplateSheets = new TemplateSheetsCollection(this);
        }
        public XLWorkbook Workbook { get; set; }
        public XMLProperties XMLProperties { get; set; }
        public ITemplateSheetsCollection TemplateSheets { get; set; }
        public Stream FilePath { get; set; }
        public string Path { get; set; }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~TemplateProperties()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Workbook = null;
                XMLProperties = null;
            }
        }
    }
}
