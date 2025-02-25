using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Trait;

public interface ISampleable<TC>
    where TC : ISampleable<TC>
{
    static abstract ISeq<T> Sample<T>(
        ITypeConstructor<TC, T> sampleable)
        where T : notnull;
}