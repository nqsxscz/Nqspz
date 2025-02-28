using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Algebra.Trait;

public interface IField<T> :
    IRing<T>,
    IMultiplicativeGroup<T>
    where T : IField<T>
{
    static T IGroup<T>.Reciprocate(T operand)
        => -operand;
}