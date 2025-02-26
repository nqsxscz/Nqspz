using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant;

public static partial class StochasticProcess
{
    public static ISeq<DateTime>
        Times<T>(
            this IPiecewiseConstantStochasticProcess<T> process)
        where T : notnull
        => process
            .Accept(
                ProcessVisitor
                    .Times);
}