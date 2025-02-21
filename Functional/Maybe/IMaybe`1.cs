using Functional.HigherKindedTypes;

namespace Functional.Maybe;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMaybe<out T> 
    : ITypeConstructor<IMaybe, T>
    where T : notnull;