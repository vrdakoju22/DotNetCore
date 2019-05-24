using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetCore.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static IDictionary ToDictionary(this IEnumerable<PropertyInfo> properties)
        {
            return properties?
                .Where(property => !string.IsNullOrWhiteSpace(property.GetValue(default) as string))
                .ToDictionary(property => property.Name.CamelCase(), property => property.GetValue(default) as string);
        }
    }
}
