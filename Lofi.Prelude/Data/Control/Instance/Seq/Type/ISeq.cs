using System.Collections;
using Lofi.Prelude.Data.Control.Instance.Seq.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Control.Instance.Seq.Type;

public interface ISeq<out T> :
    ITypeConstructor<ISeq, T>,
    IEnumerable<T>
    where T : notnull
{
    IEnumerable<T> Enumerable { get; }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => Enumerable.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}