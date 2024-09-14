using System;
using System.Reflection;

namespace IL.Tequila
{
    public static class ModuleExtensions
    {
        public static bool TryGetCustomAttribute<TAttribute>(this Module module, out TAttribute attribute)
            where TAttribute : Attribute
        {
            if (!Attribute.IsDefined(module, typeof(TAttribute)))
            {
                attribute = default;

                return false;
            }

            attribute = Attribute.GetCustomAttribute(module, typeof(TAttribute)) as TAttribute;

            return true;
        }

        public static bool TryGetCustomAttribute<TAttribute>(this Module module, bool inherit, out TAttribute attribute)
            where TAttribute : Attribute
        {
            if (!Attribute.IsDefined(module, typeof(TAttribute), inherit))
            {
                attribute = default;

                return false;
            }

            attribute = Attribute.GetCustomAttribute(module, typeof(TAttribute), inherit) as TAttribute;

            return true;
        }
    }
}
