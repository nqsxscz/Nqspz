namespace Lofi.Prelude.Algebra.Trait.Additive;

public interface IAdditiveGroup<T> :
    IAdditiveMonoid<T>,
    IGroup<T>
    where T : IAdditiveGroup<T>
{
    static abstract T operator -(T operand);
    
    static virtual T operator -(T left, T right)
        => left + -right;
    
    static T IGroup<T>.Invert(T operand)
        => -operand;
}