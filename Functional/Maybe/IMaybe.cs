using Functional.Foldables;
using Functional.Functors;
using Functional.HigherKindedTypes;
using Functional.Monads;
using Functional.Traversables;

namespace Functional.Maybe;

/// <summary>
/// 
/// </summary>
public interface IMaybe
    : IMonad<IMaybe>, ITraversable<IMaybe>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<IMaybe, T>
        IMonad<IMaybe>.MReturn<T>(T t)
        => Maybe.Nothing<T>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<IMaybe, T2>
        IMonad<IMaybe>.SelectMany<T1, T2>(
            ITypeConstructor<IMaybe, T1> maybe,
            Func<T1, ITypeConstructor<IMaybe, T2>> selector)
        => maybe switch
        {
            IJust<T1> { Value: var x} =>
                selector(x),
            _ => 
                Maybe.Nothing<T2>()
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="init"></param>
    /// <param name="f"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static T2 IFoldable<IMaybe>.AggregateRight<T1, T2>(
        ITypeConstructor<IMaybe, T1> maybe,
        T2 init,
        Func<T1, T2, T2> f)
        => maybe switch
        {
            IJust<T1> just =>
                f(just.Value, init),
            _ =>
                init
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="f"></param>
    /// <typeparam name="TF"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<TF, ITypeConstructor<IMaybe, T2>>
        ITraversable<IMaybe>.Traverse<TF, T1, T2>(
            ITypeConstructor<IMaybe, T1> maybe,
            Func<T1, ITypeConstructor<TF, T2>> f)
        => maybe switch
        {
            IJust<T1> { Value: var x} =>
                f(x).Select(Maybe.Of),
            _ =>
                TF.Pure(Maybe.Nothing<T2>())
        };
}