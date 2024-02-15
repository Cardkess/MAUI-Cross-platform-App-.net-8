using MAUI.ViewModel;

namespace MAUI.View;

public partial class MainPage : ContentPage
{
    SampleViewModel SampleViewModel { get; set; }

    public MainPage(SampleViewModel sampleViewModel)
    {
        InitializeComponent();
        SampleViewModel = sampleViewModel;
        BindingContext = SampleViewModel;
    }

}
