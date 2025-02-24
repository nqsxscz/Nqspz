using Lofi.Lang.Random.Sequence.Instance.Operator;

namespace Lofi.Lang.Random.Sequence;

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