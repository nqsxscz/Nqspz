using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Prelude.Numeric;

public static class Natural
{
    public static T ToNatural<T>(this int n)
        where T : INatural<T>
        => T.FromInt(n);
}