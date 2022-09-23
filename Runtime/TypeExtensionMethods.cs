using System;

namespace Kogane
{
    public static class TypeExtensionMethods
    {
        public static bool IsNullable( this Type self )
        {
            return Nullable.GetUnderlyingType( self ) != null;
        }
    }
}