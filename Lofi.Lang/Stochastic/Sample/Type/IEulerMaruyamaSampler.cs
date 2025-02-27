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