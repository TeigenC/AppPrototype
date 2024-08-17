using Bloom.Pages;

namespace Bloom
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("CalendarPage", typeof(CalendarPage));
            Routing.RegisterRoute("InfoPage", typeof(InfoPage));
        }
    }
}
