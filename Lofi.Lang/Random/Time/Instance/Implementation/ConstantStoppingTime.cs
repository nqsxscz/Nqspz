namespace Lofi.Lang.Random.Time.Instance.Implementation;

internal sealed record ConstantStoppingTime(
    DateTime Time)
    : IConstantStoppingTime;