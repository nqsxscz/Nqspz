using Lofi.Prelude.Data.Control.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Sample.Type;

public interface IStandardNormalSampler
{
    ISeq<T> Sample<T>(int seed)
        where T : IReal<T>;
}