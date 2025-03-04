using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Snell;

public interface ISnellEnvelopeEvaluator
{
    T Evaluate<T>(ISeq<ITrajectory<T>> trajectories)
        where T : IReal<T>;
}