using ClosedXML.Excel;
using PriorityLifeDataLoader.Build;
using PriorityLifeDataLoader.Control;
using PriorityLifeDataLoader.Helper;
using PriorityLifeDataLoader.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader
{


    public class ExtractedProperties : IDisposable
    {
        private List<DataTable> Table { get; set; }
        private Carrier Carrier { get; set; }
        public ExtractedProperties()
        {
            Table = new List<DataTable>();
        }
        public void ConvertToExtractedObject(Carrier carrier, string Path)
        {
            Carrier = carrier;
            using (TemplateProperties proper = new TemplateProperties(carrier, Path))
            {
                foreach (IXLWorksheet sheet in proper.Workbook.Worksheets)
                {
                    proper.TemplateSheets.Add(sheet.Name);
                }
                foreach (ITemplateSheet tempSheet in proper.TemplateSheets)
                {
                    using (Assemble assemble = new Assemble(tempSheet))
                    {
                        Table.Add(assemble.ReadTemplate());
                        Console.WriteLine("Total Row: " + Table[0].Rows.Count);
                    }
                }
            }
        }
        public void ConvertToExtractedObject(Carrier carrier, Stream blob)
        {
            Carrier = carrier;
            using (TemplateProperties proper = new TemplateProperties(carrier, blob))
            {
                foreach (IXLWorksheet sheet in proper.Workbook.Worksheets)
                {
                    proper.TemplateSheets.Add(sheet.Name);
                }
                foreach (ITemplateSheet tempSheet in proper.TemplateSheets)
                {
                    using (Assemble assemble = new Assemble(tempSheet))
                    {
                        Table.Add(  assemble.ReadTemplate() );
                    }
                }
            }
        }
        public void ConvertToExtractedObject(Carrier carrier, string blob, string Date)
        {
            Carrier = carrier;
            using (TemplateProperties proper = new TemplateProperties(carrier, blob))
            {
                foreach (IXLWorksheet sheet in proper.Workbook.Worksheets)
                {
                    proper.TemplateSheets.Add(sheet.Name);
                }
                foreach (ITemplateSheet tempSheet in proper.TemplateSheets)
                {
                    using (Assemble assemble = new Assemble(tempSheet))
                    {
                        Table.Add(assemble.ReadTemplate(Date));
                        Console.WriteLine("Total Row: " + Table[0].Rows.Count);
                    }
                }
            }
        }

        public string GetJson()
        {
            return Table[0].ToJson();
        }

        public int GetTotalRows()
        {
            return Table[0].Rows.Count;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~ExtractedProperties()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Table = null;
            }
        }
    }
}
