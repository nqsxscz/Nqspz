using MathNet.Numerics.Distributions;

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
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Sample.Type;

using Scannable = Prelude.Control.Scannable;

public interface ISampler
{
    ITrajectory<T> Sample<T>(
        IItoStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : IReal<T>;

    ITrajectory<DateTime> Sample(
        ITimeStochasticProcess _,
        ISeq<DateTime> times)
        => times.ToTrajectory();

    ITrajectory<T> Sample<T>(
        IWienerStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : IReal<T>
        => Scannable
            .ScanLeft(
                process
                    .Differentiate()
                    .Sample(this, times), 
                T.Zero, 
                Semigroup.Add)
            .ToTrajectory();

    ITrajectory<T> Sample<T>(
        ICorrelatedWienerStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : IReal<T>
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

    ITrajectory<T> Sample<T>(
        IConstantStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : notnull
        => times
            .Select(_ => process.Value)
            .ToSeq()
            .ToTrajectory();

    ITrajectory<T> Sample<T>(
        IGenericDifferentialStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : IAdditiveGroup<T>
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
        ISeq<DateTime> times)
        where T : IReal<T>
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

    ITrajectory<T> Sample<T>(
        IOffsetStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : notnull
        => process
            .Operand
            .Sample(
                this,
                times
                    .Select(process.Offsetter)
                    .ToSeq());
    
    ITrajectory<T2> Sample<T1, T2>(
        ISelectStochasticProcess<T1, T2> process,
        ISeq<DateTime> times)
        where T1 : notnull
        where T2 : notnull
        => process
            .Operand
            .Sample(this, times)
            .Select(process.Selector);

    ITrajectory<T3> Sample<T1, T2, T3>(
        ILiftStochasticProcess<T1, T2, T3> process,
        ISeq<DateTime> times)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
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