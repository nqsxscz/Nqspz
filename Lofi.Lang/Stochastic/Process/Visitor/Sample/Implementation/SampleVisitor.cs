using Lofi.Lang.Stochastic.Process.Visitor.Sample.Type;
using Lofi.Lang.Stochastic.Sample.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Process.Visitor.Sample.Implementation;

internal sealed record SampleVisitor(
    ISampler Sampler, 
    ISeq<DateTime> Times,
    int Seed)
    : ISampleVisitor;