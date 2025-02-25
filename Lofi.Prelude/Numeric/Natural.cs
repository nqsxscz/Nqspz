using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Prelude.Numeric;

public static class Natural
{
    public static int ToInt<T>(this T t)
        where T : INatural<T>
        => T.ToInt(t);
    
    public static T ToNatural<T>(this int n)
        where T : INatural<T>
        => T.FromInt(n);
}