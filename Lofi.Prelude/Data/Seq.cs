using Lofi.Prelude.Data.Instance.Seq;
using Lofi.Prelude.Data.Instance.Seq.Implementation;
using Lofi.Prelude.Data.Instance.Seq.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data;

public static class Seq
{
    public static ISeq<T> Empty<T>()
        where T : notnull
    {
        return Enumerable
            .Empty<T>()
            .ToSeq();
    }

    public static ISeq<T> Of<T>(T item)
        where T : notnull
    {
        return Empty<T>()
            .Append(item);
    }

    public static ISeq<T> ToSeq<T>(
        this ITypeConstructor<ISeq, T> list)
        where T : notnull
    {
        return (ISeq<T>)list;
    }

    public static ISeq<T> ToSeq<T>(this T item)
        where T : notnull
    {
        return Of(item);
    }

    public static ISeq<T> ToSeq<T>(this IEnumerable<T> ts)
        where T : notnull
    {
        return ts switch
        {
            ISeq<T> seq => seq,
            _ => new Seq<T>(ts)
        };
    }

    public static ISeq<T> Append<T>(
        this ISeq<T> seq,
        T item)
    {
        return seq.Enumerable
            .Append(item)
            .ToSeq();
    }
}