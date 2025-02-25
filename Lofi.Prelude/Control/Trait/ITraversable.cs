using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

public interface ITraversable<TC>
    : IFunctor<TC>, IFoldable<TC>
    where TC : ITraversable<TC>
{
    static abstract ITypeConstructor<TF, ITypeConstructor<TC, T2>>
        Traverse<TF, T1, T2>(
            ITypeConstructor<TC, T1> input,
            Func<T1, ITypeConstructor<TF, T2>> f)
        where TF : IApplicative<TF>
        where T1 : notnull
        where T2 : notnull;
}