using Functional.Foldables;
using Functional.HigherKindedTypes;
using Functional.Monads;
using Functional.Traversables;

namespace Functional.List;

/// <summary>
/// 
/// </summary>
public interface IList :
    IMonad<IList>,
    ITraversable<IList>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<IList, T>
        IMonad<IList>.MReturn<T>(T item)
        => List.Of(item);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<IList, T2>
        IMonad<IList>.SelectMany<T1, T2>(
            ITypeConstructor<IList, T1> list,
            Func<T1, ITypeConstructor<IList, T2>> selector)
        => list switch
        {
            IAppend<T1> { Head: var head, Tail: var tail} =>
                head.SelectMany(selector)
                    .ToList()
                    .Concat(
                        selector(tail)
                            .ToList()),
            _ => List.Empty<T2>()
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="init"></param>
    /// <param name="aggregator"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static T2 IFoldable<IList>.AggregateRight<T1, T2>(
        ITypeConstructor<IList, T1> list,
        T2 init,
        Func<T1, T2, T2> aggregator)
        => list switch
        {
            IAppend<T1> { Head: var head, Tail: var tail} =>
                aggregator(
                    tail, 
                    head.AggregateRight(
                        init, 
                        aggregator)),
            _ => init
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="f"></param>
    /// <typeparam name="TF"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<TF, ITypeConstructor<IList, T2>>
        ITraversable<IList>.Traverse<TF, T1, T2>(
            ITypeConstructor<IList, T1> list,
            Func<T1, ITypeConstructor<TF, T2>> f)
        => list.AggregateRight(
            TF.Pure(List.Empty<T2>()), 
            (x, ys) => 
                TF.Lift(
                    ys, 
                    f(x), 
                    List.Append));
}