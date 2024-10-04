using ListaDeItens.Models;
using System.Collections.ObjectModel;

namespace ListaDeItens
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<Item> Itens { get; set; } = new ObservableCollection<Item>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Item();
        }

        private void OnAdicionarItemClicked(object sender, EventArgs e)
        {

            string nomeItem = nomeEntry.Text;
            string descricaoItem = descricaoEntry.Text;
            try
            {
                if (!string.IsNullOrEmpty(nomeItem) && !string.IsNullOrEmpty(descricaoItem))
                {
                    Itens.Add(new Item(nomeItem, descricaoItem));
                    DisplayAlert(nomeItem, "item adicionado ao inventário com sucesso!", "OK");
                    nomeEntry.Text = string.Empty;
                    descricaoEntry.Text = string.Empty;
                }
                else
                {
                    DisplayAlert("Erro", "Nome ou Descrição não podem estar vazios", "OK");
                }               

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro durante o processo", ex);
            }

        }


        private async void OnInventarioClicked(object sender, EventArgs e)
        {

                await Navigation.PushAsync(new Inventario());
            
        }
    }

}
