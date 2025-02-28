using Lofi.Prelude.Data.Control.Instance.Seq.Implementation;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;
using Lofi.Prelude.Data.Control.Instance.Seq.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Control;

public static class Seq
{
    public static ISeq<T> Empty<T>()
        where T : notnull
        => Enumerable
            .Empty<T>()
            .ToSeq();

    public static ISeq<T> Of<T>(T t)
        where T : notnull
        => Empty<T>()
            .Append(t);

    
    public static ISeq<T> ToSeq<T>(this T t)
        where T : notnull
        => Of(t);

    public static ISeq<T> ToSeq<T>(this IEnumerable<T> ts)
        where T : notnull
        => ts switch
        {
            ISeq<T> seq => seq,
            _ => new Seq<T>(ts)
        };
    
    public static ISeq<T> ToSeq<T>(
        this ITypeConstructor<ISeq, T> seq)
        where T : notnull
        => (ISeq<T>) seq;

    public static ISeq<T> Append<T>(
        this ISeq<T> seq,
        T t)
        => seq.Enumerable
            .Append(t)
            .ToSeq();
}