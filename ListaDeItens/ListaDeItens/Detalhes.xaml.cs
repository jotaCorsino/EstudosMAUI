using ListaDeItens.Models;

namespace ListaDeItens;

public partial class Detalhes : ContentPage
{
    private Item _item;
    public Detalhes(Item item)
	{
		InitializeComponent();

        BindingContext = new Item();
        _item = item;
        BindingContext = _item;

    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Editar(_item));
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}