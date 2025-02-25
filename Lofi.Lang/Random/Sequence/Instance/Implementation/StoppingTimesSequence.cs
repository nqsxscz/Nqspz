using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Lang.Random.Time.Instance.Type;

namespace Lofi.Lang.Random.Sequence.Instance.Implementation;

internal sealed record StoppingTimesSequence(
    IEnumerable<IStoppingTime> StoppingTimes)
    : IStoppingTimesSequence;