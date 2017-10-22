using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyWoodenHouse.Common
{
    public class FileUploadHelper
    {
        private readonly HttpPostedFileBase file;
        
        public FileUploadHelper(HttpPostedFileBase file, string[] allowedFileExtensions, int maxSize = 1, bool isImage = true)
        {
            // TODO validate with Guard
            //Guard.

            this.file = file;
            this.AllowedFileExtensions = allowedFileExtensions;
            this.MaxSize = maxSize;
            this.IsImage = isImage;
        }

        public string[] AllowedFileExtensions { get; private set; }

        public int MaxSize { get; private set; }

        public bool IsImage { get; private set; }

        public string UploadFileToLocalServer(string folderPath)
        {
            this.ValidateFile();

            string fileNameWithExtension = Path.GetFileName(this.file.FileName);
            string newFileName = Guid.NewGuid().ToString() + "_" + fileNameWithExtension;
            string uploadPath = folderPath + newFileName;
            
            this.file.SaveAs(uploadPath);

            return newFileName;
        }

        public Tuple<int, int> GetImageDimension()
        {
            Stream stream = this.file.InputStream;
            Image image = Image.FromStream(stream);

            int height = image.Height;
            int width = image.Width;

            if (width < 0 || height < 0)
            {
                return Tuple.Create(-1, -1);
            }

            return Tuple.Create(width, height); ;
        }

        public void ValidateFile()
        {
            if (this.file.ContentLength > this.MaxSize)
            {
                string errorMessageFileSize = "Please use a file with a size less than 10 MB";
                throw new ArgumentOutOfRangeException(errorMessageFileSize);
            }

            string fileExtension = Path.GetExtension(file.FileName);
            if (!this.AllowedFileExtensions.Contains(fileExtension))
            {
                string errorMessageExtensions = "This site does not support any other file format than " + string.Join(", ", this.AllowedFileExtensions) + ". Please, select file in one of these file formats then try again.";
                throw new FileLoadException(errorMessageExtensions);
            }
        }

       
    }
}
