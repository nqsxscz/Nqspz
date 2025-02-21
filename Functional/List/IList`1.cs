using Functional.HigherKindedTypes;

namespace Functional.List;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IList<out T> 
    : ITypeConstructor<IList, T>
    where T : notnull;