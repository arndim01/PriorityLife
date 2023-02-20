using ClosedXML.Excel;
using PriorityLifeDataLoader.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader.Build
{
    public class TemplateSheet : ITemplateSheet
    {
        public TemplateSheet(string sheetName, TemplateProperties templateProperties)
        {
            SheetName = sheetName;
            
            if( templateProperties != null)
            {
                ReadLine = templateProperties.XMLProperties.TableRowLine;
                Ws = templateProperties.Workbook.Worksheet(sheetName);
                TemplateProperties = templateProperties;
            }
            else
            {
                throw new Exception();
            }
            
        }

        public string SheetName { get; private set; }
        public IXLWorksheet Ws { get; private set; }
        public int GetTotalColsUsed
        {
            get
            {
                return Ws.RangeUsed().LastColumnUsed().ColumnNumber();
            }
        }
        public int GetTotalRowsUsed
        {
            get
            {
                return Ws.LastRowUsed().RowNumber();
            }
        }
        public int ReadLine { get; private set; }
        public void NextLine()
        {
            ReadLine++;
        }
        public int CurrentLine
        {
            get
            {
                return ReadLine;
            }
        }

        public TemplateProperties TemplateProperties { get; private set; }
    }
}
