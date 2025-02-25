using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Prelude.Algebra;

public static class Bottomable
{
    public static T Bottom<T>()
        where T : IBottomable<T>
        => T.Bottom;
}