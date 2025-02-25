using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

public static class Traversable
{
    public static ITypeConstructor<TF, ITypeConstructor<TC, T2>>
        Traverse<TC, TF, T1, T2>(
            this ITypeConstructor<TC, T1> input,
            Func<T1, ITypeConstructor<TF, T2>> f)
        where TC : ITraversable<TC>
        where TF : IApplicative<TF>
        where T1 : notnull
        where T2 : notnull
        => TC.Traverse(input, f);

    public static ITypeConstructor<TF, ITypeConstructor<TC, T>>
        Sequence<TC, TF, T>(
            this ITypeConstructor<TC, ITypeConstructor<TF, T>> input)
        where TC : ITraversable<TC>
        where TF : IApplicative<TF>
        where T : notnull
        => input.Traverse(x => x);
}