using Lofi.Lang.Random.Process.Visitor.Observe.Implementation;
using Lofi.Lang.Random.Process.Visitor.StoppingSequence.Implementation;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;

namespace Lofi.Lang.Random.Process.Visitor;

public static class ProcessVisitor
{
    public static IContinuousProcessVisitor1<IMaybe> 
        Observe(DateTime t)
        => new ObserveVisitor(t);

    public static IPiecewiseConstantProcessVisitor<IStoppingSequence>
        StoppingSequence
        => new StoppingSequenceVisitor();
}