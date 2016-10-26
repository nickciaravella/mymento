using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Mymento.App.Tasks
{
    public class TimelineViewModel : ContentPage
    {
        public IEnumerable<TimelineListCellViewModel> TimelineCells { get; set; }

        public TimelineViewModel()
        {
            this.TimelineCells = new List<TimelineListCellViewModel>
            {
                new TimelineListCellViewModel()
                {
                    TaskName = "Mow the lawn",
                    DueDate = "October 20, 2016",
                    TimeLeft = "5 days overdue",
                    TimeLeftColor = Color.Red
                },
                new TimelineListCellViewModel()
                {
                    TaskName = "Rotate your tires",
                    DueDate = "October 27, 2016",
                    TimeLeft = "2 days left",
                    TimeLeftColor = Color.FromRgb(255, 165, 0)
                },
                new TimelineListCellViewModel()
                {
                    TaskName = "Bring the hoses inside",
                    DueDate = "November 5, 2016",
                    TimeLeft = "11 days left",
                    TimeLeftColor = Color.Green
                },
                new TimelineListCellViewModel()
                {
                    TaskName = "Put up the Christmas lights mother fucker",
                    DueDate = "November 25, 2016",
                    TimeLeft = "31 days left",
                    TimeLeftColor = Color.Green
                },
            };
        }
    }
}
