using ListaDeItens.Models;

namespace ListaDeItens;

public partial class Editar : ContentPage
{
    private Item _item;
    public Editar(Item item)
	{
		InitializeComponent();
        BindingContext = new Item();
        _item = item;
        BindingContext = _item;

    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sucesso", "Item atualizado com sucesso!", "OK");
        await Navigation.PopAsync();

    }

    private void OnVoltarClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}