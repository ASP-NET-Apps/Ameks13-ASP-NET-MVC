using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Constants
{
    //public static class ImageUploadConfiguration
    //{
    //    // TODO extract to config
    //    public static string[] AllowedPictureExtensions = new string[] { ".Jpg", ".png", ".jpg", "jpeg" };

    //    // TODO extract to config
    //    public const int MaxSizeInBytes = 10000000;

    //    // TODO extract to config
    //    public const string ImageUploadPath = "/Assets/Upload/Images/";
    //}


    public static partial class GlobalConsts
    {
        public struct Image
        {
            public struct UploadConfiguration
            {
                // TODO extract to config
                public static string[] AllowedPictureExtensions = new string[] { ".Jpg", ".png", ".jpg", "jpeg" };

                // TODO extract to config
                public const int MaxSizeInBytes = 10000000;

                // TODO extract to config
                public const string ImageUploadPath = "/Assets/Upload/Images/";
            }

            public struct Paths
            {
                public const string LocalResource = "/Assets/Images/";
            }

            public struct FileNames
            {
                public const string Logo = "logo.png";

                public const string NoImage = "no-image-1-600x6004-600x500.png";
            }
        }
    }
}
