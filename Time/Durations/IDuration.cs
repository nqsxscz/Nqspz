using Algebra.Groups.Additive;

namespace Time.Durations;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDuration<T>
    : IAdditiveGroup<T>
    where T : 
        IDuration<T>;