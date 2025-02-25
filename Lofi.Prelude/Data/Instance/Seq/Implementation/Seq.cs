using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Prelude.Data.Instance.Seq.Implementation;

internal sealed record Seq<T>(
    IEnumerable<T> Enumerable)
    : ISeq<T>
    where T : notnull;