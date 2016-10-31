namespace Mymento.App.Tasks
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Mymento.App.DataAccess;
    using Xamarin.Forms;

    public class TimelineViewModel : ViewModelBase
    {
        private IEnumerable<TimelineListCellViewModel> _timelineCells;
        public IEnumerable<TimelineListCellViewModel> TimelineCells
        {
            get { return _timelineCells; }
            set { Set(nameof(_timelineCells), ref _timelineCells, value); }
        }

        public ICommand LoadTimelineTasksCommand { get; set; }

        public TimelineViewModel()
        {
            this.LoadTimelineTasksCommand = new Command(
                async () => await this.LoadData());
        }

        public async Task LoadData()
        {
            this.TimelineCells = (await 
                new MymentoServiceClient()
                .GetTasksAsync())
                .Select(task => new TimelineListCellViewModel(task));
        }
    }
}
