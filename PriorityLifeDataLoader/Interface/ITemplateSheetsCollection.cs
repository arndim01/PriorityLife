using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader.Interface
{
    public interface ITemplateSheetsCollection: IEnumerable<ITemplateSheet>
    {
        ITemplateSheet Add(string sheetName);
    }
}
