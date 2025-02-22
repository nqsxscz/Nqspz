namespace Algebra.Groups.Additive;

/// <summary>
/// 
/// </summary>
public static class AdditiveSemigroup
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static T Add<T>(T left, T right)
        where T : IAdditiveSemigroup<T>
        => left + right;
}