using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeMacro.Models
{
    public class CommissionsFile
    {
        public int CarrierId { get; set; }
        public DateTime ExtractedDate { get; set; }
        public string FileUrl { get; set; }
        public string Extension { get; set; }
        public bool Active { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
