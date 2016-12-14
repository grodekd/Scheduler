using System;

namespace Scheduler
{
    public interface Person
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        TimeSpan MonStart { get; set; }

        TimeSpan MonEnd { get; set; }

        TimeSpan TuesStart { get; set; }

        TimeSpan TuesEnd { get; set; }

        TimeSpan WedStart { get; set; }

        TimeSpan WedEnd { get; set; }

        TimeSpan ThurStart { get; set; }

        TimeSpan ThurEnd { get; set; }

        TimeSpan FriStart { get; set; }

        TimeSpan FriEnd { get; set; }
    }
}
