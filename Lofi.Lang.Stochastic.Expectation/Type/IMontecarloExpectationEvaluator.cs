using Lofi.Lang.Stochastic.Trajectory;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data.Control;

namespace Lofi.Lang.Stochastic.Expectation.Type;

public interface IMontecarloExpectationEvaluator
    : IExpectationEvaluator
{
    T IExpectationEvaluator.Evaluate<T>(
        ICollection<ITrajectory<T>> trajectories)
        => Foldable.Sum(
            trajectories
                .Select(trajectory =>
                        trajectory
                            .ToSeq()
                            .Enumerable
                            .Last())
                .ToSeq())
            / T.FromInt(trajectories.Count);
}