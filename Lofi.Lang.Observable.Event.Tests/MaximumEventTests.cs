using Lofi.Lang.Observable.Event.Single;
using Shouldly;

namespace Lofi.Lang.Observable.Event.Tests;

public class MaximumEventTests
{
    [Test]
    public void Should_Occurr_At_Right_Date_When_Right_Date_After_Left_Date()
    {
        var date1 = DateTime.Now;
        var date2 = DateTime.Now + TimeSpan.FromDays(1);
        var @event = date1
            .ToEvent()
            .Maximum(date2.ToEvent());
        @event.Occurred(date1).ShouldBeFalse();
        @event.Occurred(date2).ShouldBeTrue();
    }
}