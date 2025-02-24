using System.Collections;
using Lofi.Prelude.Data.Instance.Seq.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Instance.Seq;

public interface ISeq<out T> :
    ITypeConstructor<ISeq, T>,
    IEnumerable<T>
    where T : notnull
{
    IEnumerable<T> Enumerable { get; }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return Enumerable.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}