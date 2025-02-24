using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Prelude.Algebra;

public static class AdditiveSemigroup
{
    public static T Add<T>(T left, T right)
        where T : notnull, IAdditiveSemigroup<T>
    {
        return left + right;
    }
}