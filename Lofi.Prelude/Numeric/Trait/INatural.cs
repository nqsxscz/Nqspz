using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Numeric.Trait;

public interface INatural<T> : 
    IAdditiveGroup<T>,
    IMultiplicativeGroup<T>,
    IOrderable<T>
    where T : notnull, INatural<T>
{
    static abstract int ToInt(T t);
    
    static abstract T FromInt(int i);
}