namespace Lofi.Lang.Random.Time.Instance.Type;

public interface IConstantStoppingTime :
    IStoppingTime
{
    DateTime Time { get; }
}