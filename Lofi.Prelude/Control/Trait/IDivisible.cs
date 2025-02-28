using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

public interface IDivisible<TC>
    : IContravariant<TC>
    where TC : IDivisible<TC>
{
    static abstract ITypeConstructor<TC, T> Conquer<T>()
        where T : notnull;
    
    static abstract ITypeConstructor<TC, T1>
        Divide<T1, T2, T3>(
            ITypeConstructor<TC, T2> left,
            ITypeConstructor<TC, T3> right,
            Func<T1, (T2, T3)> divider)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}