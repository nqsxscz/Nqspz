using Lofi.Lang.Random.Process.Visitor.Observe.Implementation;
using Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;

namespace Lofi.Lang.Random.Process.Visitor;

public static class ProcessVisitor
{
    public static IProcessVisitor<IMaybe> 
        Observe(DateTime t)
        => new ObserveVisitor(t);
}