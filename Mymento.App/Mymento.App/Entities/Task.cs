namespace Mymento.App.Entities
{
    using System;

    public class Task
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime NextReminderDateTimeUtc { get; set; }
    }
}
