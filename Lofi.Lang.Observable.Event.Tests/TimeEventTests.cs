using Lofi.Lang.Observable.Event.Single;
using Shouldly;

namespace Lofi.Lang.Observable.Event.Tests;

public class TimeEventTests
{
    [Test]
    public void Should_Occurr_At_Date()
    {
        var date = DateTime.Now;
        var @event = date.ToEvent();
        @event.Occurred(date).ShouldBeTrue();
    }
}