using Algebra.Groups.Additive;

namespace LinearAlgebra;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TPoint"></typeparam>
/// <typeparam name="TVector"></typeparam>
public interface IAffineSpace<TPoint, TVector>
    where TPoint : IAffineSpace<TPoint, TVector>
    where TVector : IAdditiveGroup<TVector>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    static abstract TPoint operator +(TPoint p, TVector v);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract TVector operator -(TPoint left, TPoint right);
}