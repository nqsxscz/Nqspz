using Lofi.Prelude.Data.Control.Instance.Seq.Type;

namespace Lofi.Prelude.Data.Control.Instance.Seq.Implementation;

internal sealed record Seq<T>(
    IEnumerable<T> Enumerable)
    : ISeq<T>;