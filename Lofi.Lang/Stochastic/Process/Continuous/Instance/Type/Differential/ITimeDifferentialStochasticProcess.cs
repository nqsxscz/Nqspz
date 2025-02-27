using Lofi.Lang.Stochastic.Process.Visitor;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Differential;

public interface ITimeDifferentialStochasticProcess<out T>
    : IDifferentialStochasticProcess<T>
    where T : IAdditiveGroup<T>
{
    IStochasticProcess<DateTime> Operand { get; }
    
    Func<TimeSpan, T> Converter { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IStochasticProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IStochasticProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}