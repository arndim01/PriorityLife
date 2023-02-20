using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeMacro.Interface
{
    public interface IMacroBrowser
    {
        CarrierInfo Carrier { get; }
        ErrorLogs ErrorLogs { get; }
        void SetCarrier(CarrierInfo carrier);
        void Play();
        void CleanFiles();
        void TransferFiles();
        Task UploadToBlobStorage();
        void CreateLogs();
        void Stop();
    }
}
