using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace PriorityLifeMacro
{
    public enum PatternType
    {
        PATH = 0,
        EXTENSION = 1,
        BROWSER = 2,
        DOWNLOADPATH = 3,
        ESTIMATE_TIMEOUT = 4
    }
    public class PatternXML
    {
        private Dictionary<string, string[]> _pattern;
        internal PatternXML()
        {
            _pattern = new Dictionary<string, string[]>();
            List<string> items = new List<string>();
            string stringXML = Properties.Resources.macro_pattern_version_1_0;
            using (XmlReader reader = XmlReader.Create(new StringReader(stringXML)))
            {
                string curKey = "";
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if( reader.Name == "pattern")
                            {
                                curKey = reader["name"];
                            }
                            break;
                        case XmlNodeType.Text:
                            items.Add(reader.Value.Trim());
                            break;
                        case XmlNodeType.EndElement:
                            if(reader.Name == "pattern")
                            {
                                _pattern.Add(curKey, items.ToArray());
                                items.Clear();
                            }
                            break;
                    }
                }
            }
        }
        protected string GetPattern( Carrier carrier, PatternType patternType)
        {
            if( carrier == Carrier.AMERICO)
            {
                return AMERICO_PATTERN[(int)patternType];
            }
            else if( carrier == Carrier.AIG)
            {
                return AIG_PATTERN[(int)patternType];
            }
            else if( carrier == Carrier.MOO)
            {
                return MOO_PATTERN[(int)patternType];
            }
            else if( carrier == Carrier.ROYAL)
            {
                return ROYAL_PATTERN[(int)patternType];
            }else if( carrier == Carrier.GLOBAL)
            {
                return GLOBAL_PATTERN[(int)patternType];
            }
            else if( carrier == Carrier.AMAM)
            {
                return AMAM_PATTERN[(int)patternType];
            }
            return "";
        }


        private string[] AMERICO_PATTERN
        {
            get
            {
                return _pattern["americo"];
            }
        }
        private string[] MOO_PATTERN
        {
            get
            {
                return _pattern["moo"];
            }
        }
        private string[] AIG_PATTERN
        {
            get
            {
                return _pattern["aig"];
            }
        }
        private string[] ROYAL_PATTERN
        {
            get
            {
                return _pattern["royal"];
            }
        }
        private string[] GLOBAL_PATTERN
        {
            get
            {
                return _pattern["global"];
            }
        }
        private string[] AMAM_PATTERN
        {
            get
            {
                return _pattern["amam"];
            }
        }
    }
}
