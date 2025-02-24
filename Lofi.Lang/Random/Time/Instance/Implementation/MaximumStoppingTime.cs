namespace Lofi.Lang.Random.Time.Instance.Implementation;

internal sealed record MaximumStoppingTime(
    IStoppingTime Left,
    IStoppingTime Right)
    : IMaximumStoppingTime;