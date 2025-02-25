namespace Lofi.Prelude.Algebra.Trait.Additive;

public interface IAdditiveGroup<T> :
    IAdditiveMonoid<T>,
    IGroup<T>
    where T : notnull, IAdditiveGroup<T>
{
    static abstract T operator -(T operand);
    
    static T IGroup<T>.Invert(T operand)
        => -operand;
}