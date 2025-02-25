namespace Lofi.Lang.Random.Time.Instance.Type;

public interface IMaximumStoppingTime
    : IStoppingTime
{
    IStoppingTime Left { get; }

    IStoppingTime Right { get; }
}