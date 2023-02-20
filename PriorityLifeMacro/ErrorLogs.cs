using PriorityLifeMacro.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PriorityLifeMacro
{
    [XmlRoot("marcrologs")]
    public class ErrorLogs
    {
        [XmlElement("details")]
        public List<ErrorDetails> ErrorDetails;
        public ErrorLogs()
        {
            ErrorDetails = new List<ErrorDetails>();
        }
    }

    [XmlRoot("log")]
    public class ErrorDetails
    {
        [XmlElement("Type")]
        public string Type { get; set; }
        [XmlElement("Message")]
        public string Message { get; set; }
    }

    public static class Error
    {
        public static void CreateExceptionLog(Exception exception, string Path)
        {
            var properties = exception.GetType()
                                    .GetProperties();
            var fields = properties
                             .Select(property => new {
                                 Name = property.Name,
                                 Value = property.GetValue(exception, null)
                             })
                             .Select(x => String.Format(
                                 "{0} = {1}",
                                 x.Name,
                                 x.Value != null ? x.Value.ToString() : String.Empty
                             ));
            string exceptionText = String.Join("\n", fields);
            //Create Logs File
            var dateNow = DateTime.Now;
            File.WriteAllText(Path + "/" + dateNow.ToString("MM dd yyyy hh mm ss ") + Guid.NewGuid().ToString() + ".txt", exceptionText);
        }
    }
}
