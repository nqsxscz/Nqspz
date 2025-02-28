using MathNet.Numerics.Distributions;

using Lofi.Prelude.Data.Control;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Sample.Type;

public interface IMathNetStandardNormalSampler
    : IStandardNormalSampler
{
    ISeq<T> IStandardNormalSampler.Sample<T>(int seed)
        => Normal
            .Samples(
                new Random(seed),
                0,
                1)
            .Select(T.FromDouble)
            .ToSeq();
}