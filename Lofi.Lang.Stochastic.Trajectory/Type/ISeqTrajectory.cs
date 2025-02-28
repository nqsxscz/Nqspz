using Lofi.Prelude.Data.Control.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Trajectory.Type;

public interface ISeqTrajectory<out T>
    : ITrajectory<T>
    where T : notnull
{
    ISeq<T> Values { get; }
}