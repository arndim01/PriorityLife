using PriorityLifeDataLoader.Helper;
using PriorityLifeDataLoader.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader.Control
{
    public class Assemble : IDisposable
    {
        private ITemplateSheet TemplateSheet;

        public Assemble(ITemplateSheet templateSheet)
        {
            TemplateSheet = templateSheet;
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~Assemble()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                TemplateSheet = null;
            }
        }
        public DataTable ReadTemplate()
        {
            var ColumnsAddress = TemplateSheet.GetColumnsPosition();
            return TemplateSheet.ConstructData(ColumnsAddress);
        }
        public DataTable ReadTemplate(string Date)
        {
            var ColumnsAddress = TemplateSheet.GetColumnsPosition();
            return TemplateSheet.ConstructData(ColumnsAddress, Date);
        }
    }
}
