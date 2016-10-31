namespace Mymento.App.Tasks
{
    using System;
    using Xamarin.Forms;

    public class TimelineListCellViewModel
    {
        public TimelineListCellViewModel(Entities.Task task)
        {
            this.TaskName = task.Name;
            this.DueDate = task.NextReminderDateTimeUtc.ToString();

            double mintuesLeft = (task.NextReminderDateTimeUtc - DateTime.UtcNow).TotalMinutes;
            this.TimeLeft = mintuesLeft + " minutes";
            this.TimeLeftColor = mintuesLeft > 0 ? Color.Green : Color.Red;
        }

        public string TaskName { get; set; }
        public string DueDate { get; set; }
        public string TimeLeft { get; set; }
        public Color TimeLeftColor { get; set; }
    }
}
