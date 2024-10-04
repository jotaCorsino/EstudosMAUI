namespace PaginaLogin;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
	}

    private void BtnLogout_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}