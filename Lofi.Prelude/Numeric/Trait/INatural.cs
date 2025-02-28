using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Prelude.Numeric.Trait;

public interface INatural<T> : 
    IRing<T>,
    IOrderable<T>
    where T : INatural<T>
{
    static abstract T FromInt(int n);
}