using Lofi.Lang.Model.Random.Trajectory.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Trajectory.Type;

public interface ITrajectory<out T>
    : ITypeConstructor<ITrajectory, T>
    where T : notnull;