using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PriorityLifeMacro.Helper;
using PriorityLifeMacro.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityLifeMacro
{
    public class BlobStore : IDisposable
    {
        private CloudStorageAccount StorageAccount;
        private CloudBlobClient BlobClient;

        public BlobStore()
        {
            StorageAccount = CloudStorageAccount.Parse( ConfigurationManager.AppSettings["BlobConnectionString"] );
            BlobClient = StorageAccount.CreateCloudBlobClient();
        }

        public async Task<bool> UploadFile(CarrierInfo carrier, string FileInput, string BlobPath)
        {
            try
            {
                if(Path.GetExtension(FileInput) == ".xml" || Path.GetExtension(FileInput) == ".xlsx")
                {
                    CloudBlobContainer blobContainer = BlobClient.GetContainerReference("azure-prioritylife");
                    CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(carrier.ShortName + "_" + Guid.NewGuid().ToString() + Path.GetExtension(FileInput));

                    if (Path.GetExtension(FileInput) == ".xml")
                    {
                        blockBlob.Properties.ContentType = "application/xml";
                    }
                    else if (Path.GetExtension(FileInput) == ".xlsx")
                    {
                        blockBlob.Properties.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    }
                    using (var fileStream = File.OpenRead(FileInput))
                    {
                        await blockBlob.UploadFromStreamAsync(fileStream);
                    }
                    var commissionsFile = new CommissionsFile()
                    {
                        CarrierId = carrier.Id,
                        ExtractedDate = DateTime.Now,
                        FileUrl = blockBlob.Uri.ToString(),
                        Extension = Path.GetExtension(FileInput),
                        Active = true,
                        AddedBy = ConfigurationManager.AppSettings["AdminEmail"],
                        AddedDate = DateTime.Now
                    };
                    await HttpUtility.UploadCommissionsFileInfo(commissionsFile);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception e)
            {
                Error.CreateExceptionLog(e, Constant.FILEUPLOAD_LOGS_DIR);
                return false;
            }
        }

        public void Dispose()
        {
            StorageAccount = null;
            BlobClient = null;
        }
    }
}
