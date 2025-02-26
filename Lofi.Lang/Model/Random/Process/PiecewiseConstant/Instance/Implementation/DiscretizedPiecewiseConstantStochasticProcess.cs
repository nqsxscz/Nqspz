using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Implementation;

internal sealed record DiscretizedPiecewiseConstantStochasticProcess<T>(
    IStochasticProcess<T> Operand,
    ISeq<DateTime> Times)
    : IDiscretizedPiecewiseConstantStochasticProcess<T>
    where T : notnull;