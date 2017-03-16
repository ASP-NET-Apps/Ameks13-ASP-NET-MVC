using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Extensions
{
    public static class TypeExtensions
    {
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
