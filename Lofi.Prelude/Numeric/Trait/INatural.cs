using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Prelude.Numeric.Trait;

public interface INatural<T> : 
    IField<T>,
    IOrderable<T>
    where T : INatural<T>
{
    static abstract T FromInt(int n);
}