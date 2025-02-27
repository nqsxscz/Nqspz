using Lofi.Lang.Observable.Event.Set.Instance.Operator;

namespace Lofi.Lang.Observable.Event.Set;

public static class Operator
{
    public static IOperator After
        => new AfterOperator();
    
    public static IOperator Before
        => new BeforeOperator();
    
    public static IOperator Except
        => new ExceptOperator();
    
    public static IOperator Intersect
        => new IntersectOperator();
    
    public static IOperator Union
        => new UnionOperator();
}