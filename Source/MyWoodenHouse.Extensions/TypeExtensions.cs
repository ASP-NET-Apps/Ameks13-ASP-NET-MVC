﻿using System;
using System.Linq;

namespace MyWoodenHouse.Extensions
{
    public static class TypeExtensions
    {
        public static bool HasPublicConstructor(this Type @type)
        {
            if (@type == null)
            {
                throw new ArgumentNullException();
            }

            bool hasPublicConstructor = @type.GetConstructors().Count() > 0;

            return hasPublicConstructor;
        }

        public static bool HasProperty(this Type @type, string propertyName)
        {
            if (@type == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Argument propertyName can not be null or empty");
            }

            bool hasProperty = @type.GetProperty(propertyName) != null;

            return hasProperty;
        }

        public static bool HasProperty(this object obj, string propertyName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Argument propertyName can not be null or empty");
            }

            bool hasProperty = obj.GetType().GetProperty(propertyName) != null;

            return hasProperty;
        }
    }
}
