using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PriorityLifeLoader.AzureFunction
{
    public class PatternXML
    {
        private Dictionary<string, string[]> _pattern;
        internal PatternXML()
        {
            //string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            //string Filename = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/nyk_pattern_version_1.xml";
            _pattern = new Dictionary<string, string[]>();
            List<string> items = new List<string>();
            string stringXML = Properties.Resources.datatype;
            using (XmlReader reader = XmlReader.Create(new StringReader(stringXML)))
            {
                string curKey = "";
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "patternkey")
                            {
                                curKey = reader["name"];
                            }
                            break;
                        case XmlNodeType.Text:
                            items.Add(reader.Value.Trim());
                            break;
                        case XmlNodeType.EndElement:
                            if (reader.Name == "patternkey")
                            {
                                _pattern.Add(curKey, items.ToArray());
                                items.Clear();
                            }
                            break;
                    }
                }
            }
        }

    }
}
