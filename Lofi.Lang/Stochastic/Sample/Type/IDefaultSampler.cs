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
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Numeric;
using MathNet.Numerics.Distributions;

namespace Lofi.Lang.Stochastic.Sample.Type;

public interface IDefaultSampler
    : ISampler
{
    ITrajectory<DateTime> ISampler.Sample(
        ITimeStochasticProcess _,
        ISeq<DateTime> times)
        => times.ToTrajectory();

    ITrajectory<T> ISampler.Sample<T>(
        IWienerStochasticProcess<T> process,
        ISeq<DateTime> times)
        => process
            .Differentiate()
            .Sample(this, times)
            .ScanLeft(
                T.Zero, 
                Semigroup.Add);

    ITrajectory<T> ISampler.Sample<T>(
        ICorrelatedWienerStochasticProcess<T> process,
        ISeq<DateTime> times)
        => StochasticProcess
            .Lift(
                process.Left,
                process.Right,
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
            .Sample(this, times);

    ITrajectory<T> ISampler.Sample<T>(
        IConstantStochasticProcess<T> process,
        ISeq<DateTime> times)
        => times
            .Select(_ => process.Value)
            .ToSeq()
            .ToTrajectory();

    ITrajectory<T> ISampler.Sample<T>(
        IGenericDifferentialStochasticProcess<T> process,
        ISeq<DateTime> times)
    {
        var trajectory = process
            .Operand
            .Sample(this, times)
            .ToSeq();
        return trajectory
            .Zip(trajectory.Skip(1))
            .Select(p => p.Second - p.First)
            .ToSeq()
            .ToTrajectory();
    }

    ITrajectory<T> ISampler.Sample<T>(
        ITimeDifferentialStochasticProcess<T> process, 
        ISeq<DateTime> times)
        => times
            .Zip(times.Skip(1))
            .Select(p => p.Second - p.First)
            .Select(process.Converter)
            .ToSeq()
            .ToTrajectory();

    ITrajectory<T> ISampler.Sample<T>(
        IWienerDifferentialStochasticProcess<T> process,
        ISeq<DateTime> times)
        => RandomTrajectory.Lift(
            StochasticProcess
                .Time
                .Differentiate(process.Converter)
                .Sample(this, times), 
            Normal
                .Samples(0, 1)
                .ToSeq()
                .ToTrajectory(), 
            (dt, z) => 
                dt.Sqrt()
                    .Multiply(
                        T.FromDouble(z))
        );

    ITrajectory<T> ISampler.Sample<T>(
        IOffsetStochasticProcess<T> process,
        ISeq<DateTime> times)
        => process
            .Operand
            .Sample(
                this,
                times
                    .Select(process.Offsetter)
                    .ToSeq());

    ITrajectory<T> ISampler.Sample<T>(
        IItoStochasticProcess<T> process, 
        ISeq<DateTime> times)
    {
        var dt = 
            StochasticProcess
                .Time
                .Differentiate(process.Converter)
                .Sample(this, times);
        
        var dwt =
            process
                .Wiener
                .Differentiate()
                .Sample(this, times);

        var at =
            process
                .Left
                .Sample(this, times);
        
        var bt =
            process
                .Right
                .Sample(this, times);

        return RandomTrajectory
            .ScanLeft(
                dt, 
                dwt, 
                at, 
                bt, 
                process.Init, 
                (su, du, dwu, au, bu) => 
                    process.Drift(su, au) * du 
                    + process.Volatility(su, bu) * dwu);
    }

    ITrajectory<T2> ISampler.Sample<T1, T2>(
        ISelectStochasticProcess<T1, T2> process,
        ISeq<DateTime> times)
        => process
            .Operand
            .Sample(this, times)
            .Select(process.Selector);

    ITrajectory<T3> ISampler.Sample<T1, T2, T3>(
        ILiftStochasticProcess<T1, T2, T3> process,
        ISeq<DateTime> times)
        => RandomTrajectory
            .Lift(
                process
                    .Left
                    .Sample(this, times),
                process
                    .Right
                    .Sample(this, times),
                process
                    .Combinator);
}