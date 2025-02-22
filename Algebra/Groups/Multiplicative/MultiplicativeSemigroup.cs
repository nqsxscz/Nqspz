namespace Algebra.Groups.Multiplicative;

/// <summary>
/// 
/// </summary>
public static class MultiplicativeSemigroup
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static T Multiply<T>(T left, T right)
        where T : IMultiplicativeSemigroup<T>
        => left * right;
}