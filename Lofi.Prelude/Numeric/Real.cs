using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Prelude.Numeric;

public static class Real
{
    public static double ToDouble<T>(this T t)
        where T : IReal<T>
        => T.ToDouble(t);
    
    public static T ToReal<T>(this double x)
        where T : IReal<T>
        => T.FromDouble(x);
}