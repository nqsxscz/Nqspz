using Lofi.Lang.Stochastic.Process.Continuous;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Ito;
using Lofi.Lang.Stochastic.Trajectory;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Sample.Type;

using Scannable = Prelude.Control.Scannable;

public interface IRungeKuttaSampler
    : ISampler
{
    ITrajectory<T> ISampler.Sample<T>(
        IItoStochasticProcess<T> process, 
        ISeq<DateTime> times,
        int seed)
    {
        var dt = 
            StochasticProcess
                .Time
                .Differentiate(process.Converter)
                .Sample(this, times, seed);
        
        var dwt =
            process
                .Wiener
                .Differentiate(process.Converter)
                .Sample(this, times, seed);

        var at =
            process
                .Left
                .Sample(this, times, seed);
        
        var bt =
            process
                .Right
                .Sample(this, times, seed);

        return Scannable
            .ScanLeft(
                dt, 
                dwt, 
                at, 
                bt, 
                process.Init, 
                (su, du, dwu, au, bu) => 
                    Next(
                        process.Drift, 
                        process.Volatility, 
                        su, 
                        du, 
                        dwu, 
                        au, 
                        bu))
            .ToTrajectory();
    }

    private static T Next<T>(
        Func<T, T, T> drift,
        Func<T, T, T> volatility,
        T su,
        T du,
        T dwu,
        T au,
        T bu)
        where T : IReal<T>
    {
        var sbaru = 
            su 
            + drift(su, au) * du 
            + volatility(su, bu) * du.Sqrt();
        var next =
            su
            + drift(su, au) * du
            + volatility(su, bu) * dwu
            + T.Two.Reciprocate() * (drift(sbaru, au) - drift(su, au)) * (dwu.Square() - du) / du.Sqrt();
        return next;
    }
}