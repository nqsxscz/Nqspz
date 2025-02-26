using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Select;

public interface ISelectStochasticProcess<T1, out T2>
    : IStochasticProcess<T2>
    where T1 : notnull
    where T2 : notnull
{
    IStochasticProcess<T1> Operand { get; }
    
    Func<T1, T2> Selector { get; }
    
    TResult IStochasticProcess<T2>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T2> IStochasticProcess<T2>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}