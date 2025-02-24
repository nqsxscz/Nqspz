using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

/// <summary>
/// </summary>
public static class Traversable
{
    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="f"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="TF"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static ITypeConstructor<TF, ITypeConstructor<TC, T2>>
        Traverse<TC, TF, T1, T2>(
            this ITypeConstructor<TC, T1> input,
            Func<T1, ITypeConstructor<TF, T2>> f)
        where TC : ITraversable<TC>
        where TF : IApplicative<TF>
        where T1 : notnull
        where T2 : notnull
    {
        return TC.Traverse(input, f);
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="TF"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ITypeConstructor<TF, ITypeConstructor<TC, T>>
        Sequence<TC, TF, T>(
            this ITypeConstructor<TC, ITypeConstructor<TF, T>> input)
        where TC : ITraversable<TC>
        where TF : IApplicative<TF>
        where T : notnull
    {
        return input.Traverse(x => x);
    }
}