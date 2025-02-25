namespace Lofi.Lang.Random.Time.Instance.Type;

public interface IOffsetStoppingTime
    : IStoppingTime
{
    IStoppingTime Operand { get; }

    TimeSpan Offset { get; }
}