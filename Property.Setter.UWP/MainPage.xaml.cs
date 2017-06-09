using Windows.Foundation;
using Windows.UI.ViewManagement;
using Property.Setter.UWP.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Property.Setter.UWP
{
    /// <summary>
    /// An empty page that can be used on its own orB navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            DataContext = new MainPageViewModel();

            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(525, 350);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }
    }
}
