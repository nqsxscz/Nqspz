namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Lift;

public interface ILiftStochasticProcess<T1, T2, out T3>
    : IStochasticProcess<T3>
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
{
    IStochasticProcess<T1> Left { get; }
    
    IStochasticProcess<T2> Right { get; }
    
    Func<T1, T2, T3> Combinator { get; }
}