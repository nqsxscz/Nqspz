using System.Numerics;
using LinearAlgebra;
using Time.Durations;

namespace Time.Times;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TDuration"></typeparam>
public interface ITime<T, TDuration> : 
    IAffineSpace<T, TDuration>,
    IComparisonOperators<T, T, bool>
    where T : ITime<T, TDuration>
    where TDuration : IDuration<TDuration>;