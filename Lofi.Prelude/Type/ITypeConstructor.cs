namespace Lofi.Prelude.Type;

/// <summary>
/// </summary>
/// <typeparam name="TC"></typeparam>
/// <typeparam name="T"></typeparam>
public interface ITypeConstructor<TC, out T>
    where T : notnull;