using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Lang.Model.Random.Process.Instance.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process;

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