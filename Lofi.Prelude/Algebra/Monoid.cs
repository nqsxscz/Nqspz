using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Algebra;

public static class Monoid
{
    public static T Identity<T>()
        where T : IMonoid<T>
        => T.Identity;
    
    public static T Zero<T>()
        where T : IAdditiveMonoid<T>
        => T.Zero;

    public static T One<T>()
        where T : IMultiplicativeMonoid<T>
        => T.One;
}