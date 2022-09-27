using System;
using System.Collections.Generic;
using System.Linq;

namespace Kogane
{
    /// <summary>
    /// Type 型の拡張メソッドを管理するクラス
    /// </summary>
    public static class TypeExtensionMethods
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// nullable の場合 true を返します
        /// </summary>
        public static bool IsNullable( this Type self )
        {
            return Nullable.GetUnderlyingType( self ) != null;
        }

        /// <summary>
        /// 指定された基底クラスを継承しているもしくはインターフェイスを実装している場合 true を返します
        /// </summary>
        public static bool IsInherits( this Type self, Type baseOrInterfaceType )
        {
            if ( self == null ) return false;
            if ( baseOrInterfaceType == null ) return self.IsInterface || self == typeof( object );
            if ( baseOrInterfaceType.IsInterface ) return self.GetInterfaces().Contains( baseOrInterfaceType );

            var currentType = self;

            while ( currentType != null )
            {
                if ( currentType.BaseType == baseOrInterfaceType ) return true;
                currentType = currentType.BaseType;
            }

            return false;
        }

        /// <summary>
        /// 継承しているすべての基底クラスと実装しているすべてのインターフェイスの Type を返します
        /// </summary>
        public static IEnumerable<Type> GetParentTypes( this Type self )
        {
            if ( self == null ) yield break;

            foreach ( var x in self.GetInterfaces() )
            {
                yield return x;
            }

            var currentBaseType = self.BaseType;

            while ( currentBaseType != null )
            {
                yield return currentBaseType;
                currentBaseType = currentBaseType.BaseType;
            }
        }
    }
}