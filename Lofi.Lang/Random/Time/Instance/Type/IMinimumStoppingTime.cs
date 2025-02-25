namespace Lofi.Lang.Random.Time.Instance.Type;

public interface IMinimumStoppingTime
    : IStoppingTime
{
    IStoppingTime Left { get; }

    IStoppingTime Right { get; }
}