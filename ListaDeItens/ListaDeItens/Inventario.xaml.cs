using ListaDeItens.Models;
using Microsoft.Maui;
using System.Collections.ObjectModel;

namespace ListaDeItens;

public partial class Inventario : ContentPage
{

    public Inventario()
    {
        InitializeComponent();
        BindingContext = new { Itens = MainPage.Itens };
    }

    private async void BtnDetalhes_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        // Obtem o item passado pelo CommandParameter do botão
        var selectedItem = button.CommandParameter as Item;

        if (selectedItem != null)
        {
            // Navega para a página de detalhes, passando o item selecionado
            await Navigation.PushAsync(new Detalhes(selectedItem));
        }
    }

    private void BtnSair_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
