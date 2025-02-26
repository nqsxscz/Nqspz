using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> ToStochasticProcess<T>(
        this ITypeConstructor<IStochasticProcess, T> stochasticProcess)
        where T : notnull
        => (IStochasticProcess<T>) stochasticProcess;
    
    public static IStochasticProcess<T> ToStochasticProcess<T>(
        this T t)
        where T : notnull
        => throw new NotImplementedException();
}