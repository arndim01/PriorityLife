using PriorityLifeMacro.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeMacro
{

    public enum Carrier
    {
        AMERICO = 0,
        AIG = 1,
        MOO = 2,
        ROYAL = 3,
        GLOBAL = 4,
        AMAM = 5,
        NULL = 6
    }
    public enum DownloadType
    {
        Bulk = 0,
        InputDate = 1
    }
    public class CarrierInfo : PatternXML
    {
        public int Id { get; set; }
        public Carrier Carrier { get; set; }
        public string ShortName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DownloadType DownloadType { get; set; }
        public CarrierInfo(int _id, Carrier _carrier, string shortName, string _username, string _password, DownloadType downloadType = DownloadType.Bulk) 
        {
            Id = _id;
            ShortName = shortName;
            Carrier = _carrier;
            Username = _username;
            Password = _password;
            DownloadType = downloadType;
        }
        public string GetPath()
        {
            return GetPattern(Carrier, PatternType.PATH);
        }
        public string GetBrowser()
        {
            return GetPattern(Carrier, PatternType.BROWSER);
        }
        public string GetExtension()
        {
            return GetPattern(Carrier, PatternType.EXTENSION);
        }
        public string GetDownloadPath()
        {
            return GetPattern(Carrier, PatternType.DOWNLOADPATH);
        }
        public int GetEstimateTimeout()
        {
            return Convert.ToInt32(GetPattern(Carrier, PatternType.ESTIMATE_TIMEOUT));
        }
        public CarrierInfo() { }

    }
}
