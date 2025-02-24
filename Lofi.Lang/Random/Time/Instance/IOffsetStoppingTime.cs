namespace Lofi.Lang.Random.Time.Instance;

public interface IOffsetStoppingTime
    : IStoppingTime
{
    IStoppingTime Operand { get; }

    TimeSpan Offset { get; }
}