using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Prelude.Algebra.Trait.Multiplicative;

public interface IMultiplicativeGroup<T> :
    IMultiplicativeMonoid<T>,
    IGroup<T>
    where T : IMultiplicativeGroup<T>
{
    static virtual T operator /(T left, T right)
        => left * T.Invert(right);
    
    static virtual T Power<TNatural>(
        T left,
        TNatural right)
        where TNatural : INatural<TNatural>
        => right >= TNatural.Zero ? 
            T.Power1(left, right) 
            : 
            T.Power1(left, right)
                .Invert();
    
    protected static virtual T Power1<TNatural>(
        T left, 
        TNatural right)
        where TNatural : INatural<TNatural>
        => right.Equals(TNatural.Zero) ? 
            T.One 
            : left * T.Power1(left, right - TNatural.One);
}