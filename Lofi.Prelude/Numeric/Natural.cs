using Lofi.Prelude.Data.Numeric.Instance;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Prelude.Numeric;

public static class Natural
{
    public static NaturalNumber ToNatural(this int n)
        => n.ToNatural<NaturalNumber>();
    
    public static T ToNatural<T>(this int n)
        where T : INatural<T>
        => T.FromInt(n);
}