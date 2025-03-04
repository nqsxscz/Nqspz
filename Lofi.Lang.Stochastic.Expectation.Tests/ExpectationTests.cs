using System.Security.Cryptography;
using Lofi.Lang.Stochastic.Process.Continuous;
using Lofi.Lang.Stochastic.Sample;
using Lofi.Lang.Stochastic.Trajectory;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data.Control;
using Lofi.Prelude.Data.Numeric.Instance;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;
using Lofi.Prelude.Type.Constant;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;

namespace Lofi.Lang.Stochastic.Expectation.Tests;

public class ExpectationTests
{
    [Test]
    public void IID()
    {
        var count = 4;
        var samples = Sample<RealNumber>(count)
            .Select(t => t)
            .ToSeq()
            .ToTrajectory();
        var autocorrelations =
            Enumerable.Range(0, count)
                .Select(i => Autocorrelation(samples, i))
                .ToArray();
        ;
    }

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
    
    [Test]
    public void Wiener()
    {
        var wiener = StochasticProcess
            .WienerAct365<RealNumber>(0);
        
        var sampler = Sampler.EulerMaruyama();
        var evaluator = Evaluator.Montecarlo;
        var now = new DateTime(2025, 01, 01);
        var times = Enumerable
            .Range(0, 5)
            .Select(i => now.AddDays(i*10))
            .ToSeq();
        const int count = 10_000;
        var trajectories = wiener
            .Differentiate()
            .SampleMany(
                sampler, 
                times, 
                count);
        var avg = evaluator
            .Evaluate(trajectories);

        var autocorrelations =
            trajectories
                .Select(
                    trajectory => 
                        Enumerable.Range(0, times.Count() - 1)
                            .Select(i => Autocorrelation(trajectory, i))
                            .ToArray())
                .ToArray();
        
        ;
    }
    
    [Test]
    public void Forward_Gbm()
    {
        var wiener = StochasticProcess
            .WienerAct365<DualNumber<RealNumber, Three>>(0);
        var spot = 
            RealNumber
                .FromDouble(100)
                .ToVariable<Three>(1);
        var r = 
            RealNumber
                .FromDouble(.04)
                .ToVariable<Three>(2);
        var sigma = 
            RealNumber
                .FromDouble(.1)
                .ToVariable<Three>(3);
        var s = StochasticProcess
            .GeometricBrownianMotion(
                spot, 
                r, 
                sigma, 
                wiener);
        
        var sampler = Sampler.EulerMaruyama();
        var evaluator = Evaluator.Montecarlo;
        var now = new DateTime(2025, 01, 01);
        var times = Enumerable
            .Range(0, 5)
            .Select(i => now.AddDays(i*10))
            .ToSeq();
        const int count = 10_000;
        var trajectories = s
            .SampleMany(
                sampler, 
                times, 
                count);
        var dt = Act365<DualNumber<RealNumber, Three>>(
            times.Last() - times.First());
        var df = DiscountFactor(r, dt);
        var avg = evaluator
            .Evaluate(trajectories);
        var (actualNpv, actualSensitivities) = 
            df.Multiply(avg);

        var actualDelta = actualSensitivities[0];
        var actualRho = actualSensitivities[1];
        var actualVega = actualSensitivities[2];
        
        ;
    }
    
    [Test]
    public void Standard_Call_Option_Gbm()
    {
        var wiener = StochasticProcess
            .WienerAct365<DualNumber<RealNumber, Three>>(0);
        var spot = 
            RealNumber
                .FromDouble(100)
                .ToVariable<Three>(1);
        var r = 
            RealNumber
                .FromDouble(.04)
                .ToVariable<Three>(2);
        var sigma = 
            RealNumber
                .FromDouble(.1)
                .ToVariable<Three>(3);
        var s = StochasticProcess
            .GeometricBrownianMotion(
                spot, 
                r, 
                sigma, 
                wiener);
        var strike = 
            RealNumber
                .FromDouble(95)
                .ToConstant<Three>();
        var payoff = 
            s.Subtract(strike)
                .Maximum(
                    RealNumber
                        .Zero
                        .ToConstant<Three>());
        
        var sampler = Sampler.EulerMaruyama();
        var evaluator = Evaluator.Montecarlo;
        var now = new DateTime(2025, 01, 01);
        var times = Enumerable
            .Range(0, 5)
            .Select(i => now.AddDays(i*10))
            .ToSeq();
        const int count = 10_000;
        var trajectories = payoff
            .SampleMany(
                sampler, 
                times, 
                count);
        var dt = Act365<DualNumber<RealNumber, Three>>(
            times.Last() - times.First());
        var df = DiscountFactor(r, dt);
        var (actualNpv, actualSensitivities) = 
            df.Multiply(
                evaluator
                    .Evaluate(trajectories));

        var (expectedNpv, expectedSensitivities) = 
            BlackScholes(
                dt, 
                strike, 
                spot, 
                r, 
                sigma);

        var r100 = RealNumber
            .FromDouble(100);

        var actualDelta = actualSensitivities[0];
        var actualRho = actualSensitivities[1];
        var actualVega = actualSensitivities[2];
        
        var expectedDelta = expectedSensitivities[0];
        var expectedRho = expectedSensitivities[1];
        var expectedVega = expectedSensitivities[2];
        
        var errorNpv = 
            expectedNpv
                .Subtract(actualNpv)
                .Divide(expectedNpv)
                .Multiply(r100);
        var errorDelta = 
            expectedDelta
                .Subtract(actualDelta)
                .Divide(expectedDelta)
                .Multiply(r100);
        var errorRho = 
            expectedRho
                .Subtract(actualRho)
                .Divide(expectedRho)
                .Multiply(r100);
        var errorVega = 
            expectedVega
                .Subtract(actualVega)
                .Divide(expectedVega)
                .Multiply(r100);
        ;
    }

