using Lofi.Lang.Model.Random.Process.Continuous.Instance.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;

public interface IStochasticProcess<out T>
    : ITypeConstructor<IStochasticProcess, T>
    where T : notnull;