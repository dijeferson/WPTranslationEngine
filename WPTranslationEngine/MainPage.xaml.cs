using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WPTranslationEngine
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            TranslationManager.Translate(this);
        }
    }
}
