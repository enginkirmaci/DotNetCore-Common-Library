using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Linq;

namespace Common.Web.IO
{
    public class FormUpload
    {
        private static string UploadDestination { get; set; }

        private static string[] AllowedExtensions { get; set; }

        public FormUpload(string webRootPath)
        {
            //upload config
            AllowedExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
            UploadDestination = webRootPath + "\\data\\";
        }

        private bool VerifyFileExtension(string path)
        {
            return AllowedExtensions.Contains(Path.GetExtension(path));
        }

        private bool VerifyFileSize(IFormFile file)
        {
            double fileSize = 0;
            using (var reader = file.OpenReadStream())
            {
                //get filesize in kb
                fileSize = (reader.Length / 1024);
            }

            //filesize less than 1MB => true, else => false
            return (fileSize < 1024) ? true : false;
        }

        public void RemoveFile(string filename, string folder)
        {
            File.Delete(Path.Combine(UploadDestination, folder, filename));
        }

        public BaseResult<string> SaveFile(IFormFile file, string filename, string folder)
        {
            var result = ResultFactory.Create(string.Empty);

            if (file.ContentDisposition != null)
            {
                //parse uploaded file
                var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var orginalFilename = parsedContentDisposition.FileName.Trim('"');
                var fileExtension = Path.GetExtension(orginalFilename);
                result.Object = filename + fileExtension;
                string uploadPath = Path.Combine(UploadDestination, folder, result.Object);

                //check extension
                bool extension = this.VerifyFileExtension(uploadPath);
                if (extension == false)
                {
                    result.ResolveError("7000", "Desteklenmeyen bir resim dosyası seçtiniz. Lütfen .jpg, .png yada .gif formatında bir dosya seçiniz.");
                    return result;
                }

                //check file size
                bool filesize = this.VerifyFileSize(file);
                if (filesize == false)
                {
                    result.ResolveError("7001", "Dosya boyutu 1mb tan fazla olamaz. Lütfen boyutu daha 1mb altında bir dosya seçiniz.");
                    return result;
                }

                //save the file to upload destination
                file.CopyTo(new FileStream(uploadPath, FileMode.Create));
            }

            return result;
        }
    }
}