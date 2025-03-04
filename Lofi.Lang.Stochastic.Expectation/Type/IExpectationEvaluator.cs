using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Expectation.Type;

public interface IExpectationEvaluator
{
    T Evaluate<T>(ICollection<ITrajectory<T>> trajectories)
        where T : IReal<T>;
}