# Kogane Type Extension Methods

Type の拡張メソッド

## 使用例

```csharp
Debug.Log( typeof( int ).IsNullable() );  // False
Debug.Log( typeof( int? ).IsNullable() ); // True
```