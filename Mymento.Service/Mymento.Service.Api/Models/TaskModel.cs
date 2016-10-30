namespace Mymento.Service.Api.Models
{
    using System;

    public class TaskModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime NextReminderDateTimeUtc { get; set; }
    }
}