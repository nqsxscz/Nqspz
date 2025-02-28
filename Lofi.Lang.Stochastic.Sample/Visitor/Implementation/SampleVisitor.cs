using Lofi.Lang.Stochastic.Sample.Type;
using Lofi.Lang.Stochastic.Sample.Visitor.Type;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Sample.Visitor.Implementation;

internal sealed record SampleVisitor(
    ISampler Sampler, 
    ISeq<DateTime> Times,
    int Seed)
    : ISampleVisitor;