using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface ILiftContinuousProcess<T1, T2, out T3>
    : IContinuousProcess<T3>
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
{
    IContinuousProcess<T1> Left { get; }

    IContinuousProcess<T2> Right { get; }

    Func<T1, T2, T3> Combinator { get; }
    
    ITypeConstructor<TC, T3> IContinuousProcess<T3>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}