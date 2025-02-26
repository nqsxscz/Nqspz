using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;

public interface ITimeDifferentialStochasticProcess<out T>
    : IDifferentialStochasticProcess<T>
    where T : IAdditiveGroup<T>
{
    IStochasticProcess<DateTime> Operand { get; }
    
    Func<TimeSpan, T> Converter { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}