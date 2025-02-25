using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Algebra;

public static class Group
{
    public static T Invert<T>(this T value)
        where T : notnull, IGroup<T>
        => T.Invert(value);
    
    public static T Negate<T>(this T value)
        where T : notnull, IAdditiveGroup<T>
        => -value;
    
    public static T Subtract<T>(this T left, T right)
        where T : notnull, IAdditiveGroup<T>
        => left - right;
    
    public static T Divide<T>(this T left, T right)
        where T : notnull, IMultiplicativeGroup<T>
        => left / right;
}