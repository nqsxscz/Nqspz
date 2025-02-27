using MathNet.Numerics.Distributions;

using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Sample.Type;

public interface IMathNetStandardNormalSampler
    : IStandardNormalSampler
{
    ISeq<T> IStandardNormalSampler.Sample<T>(int seed)
        => Normal
            .Samples(
                new System.Random(seed),
                0,
                1)
            .Select(T.FromDouble)
            .ToSeq();
}