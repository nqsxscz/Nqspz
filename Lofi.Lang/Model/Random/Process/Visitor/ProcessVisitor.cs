using Lofi.Lang.Model.Random.Process.Visitor.Times.Implementation;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Process.Visitor;

public static class ProcessVisitor
{
    public static IPiecewiseConstantProcessVisitor<ISeq<DateTime>>
        Times
        => new TimesVisitor();
}