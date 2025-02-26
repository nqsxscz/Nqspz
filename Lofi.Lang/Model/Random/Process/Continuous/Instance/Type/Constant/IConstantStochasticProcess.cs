namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Constant;

public interface IConstantStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : notnull
{
    T Value { get; }
}