using ListaDeItens.Models;

namespace ListaDeItens
{
    public partial class MainPage : ContentPage
    {
        private List<Item> itens = new List<Item>();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Item();
        }

        private void BtnAdditem_Clicked(object sender, EventArgs e)
        {

            string nomeItem = NomeItem.Text;
            string descricaoItem = DescricaoItem.Text;
            try
            {
                if (!string.IsNullOrEmpty(nomeItem) && !string.IsNullOrEmpty(descricaoItem))
                {
                    itens.Add(new Item(nomeItem, descricaoItem));
                    DisplayAlert(nomeItem, "item adicionado ao inventário com sucesso!", "OK");
                }
                else
                {
                    DisplayAlert("Erro", "Nome ou Descrição não podem estar vazios", "OK");
                }

                NomeItem.Text = string.Empty;
                DescricaoItem.Text = string.Empty;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro durante o processo", ex);
            }

        }

        private void BtnListItens_Clicked(object sender, EventArgs e)
        {
            try
            {
                vsItens.Clear();
                if (itens.Count == 0)
                {
                    DisplayAlert("Erro", "O inventário está vazio", "OK");
                }
                else
                {
                    foreach (Item item in itens)
                    {
                        StackLayout itemLayout = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Margin = new Thickness(8, 4),
                            Spacing = 8
                        };
                        Label label = new Label
                        {
                            Text = item.Nome,
                            FontSize = 18,
                            FontAttributes = FontAttributes.Bold,
                        };
                        Label label2 = new Label
                        {
                            Text = item.Descricao,
                            FontSize = 14,
                        };

                        vsItens.Children.Add(label);
                        vsItens.Children.Add(label2);

                        vsItens.Children.Add(itemLayout);
                        ListaInventario.IsVisible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Informe apenas números", "OK");
            }
        }
    }

}
