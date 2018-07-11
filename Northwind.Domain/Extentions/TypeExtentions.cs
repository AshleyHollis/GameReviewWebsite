using System;
using System.Reflection;

namespace Northwind.Domain.Extentions
{
    public static class TypeExtentions
    {
        public static bool HasProperty(this Type obj, string propertyName)
        {
            return obj.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }
    }
}