    [Test]
    public void Standard_Call_Option_Heston()
    {
        var wiener = StochasticProcess
            .WienerAct365<DualNumber<RealNumber, Three>>(0);
        var spot = 
            RealNumber
                .FromDouble(100)
                .ToVariable<Three>(1);
        var r = 
            RealNumber
                .FromDouble(.04)
                .ToVariable<Three>(2);
        var sigma = 
            RealNumber
                .FromDouble(.1)
                .ToVariable<Three>(3);
        var kappa = 
            RealNumber
                .One
                .ToConstant<Three>();
        var volvol = 
            RealNumber
                .FromDouble(.2)
                .ToConstant<Three>();
        var rho = 
            RealNumber
                .FromDouble(.1)
                .ToConstant<Three>();
        
        var s = StochasticProcess
            .Heston(
                spot,
                sigma,
                r, 
                kappa, 
                sigma,
                volvol,
                rho,
                wiener);
        var strike = 
            RealNumber
                .FromDouble(95)
                .ToConstant<Three>();
        var payoff = 
            s.Subtract(strike)
                .Maximum(
                    RealNumber
                        .Zero
                        .ToConstant<Three>());
        
        var sampler = Sampler.EulerMaruyama();
        var evaluator = Evaluator.Montecarlo;
        var now = new DateTime(2025, 01, 01);
        var times = Enumerable
            .Range(0, 5)
            .Select(i => now.AddDays(i*10))
            .ToSeq();
        const int count = 10_000;
        var trajectories = payoff
            .SampleMany(
                sampler, 
                times, 
                count);
        var dt = Act365<DualNumber<RealNumber, Three>>(
            times.Last() - times.First());
        var df = DiscountFactor(r, dt);
        var (actualNpv, sensitivities) = 
            df.Multiply(
                evaluator
                    .Evaluate(trajectories));

        var actualDelta = sensitivities[0];
        var actualRho = sensitivities[1];
        var actualVega = sensitivities[2];
        ;
    }

    private static T Autocorrelation<T>(ITrajectory<T> trajectory, int lag)
        where T : IReal<T>
    {
        var ts = trajectory.ToSeq().Enumerable.ToArray();
        var n = ts.Length;
        var mean = 
            ts.Aggregate(Semigroup.Add)
            / T.FromInt(n);
        var stddev = ts
                .Select(t => t - mean)
                .Select(t => t * t)
                .Aggregate(Semigroup.Add);
        var sum = T.Zero;
        for (var i = 0; i < n - lag; ++i)
            sum += (ts[i] - mean) * (ts[i + lag] - mean);
        return sum / stddev;
    }
    
    private static T Act365<T>(TimeSpan dt)
        where T : IReal<T>
        => T.FromDouble(dt.TotalDays / 365);
    
    private static T DiscountFactor<T>(T r, T dt)
        where T : IReal<T>
        => T.Exp(-r * dt);

    private static T BlackScholes<T>(T dt, T strike, T spot, T r, T sigma)
        where T : IReal<T>
        => spot
           * T.NormalCdf(BlackScholesD1(dt, strike, spot, r, sigma))
           - strike
           * DiscountFactor(r, dt)
           * T.NormalCdf(BlackScholesD2(dt, strike, spot, r, sigma));
    
    private static T BlackScholesD1<T>(T dt, T strike, T spot, T r, T sigma)
        where T : IReal<T>
        => (T.Log(spot / strike) + (r + sigma * sigma / T.Two) * dt) 
           / (sigma * T.Sqrt(dt));
    
    private static T BlackScholesD2<T>(T dt, T strike, T spot, T r, T sigma)
        where T : IReal<T>
        => (T.Log(spot / strike) + (r - sigma * sigma / T.Two) * dt) 
           / (sigma * T.Sqrt(dt));
}