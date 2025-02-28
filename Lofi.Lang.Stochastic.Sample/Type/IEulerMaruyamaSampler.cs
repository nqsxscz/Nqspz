using Lofi.Lang.Stochastic.Process.Continuous;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Ito;
using Lofi.Lang.Stochastic.Trajectory;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Sample.Type;

using Scannable = Prelude.Control.Scannable;

public interface IEulerMaruyamaSampler
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
                    process.Drift(su, au) * du 
                    + process.Volatility(su, bu) * dwu)
            .ToTrajectory();
    }
}