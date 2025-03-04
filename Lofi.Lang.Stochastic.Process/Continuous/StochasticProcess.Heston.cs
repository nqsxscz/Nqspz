using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Heston<T>(
        T init1,
        T init2,
        T mu,
        T kappa,
        T theta,
        T volvol,
        T rho,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init1,
            s => mu * s, 
            (s, v) => v * s,
            OrnsteinUhlenbeck(
                init2, 
                kappa, 
                theta, 
                volvol, 
                wiener.Correlate(rho)),
            wiener);
}