using Lofi.Lang.Model.Random.Process.Visitor.Sample.Type;
using Lofi.Lang.Model.Random.Sample.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Process.Visitor.Sample.Implementation;

internal sealed record SampleVisitor(
    ISampler Sampler, 
    ISeq<DateTime> Times)
    : ISampleVisitor;