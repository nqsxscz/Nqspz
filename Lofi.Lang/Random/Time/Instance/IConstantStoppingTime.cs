namespace Lofi.Lang.Random.Time.Instance;

public interface IConstantStoppingTime :
    IStoppingTime
{
    DateTime Time { get; }
}