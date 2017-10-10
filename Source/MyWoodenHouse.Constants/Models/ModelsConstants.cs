using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Constants.Models
{
    public static partial class Consts
    {
        public struct Building
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Building Id value should be positive integer number.";
            }
        };

        public struct Category
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Category Id value should be positive integer number.";
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
                public const string ErrorMessage = "Material Id value should be positive integer number.";
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
                public const string ErrorMessageMaxLength = "Material description length should be less than " + "500" + " symbols.";
            }

        };

        public struct Picture
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Picture Id value should be positive integer number.";
            }

            public struct Name
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Picture name length should be less than " + "50" + " symbols.";
                public const string ErrorMessageMinLength = "Picture name length should be more than " + "2" + " symbols.";
            }

            public struct Width
            {
                public const int MaxValue = 5000;
                public const int MinValue = 0;
                public const string ErrorMessage = "Picture Width value should be positive integer number and not more than 5000 px.";
            }

            public struct Height
            {
                public const int MaxValue = 5000;
                public const int MinValue = 0;
                public const string ErrorMessage = "Picture Height value should be positive integer number and not more than 5000 px.";
            }

            public struct Url
            {
                public const int MaxLength = 250;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Picture Url length should be less than " + "250" + " symbols.";
                public const string ErrorMessageMinLength = "Picture Url length should be more than " + "2" + " symbols.";
            }

            public struct GetFrom
            {
                public const int MaxValue = 10;
                public const int MinValue = 1;
                public const string ErrorMessage = "Picture GetFrom value should be positive integer number .";
            }
        };

        public struct Product
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Product Id value should be positive integer number.";
            }

            public struct Name
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Product name length should be less than " + "50" + " symbols.";
                public const string ErrorMessageMinLength = "Product name length should be more than " + "2" + " symbols.";
            }

            public struct Description
            {
                public const int MaxLength = 500;
                public const string ErrorMessageMaxLength = "Product description length should be less than " + "500" + " symbols.";
            }

        };

        public struct Price
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Price Id value should be positive integer number.";
            }

            public struct Value
            {
                public const float MaxValue = float.MaxValue;
                public const float MinValue = 1;
                public const string ErrorMessage = "Price Value value should be positive.";
            }

            public struct Currency
            {
                public const int MaxLength = 10;
                public const int MinLength = 1;
                public const string ErrorMessageMaxLength = "Price Currency length should be less than " + "10" + " symbols.";
                public const string ErrorMessageMinLength = "Price Currency length should be more than " + "1" + " symbols.";
            }

            public struct PerSquareMeter
            {
                public const float MaxValue = float.MaxValue;
                public const float MinValue = 1;
                public const string ErrorMessage = "Price PerSquareMeter value should be positive.";
            }

            public struct PriceCategoryId
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Price PriceCategoryId value should be positive integer number.";
            }

        };

        public struct PriceCategory
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "PriceCategory Id value should be positive integer number.";
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
