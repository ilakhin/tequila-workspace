using System;
using System.Reflection;

namespace IL.Tequila
{
    public static class CustomAttributeProviderExtensions
    {
        public static bool IsDefined<TAttribute>(this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            return provider.IsDefined(typeof(TAttribute), inherit);
        }
    }
}
