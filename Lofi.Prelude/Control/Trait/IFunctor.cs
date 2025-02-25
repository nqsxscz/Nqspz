using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

public interface IFunctor<TC>
    where TC : IFunctor<TC>
{
    static abstract ITypeConstructor<TC, T2> Select<T1, T2>(
        ITypeConstructor<TC, T1> input,
        Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull;
}