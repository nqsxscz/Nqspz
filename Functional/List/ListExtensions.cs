using Functional.Foldables;
using Functional.HigherKindedTypes;

namespace Functional.List;

/// <summary>
/// 
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IList<T> ToList<T>(
        this ITypeConstructor<IList, T> list)
        where T : notnull
        => (IList<T>) list;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IList<T> ToList<T>(this T item)
        where T : notnull
        => List.Of(item);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="item"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IList<T> Append<T>(
        this IList<T> list, 
        T item)
        where T : notnull
        => List.Append(
            list, 
            item);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IList<T> Concat<T>(
        this IList<T> left,
        IList<T> right)
        => right.AggregateRight(
            left, 
            List.Append);
}