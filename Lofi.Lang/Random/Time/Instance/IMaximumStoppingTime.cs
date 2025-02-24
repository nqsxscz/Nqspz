namespace Lofi.Lang.Random.Time.Instance;

public interface IMaximumStoppingTime
    : IStoppingTime
{
    IStoppingTime Left { get; }

    IStoppingTime Right { get; }
}