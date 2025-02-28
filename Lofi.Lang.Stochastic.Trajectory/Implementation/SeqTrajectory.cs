using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Trajectory.Implementation;

internal sealed record SeqTrajectory<T>(
    ISeq<T> Values)
    : ISeqTrajectory<T>
    where T : notnull;