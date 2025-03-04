using Lofi.Lang.Stochastic.Process.Continuous;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Constant;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Ito;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Lift;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Offset;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Select;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Time;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Lang.Stochastic.Trajectory;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Data.Control;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Sample.Type;

using Scannable = Prelude.Control.Scannable;

public interface ISampler
{
    IStandardNormalSampler StandardNormalSampler { get; } 
    
    ITrajectory<T> Sample<T>(
        IItoStochasticProcess<T> process,
        ISeq<DateTime> times,
        int seed)
        where T : IReal<T>;

    ITrajectory<DateTime> Sample(
        ITimeStochasticProcess _,
        ISeq<DateTime> times)
        => times.ToTrajectory();

    ITrajectory<T> Sample<T>(
        IStandardWienerStochasticProcess<T> process,
        ISeq<DateTime> times,
        int seed)
        where T : IReal<T>
        => Scannable
            .ScanLeft(
                process
                    .Differentiate()
                    .Sample(
                        this, 
                        times, 
                        seed), 
                T.Zero, 
                Semigroup.Add)
            .ToTrajectory();

    ITrajectory<T> Sample<T>(
        ICorrelatedWienerStochasticProcess<T> process,
        ISeq<DateTime> times,
        int seed)
        where T : IReal<T>
        => StochasticProcess
            .Lift(
                process.Operand,
                StochasticProcess
                    .Wiener(
                        process.Converter),
                (w1, w2) =>
                    process
                        .Correlation
                        .Multiply(w1)
                        .Add(
                            T.One
                                .Subtract(
                                    process.Correlation
                                        .Multiply(process.Correlation))
                                .Sqrt()
                                .Multiply(w2)))
            .Sample(
                this, 
                times, 
                seed);

    ITrajectory<T> Sample<T>(
        IConstantStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : notnull
        => times
            .Select(_ => process.Value)
            .Skip(1)
            .ToSeq()
            .ToTrajectory();

    ITrajectory<T> Sample<T>(
        IGenericDifferentialStochasticProcess<T> process,
        ISeq<DateTime> times,
        int seed)
        where T : IAdditiveGroup<T>
    {
        var trajectory = process
            .Operand
            .Sample(
                this, 
                times,
                seed)
            .ToSeq();
        return trajectory
            .Zip(trajectory.Skip(1))
            .Select(p => p.Second - p.First)
            .ToSeq()
            .ToTrajectory();
    }

    ITrajectory<T> Sample<T>(
        ITimeDifferentialStochasticProcess<T> process, 
        ISeq<DateTime> times)
        where T : IAdditiveGroup<T>
        => times
            .Zip(times.Skip(1))
            .Select(p => p.Second - p.First)
            .Select(process.Converter)
            .ToSeq()
            .ToTrajectory();

    ITrajectory<T> Sample<T>(
        IWienerDifferentialStochasticProcess<T> process,
        ISeq<DateTime> times,
        int seed)
        where T : IReal<T>
        => process.Operand switch
        {
            IStandardWienerStochasticProcess<T>
                {
                    Id: var id
                } =>
                SampleStandard(
                    id, 
                    process
                        .Operand
                        .Converter, 
                    times, 
                    seed),
            ICorrelatedWienerStochasticProcess<T> correlated =>
                SampleCorrelated(
                    correlated, 
                    times, 
                    seed),
            _ => throw new InvalidOperationException()
        };

    ITrajectory<T> Sample<T>(
        IOffsetStochasticProcess<T> process,
        ISeq<DateTime> times,
        int seed)
        where T : notnull
        => process
            .Operand
            .Sample(
                this,
                times
                    .Select(process.Offsetter)
                    .ToSeq(),
                seed);
    
    ITrajectory<T2> Sample<T1, T2>(
        ISelectStochasticProcess<T1, T2> process,
        ISeq<DateTime> times,
        int seed)
        where T1 : notnull
        where T2 : notnull
        => process
            .Operand
            .Sample(this, times, seed)
            .Select(process.Selector);

    ITrajectory<T3> Sample<T1, T2, T3>(
        ILiftStochasticProcess<T1, T2, T3> process,
        ISeq<DateTime> times,
        int seed)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => RandomTrajectory
            .Lift(
                process
                    .Left
                    .Sample(this, times, seed),
                process
                    .Right
                    .Sample(this, times, seed),
                process
                    .Combinator);
    
    ITrajectory<T> SampleStandard<T>(
        int id,
        Func<TimeSpan, T> converter,
        ISeq<DateTime> times,
        int seed)
        where T : IReal<T>
        => RandomTrajectory.Lift(
            StochasticProcess
                .Time
                .Differentiate(converter)
                .Sample(this, times, seed), 
            StandardNormalSampler
                .Sample<T>(
                    seed*100_000 + id, 
                    times.Count()-1)
                .ToTrajectory(), 
            (dt, z) => 
                dt.Sqrt() * z);

    ITrajectory<T> SampleCorrelated<T>(
        ICorrelatedWienerStochasticProcess<T> process,
        ISeq<DateTime> times,
        int seed)
        where T : IReal<T>
    {
        var w = process
            .Sample(this, times, seed)
            .ToSeq();
        return w.Zip(w.Skip(1))
            .Select(p => p.Second - p.First)
            .ToSeq()
            .ToTrajectory();
    }
}