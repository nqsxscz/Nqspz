using Lofi.Lang.Model.Random.Process.PiecewiseConstant;
using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Process.Visitor.Times.Type;

public interface ITimesVisitor 
    : IPiecewiseConstantProcessVisitor<ISeq<DateTime>>
{
    ISeq<DateTime> 
        IPiecewiseConstantProcessVisitor<ISeq<DateTime>>.Visit<T>(
            IDiscretizedPiecewiseConstantStochasticProcess<T> process)
        => process.Times;

    ISeq<DateTime> 
        IPiecewiseConstantProcessVisitor<ISeq<DateTime>>.Visit<T>(
            IOffsetPiecewiseConstantStochasticProcess<T> process)
        => process
            .Operand
            .Times()
            .Skip(process.Offset)
            .ToSeq();
}