using Lofi.Lang.Model.Random.Variable.Instance.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.Implementation;

internal sealed record ConstantRandomVariable<T>(
    T Value)
    : IConstantRandomVariable<T>
    where T : notnull;