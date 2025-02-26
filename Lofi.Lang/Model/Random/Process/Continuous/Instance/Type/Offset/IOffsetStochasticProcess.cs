namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Offset;

public interface IOffsetStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : notnull
{
    IStochasticProcess<T> Operand { get; }
    
    TimeSpan Offset { get; }
    
    Func<DateTime, TimeSpan, DateTime> Offsetter { get; }
}