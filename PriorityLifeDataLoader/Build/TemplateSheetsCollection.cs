using PriorityLifeDataLoader.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader.Build
{
    public class TemplateSheetsCollection : ITemplateSheetsCollection, IEnumerable<ITemplateSheet>
    {
        private TemplateProperties TemplateProperties;
        private Dictionary<string, ITemplateSheet> TemplateSheet = new Dictionary<string, ITemplateSheet>();
        internal TemplateSheetsCollection(TemplateProperties templateProperties)
        {
            TemplateProperties = templateProperties;
        }
        public ITemplateSheet Add(string sheetName)
        {
            var sheet = new TemplateSheet(sheetName, TemplateProperties);
            if( sheetName != null) { TemplateSheet.Add(sheetName.ToLowerInvariant(), sheet); }
                
            return sheet;
        }

        public IEnumerator<ITemplateSheet> GetEnumerator()
        {
            return ((IEnumerable<ITemplateSheet>)TemplateSheet.Values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
