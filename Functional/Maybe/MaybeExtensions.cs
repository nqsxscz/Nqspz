using Functional.HigherKindedTypes;

namespace Functional.Maybe;

/// <summary>
/// 
/// </summary>
public static class MaybeExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="maybe"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> Coerce<T>(
        this ITypeConstructor<IMaybe, T> maybe)
        => (IMaybe<T>) maybe; 
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> ToMaybe<T>(this T value)
        => Maybe.Of(value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="f"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> OrElse<T>(
        this IMaybe<T> maybe,
        Func<IMaybe<T>> f)
        => maybe switch
        {
            IJust<T> just =>
                just.Value
                    .ToMaybe(),
            _ =>
                f(),
        };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="other"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> OrElse<T>(
        this IMaybe<T> maybe,
        IMaybe<T> other)
        => maybe.OrElse(
            () => other);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="f"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T OrElse<T>(
        this IMaybe<T> maybe,
        Func<T> f)
        => maybe switch
        {
            IJust<T> just =>
                just.Value,
            _ =>
                f(),
        };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="other"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T OrElse<T>(
        this IMaybe<T> maybe,
        T other)
        => maybe.OrElse(
            () => other);
}