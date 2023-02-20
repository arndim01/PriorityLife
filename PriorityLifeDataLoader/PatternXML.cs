using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PriorityLifeDataLoader
{
    public enum Carrier
    {
        AIG = 0,
        AMERICO = 1,
        MOO = 2,
        GLOBAL = 3,
        ROYAL = 4,
        AMAM = 5,
        ATHENE = 6,
        TRANS = 7,
        PROSPERITY = 8,
        RSHIELD = 9
    }
    public class PatternXML
    {
        List<XMLProperties> ExcelProperties { get; set; }
        public PatternXML()
        {
            ExcelProperties = new List<XMLProperties>();

            string stringXML = Properties.Resources.excel_pattern_version_1_0;
            using (XmlReader reader = XmlReader.Create(new StringReader(stringXML)))
            {
                string curKey = "";
                string curTag = "";

                XMLProperties excels = new XMLProperties();
                string extension = "";
                string dltype = "";
                string startline = "";
                string name = "";
                string item = "";

                ColumnPolicy columnPolicy = new ColumnPolicy();

                while (reader.Read())
                {

                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "pattern")
                            {
                                curKey = reader["name"];
                            }
                            if( reader.Name == "name")
                            {
                                //Console.WriteLine( reader["cl"] );
                                columnPolicy.ExtractedColumn = reader["cl"];
                            }

                            curTag = reader.Name;
                            break;
                        case XmlNodeType.Text:

                            
                            if (curTag == "extension")
                            {
                                extension = reader.Value.Trim();
                            }
                            if( curTag == "tableline")
                            {
                                startline = reader.Value.Trim();
                            }
                            if( curTag == "dltype")
                            {
                                dltype = reader.Value.Trim();
                            }

                            if (curTag == "name")
                            {
                                name = reader.Value.Trim();
                            }

                            if (curTag == "dos_item")
                            {
                                item = reader.Value.Trim();
                            }

                            if (curTag == "dont_item")
                            {
                                item = reader.Value.Trim();
                            }

                            break;
                        case XmlNodeType.EndElement:

                            if (reader.Name == "dont_item")
                            {
                                columnPolicy.Dont.Add(item);
                            }
                            if (reader.Name == "dos_item")
                            {
                                columnPolicy.Dos.Add(item);
                            }
                            if (reader.Name == "column")
                            {
                                excels.CarrierName = curKey;
                                excels.Extention = extension;
                                excels.DlType = dltype;
                                excels.TableRowLine = Convert.ToInt32(startline);
                                excels.Columns.Add(name, columnPolicy);
                                columnPolicy = new ColumnPolicy();
                            }
                            if (reader.Name == "columns")
                            {
                                ExcelProperties.Add(excels);
                            }
                            if( reader.Name == "pattern")
                            {

                                excels = new XMLProperties();
                            }
                            break;
                    }
                }

                //System.Console.WriteLine(ExcelProperties);
            }
        }
        public XMLProperties GetXMLProperties(Carrier carrier)
        {
            return ExcelProperties.ElementAt((int)carrier);
        }
    }
}
