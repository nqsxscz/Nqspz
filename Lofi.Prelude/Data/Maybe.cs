using Lofi.Prelude.Control;
using Lofi.Prelude.Data.Instance.Maybe.Implementation;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data;

public static class Maybe
{
    public static IMaybe<T> Nothing<T>()
        where T : notnull
        => new Nothing<T>();

    public static IMaybe<T> Of<T>(T t)
        where T : notnull
        => new Just<T>(t);

    public static IMaybe<T> ToMaybe<T>(this T t)
        where T : notnull
        => Of(t);
    
    public static IMaybe<T> ToMaybe<T>(
        this ITypeConstructor<IMaybe, T> maybe)
        where T : notnull
        => (IMaybe<T>) maybe;

    public static IMaybe<T> OrElse<T>(
        this IMaybe<T> maybe,
        Func<IMaybe<T>> other)
        where T : notnull
        => maybe switch
        {
            IJust<T> just =>
                just.Value
                    .ToMaybe(),
            _ =>
                other()
        };

    public static IMaybe<T> OrElse<T>(
        this IMaybe<T> maybe,
        IMaybe<T> other)
        where T : notnull
        => maybe.OrElse(
            () => other);

    public static T OrElse<T>(
        this IMaybe<T> maybe,
        Func<T> @default)
        where T : notnull
        => maybe switch
        {
            IJust<T> just =>
                just.Value,
            _ =>
                @default()
        };

    public static T OrElse<T>(
        this IMaybe<T> maybe,
        T @default)
        where T : notnull
        => maybe.OrElse(
            () => @default);
    
    public static bool IsEmpty<T>(this IMaybe<T> maybe)
        => maybe is INothing<T>;

    public static bool IsNotEmpty<T>(this IMaybe<T> maybe)
        => !maybe.IsEmpty();

    public static IEnumerable<T> ToEnumerable<T>(this IMaybe<T> maybe)
        => maybe
            .Select(t => Enumerable.Repeat(t, 1))
            .ToMaybe()
            .OrElse([]);

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

    public static IMaybe<T> MaybeLast<T>(this IEnumerable<T> enumerable)
        => enumerable
            .TakeLast(1)
            .MaybeFirst();

    public static IMaybe<T> MaybeGet<T>(
        this IEnumerable<T> enumerable,
        int index)
        => enumerable
            .Take(index)
            .MaybeLast();

    public static Func<IMaybe<T1>, IMaybe<T2>, IMaybe<T3>>
        Lift<T1, T2, T3>(Func<T1, T2, T3> f)
        => (left, right)
            => left
                .Lift(right, f)
                .ToMaybe();
}