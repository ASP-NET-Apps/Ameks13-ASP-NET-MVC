using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Models.Constants.Models
{
    public static partial class Consts
    {
        public struct Building
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Building Id value should be positive integer numnber.";
            }
        };

        public struct Category
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Category Id value should be positive integer numnber.";
            }

            public struct Name
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Category name length should be less than " + "50" + " symbols.";
                public const string ErrorMessageMinLength = "Category name length should be more than " + "2" + " symbols.";
            }
        };

        public struct Material
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Material Id value should be positive integer numnber.";
            }

            public struct Name
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Material name length should be less than " + "50" + " symbols.";
                public const string ErrorMessageMinLength = "Material name length should be more than " + "2" + " symbols.";
            }

            public struct Description
            {
                public const int MaxLength = 500;
                public const string ErrorMessageMaxLength = "Material name length should be less than " + "500" + " symbols.";
            }

        };

        public struct Picture
        {
            public struct Width
            {
                public const int MaxValue = 5000;
                public const int MinValue = 0;
                public const string ErrorMessage = "Picture Width value should be positive integer numnber and not more than 5000 px.";
            }

            public struct Height
            {
                public const int MaxValue = 5000;
                public const int MinValue = 0;
                public const string ErrorMessage = "Picture Height value should be positive integer numnber and not more than 5000 px.";
            }

            public struct PictureUrl
            {
                public const int MaxLength = 150;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Picture PictureUrl length should be less than " + "150" + " symbols.";
                public const string ErrorMessageMinLength = "Picture PictureUrl length should be more than " + "2" + " symbols.";
            }
        };

        public struct PriceCategory
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "PriceCategory Id value should be positive integer numnber.";
            }

            public struct Name
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "PriceCategory name length should be less than " + "50" + " symbols.";
                public const string ErrorMessageMinLength = "PriceCategory name length should be more than " + "2" + " symbols.";
            }

        };
    }
}
