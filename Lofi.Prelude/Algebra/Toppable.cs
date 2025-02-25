using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Prelude.Algebra;

public static class Toppable
{
    public static T Top<T>()
        where T : IToppable<T>
        => T.Top;
}