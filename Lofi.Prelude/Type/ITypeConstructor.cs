namespace Lofi.Prelude.Type;

public interface ITypeConstructor<TC, out T>
    where TC: notnull
    where T : notnull;