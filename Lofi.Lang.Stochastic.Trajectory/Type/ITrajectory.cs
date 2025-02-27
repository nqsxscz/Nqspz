using Lofi.Lang.Stochastic.Trajectory.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Trajectory.Type;

public interface ITrajectory<out T>
    : ITypeConstructor<ITrajectory, T>
    where T : notnull;