using Lofi.Prelude.Data.Control;
using Shouldly;

namespace Lofi.Lang.Stochastic.Trajectory.Tests;

public class TrajectoryTests
{
    [Test]
    public void Lift_Seq_Trajectory_With_Seq_Trajectory_Should_Return_Seq_Trajectory()
    {
        var trajectory1 = Enumerable
            .Range(1, 3)
            .ToSeq()
            .ToTrajectory();
        var trajectory2 = Enumerable
            .Range(2, 3)
            .ToSeq()
            .ToTrajectory();
        var trajectory3 = RandomTrajectory
            .Lift(
                trajectory1, 
                trajectory2, 
                (x, y) => x + y);

        int[] expected = [3, 5, 7];
        
        trajectory3
            .ToSeq()
            .Enumerable
            .ToArray()
            .ShouldBeEquivalentTo(expected);
        // TODO:
        // improve the usability of ISeq and ITrajectory
        // to avoid having to transform to/from IEnumerable
    }
}