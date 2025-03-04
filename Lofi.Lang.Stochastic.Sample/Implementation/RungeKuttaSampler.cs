using Lofi.Lang.Stochastic.Sample.Type;

namespace Lofi.Lang.Stochastic.Sample.Implementation;

internal sealed record RungeKuttaSampler(
    IStandardNormalSampler StandardNormalSampler)
    : IRungeKuttaSampler;