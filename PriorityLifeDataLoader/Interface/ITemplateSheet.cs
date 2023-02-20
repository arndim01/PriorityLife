using ClosedXML.Excel;
using PriorityLifeDataLoader.Build;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader.Interface
{
    public interface ITemplateSheet
    {
        TemplateProperties TemplateProperties { get; }
        string SheetName { get; }
        IXLWorksheet Ws { get; }
        int GetTotalColsUsed { get; }
        int GetTotalRowsUsed { get; }
        int ReadLine { get; }
        int CurrentLine { get; }
        void NextLine();
    }
}
