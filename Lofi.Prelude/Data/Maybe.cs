using Lofi.Prelude.Control;
using Lofi.Prelude.Data.Instance.Maybe;
using Lofi.Prelude.Data.Instance.Maybe.Implementation;
using Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data;

/// <summary>
/// </summary>
public static class Maybe
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> Nothing<T>()
        where T : notnull
    {
        return new Nothing<T>();
    }

    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> Of<T>(T value)
        where T : notnull
    {
        return new Just<T>(value);
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool IsEmpty<T>(this IMaybe<T> maybe)
    {
        return maybe is INothing<T>;
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool IsNotEmpty<T>(this IMaybe<T> maybe)
    {
        return !maybe.IsEmpty();
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> ToMaybe<T>(
        this ITypeConstructor<IMaybe, T> maybe)
        where T : notnull
    {
        return (IMaybe<T>)maybe;
    }

    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> ToMaybe<T>(this T value)
        where T : notnull
    {
        return Of(value);
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="f"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> OrElse<T>(
        this IMaybe<T> maybe,
        Func<IMaybe<T>> f)
        where T : notnull
    {
        return maybe switch
        {
            IJust<T> just =>
                just.Value
                    .ToMaybe(),
            _ =>
                f()
        };
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="other"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> OrElse<T>(
        this IMaybe<T> maybe,
        IMaybe<T> other)
        where T : notnull
    {
        return maybe.OrElse(
            () => other);
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="f"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T OrElse<T>(
        this IMaybe<T> maybe,
        Func<T> f)
        where T : notnull
    {
        return maybe switch
        {
            IJust<T> just =>
                just.Value,
            _ =>
                f()
        };
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="other"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T OrElse<T>(
        this IMaybe<T> maybe,
        T other)
        where T : notnull
    {
        return maybe.OrElse(
            () => other);
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> ToEnumerable<T>(this IMaybe<T> maybe)
    {
        return maybe
            .Select(t => Enumerable.Repeat(t, 1))
            .ToMaybe()
            .OrElse([]);
    }

    /// <summary>
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> MaybeFirst<T>(this IEnumerable<T> enumerable)
    {
        var ts = enumerable
            .Take(1)
            .ToArray();
        return ts.Length == 0
            ? Nothing<T>()
            : ts.First()
                .ToMaybe();
    }

    /// <summary>
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> MaybeLast<T>(this IEnumerable<T> enumerable)
    {
        return enumerable
            .TakeLast(1)
            .MaybeFirst();
    }

    /// <summary>
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="index"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> MaybeGet<T>(
        this IEnumerable<T> enumerable,
        int index)
    {
        return enumerable
            .Take(index)
            .MaybeLast();
    }

    /// <summary>
    /// </summary>
    /// <param name="f"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static Func<IMaybe<T1>, IMaybe<T2>, IMaybe<T3>>
        Lift<T1, T2, T3>(Func<T1, T2, T3> f)
    {
        return (left, right)
            => left
                .Lift(right, f)
                .ToMaybe();
    }
}