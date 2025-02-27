using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Wiener;
using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Numeric.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;

public interface IWienerDifferentialStochasticProcess<out T>
    : IDifferentialStochasticProcess<T>
    where T : IReal<T>
{
    IWienerStochasticProcess<T> Operand { get; }
    
    Func<TimeSpan, T> Converter { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}