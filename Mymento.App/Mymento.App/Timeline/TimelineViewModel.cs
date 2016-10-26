using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Mymento.App.Timeline
{
    public class TimelineViewModel : ContentPage
    {
        public IEnumerable<string> ListSource { get; set; }

        public TimelineViewModel()
        {
            ListSource = Enumerable.Repeat("", 100);
        }
    }
}
