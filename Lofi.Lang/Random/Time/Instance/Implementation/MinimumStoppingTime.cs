namespace Lofi.Lang.Random.Time.Instance.Implementation;

internal sealed record MinimumStoppingTime(
    IStoppingTime Left,
    IStoppingTime Right)
    : IMinimumStoppingTime;