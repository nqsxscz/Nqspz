using Lofi.Lang.Stochastic.Sample.Type;

namespace Lofi.Lang.Stochastic.Sample.Implementation;

internal sealed record EulerMaruyamaSampler(
    IStandardNormalSampler StandardNormalSampler)
    : IEulerMaruyamaSampler;