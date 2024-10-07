namespace BlocoDeNotas.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    private async void BtnSobre_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.About about)
        {
            await Launcher.Default.OpenAsync(about.MoreInfoURL);
        }
    }
}