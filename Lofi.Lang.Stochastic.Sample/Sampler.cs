using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Sample.Implementation;
using Lofi.Lang.Stochastic.Sample.Type;
using Lofi.Lang.Stochastic.Sample.Visitor;
using Lofi.Lang.Stochastic.Trajectory;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Sample;

public static class Sampler
{
    public static IStandardNormalSampler StandardNormal
        => new MathNetStandardNormalSampler();

    public static ISampler EulerMaruyama()
        => EulerMaruyama(StandardNormal);
    
    public static ISampler EulerMaruyama(IStandardNormalSampler standardNormalSampler)
        => new EulerMaruyamaSampler(standardNormalSampler);
    
    public static ISampler RungeKutta()
        => RungeKutta(StandardNormal);
    
    public static ISampler RungeKutta(IStandardNormalSampler standardNormalSampler)
        => new RungeKuttaSampler(standardNormalSampler);

    public static ICollection<ITrajectory<T>> SampleMany<T>(this
            IStochasticProcess<T> process,
        ISampler sampler,
        ISeq<DateTime> times,
        int count)
        where T : notnull
        => Enumerable
            .Range(0, count)
            .Select(i =>
                process
                    .Sample(
                        sampler,
                        times,
                        i))
            .ToArray();
    
    public static ITrajectory<T> Sample<T>(this 
        IStochasticProcess<T> process,
        ISampler sampler,
        ISeq<DateTime> times,
        int seed)
        where T : notnull
        => process
            .Accept(
                StochasticProcessVisitor
                    .Sample(
                        sampler, 
                        times,
                        seed))
            .ToTrajectory();
}