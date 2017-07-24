using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Net.Http;

namespace Common.Web.IO
{
    static public class IFormFileExtension
    {
        static public string GetExtension(this IFormFile file)
        {
            var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var orginalFilename = parsedContentDisposition.FileName.Trim('"');
            var fileExtension = Path.GetExtension(orginalFilename);
            return fileExtension;
        }

        static public StreamContent ToStreamContent(this IFormFile file)
        {
            var stream = file.OpenReadStream();
            var memoryStream = new MemoryStream();

            stream.CopyTo(memoryStream);
            memoryStream.Position = 0;

            var streamContent = new StreamContent(memoryStream);

            return streamContent;
        }

        static public bool VerifyFileSize(this IFormFile file, int maxFileSize = 1024)
        {
            var fileSize = 0.0;
            using (var reader = file.OpenReadStream())
            {
                //get filesize in kb
                fileSize = (reader.Length / maxFileSize);
            }

            //filesize less than 1MB => true, else => false
            return (fileSize < maxFileSize) ? true : false;
        }
    }
}