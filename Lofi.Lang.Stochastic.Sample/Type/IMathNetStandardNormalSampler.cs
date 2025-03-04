using System.Security.Cryptography;
using MathNet.Numerics.Distributions;

using Lofi.Prelude.Data.Control;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;
using MathNet.Numerics.Random;

namespace Lofi.Lang.Stochastic.Sample.Type;

public interface IMathNetStandardNormalSampler
    : IStandardNormalSampler
{
    ISeq<T> IStandardNormalSampler.Sample<T>(int seed, int count)
        => Sample<T>(count)
            .Take(count)
            .ToSeq();
    
    private static T[] Sample<T>(int count)
        where T : IReal<T>
        => Enumerable.Range(0, count)
            .Select(_ =>
                Sample<T>())
            .ToArray();
    
    private static T Sample<T>()
        where T : IReal<T>
    {
        
        var random = CreateSeededRandom();
        var mt = new MersenneTwister(random.Next());
        var sample = new Normal(0, 1, mt).Sample();
        return T.FromDouble(sample);
    }
    
    private static Random CreateSeededRandom()
    {
        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[4];
        rng.GetBytes(bytes);
        var seed = BitConverter.ToInt32(bytes, 0);
        return new Random(seed);
    }
}