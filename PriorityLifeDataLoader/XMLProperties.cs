using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeDataLoader
{
    public class XMLProperties
    {
        public string CarrierName { get; set; }
        public string Extention { get; set; }
        public string DlType { get; set; }
        public int TableRowLine { get; set; }
        public Dictionary<string, ColumnPolicy> Columns { get; set; }

        public XMLProperties()
        {
            Columns = new Dictionary<string, ColumnPolicy>();
        }

        public void Clear()
        {
            CarrierName = "";
            Extention = "";
            Columns = new Dictionary<string, ColumnPolicy>();
        }
    }
    public class ColumnPolicy
    {
        public string ExtractedColumn { get; set; }
        public List<string> Dos { get; set; }
        public List<string> Dont { get; set; }
        public ColumnPolicy()
        {
            Dos = new List<string>();
            Dont = new List<string>();
        }
        public void Clear()
        {
            Dos = new List<string>();
            Dont = new List<string>();
        }
    }
}
