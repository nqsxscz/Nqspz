using Lofi.Prelude.Data.Instance.Seq.Implementation;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Data.Instance.Seq.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data;

public static class Seq
{
    public static ISeq<T> Empty<T>()
        where T : notnull
        => Enumerable
            .Empty<T>()
            .ToSeq();

    public static ISeq<T> Of<T>(T item)
        where T : notnull
        => Empty<T>()
            .Append(item);

    public static ISeq<T> ToSeq<T>(
        this ITypeConstructor<ISeq, T> list)
        where T : notnull
        => (ISeq<T>)list;

    public static ISeq<T> ToSeq<T>(this T item)
        where T : notnull
        => Of(item);

    public static ISeq<T> ToSeq<T>(this IEnumerable<T> ts)
        where T : notnull
        => ts switch
        {
            ISeq<T> seq => seq,
            _ => new Seq<T>(ts)
        };

    public static ISeq<T> Append<T>(
        this ISeq<T> seq,
        T item)
        => seq.Enumerable
            .Append(item)
            .ToSeq();
}