namespace Lofi.Lang.Random.Time.Instance;

public interface IMinimumStoppingTime
    : IStoppingTime
{
    IStoppingTime Left { get; }

    IStoppingTime Right { get; }
}