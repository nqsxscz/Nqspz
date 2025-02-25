using Lofi.Lang.Random.Time.Instance.Type;

namespace Lofi.Lang.Random.Time.Instance.Implementation;

internal sealed record ConstantStoppingTime(
    DateTime Time)
    : IConstantStoppingTime;