using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Constants
{
    public static class ImageUploadConfiguration
    {
        public static string[] AllowedPictureExtensions = new string[] { ".Jpg", ".png", ".jpg", "jpeg" };

        public static int MaxSizeInBytes = 10000000;
    }
}
