namespace Mymento.App.Tasks
{
    using Xamarin.Forms;

    public class TimelineListCellViewModel
    {
        public string TaskName { get; set; }
        public string DueDate { get; set; }
        public string TimeLeft { get; set; }
        public Color TimeLeftColor { get; set; }
    }
}
