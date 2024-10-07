using SQLite;

namespace MauiCRUD
{
    public partial class MainPage : ContentPage
    {
        string DbPath; // caminho do banco de dados
        SQLiteConnection Connection; //conexão com o banco SQLite
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonCriarBancoDeDados_Clicked(object sender, EventArgs e)
        {
            // definir o caminho do banco de dados
            DbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "sites.db3");

            // cria uma nova conexão com o banco de dados
            Connection = new SQLiteConnection(DbPath);

            Connection.CreateTable<Site>();
            VslOperacoes.IsVisible = true;
        }

        private void ButtonInserir_Clicked(object sender, EventArgs e)
        {
            if (EntryEndereco.Text == null)
            {
                DisplayAlert("", "Campo de Endereco está vazio", "Ok");
            }
            else
            {
                Site site = new Site();
                site.Endereco = EntryEndereco.Text;
                Connection.Insert(site);

                LimparCampos();
                ListarSites();
            }
        }

        private void ButtonExcluir_Clicked(object sender, EventArgs e)
        {
            if (EntryId.Text == null)
            {
                DisplayAlert("", "Campo de Id está vazio", "Ok");
            }
            else
            {
                int id = Convert.ToInt32(EntryId.Text);
                Connection.Delete<Site>(id);
                LimparCampos();
                ListarSites();
            }
        }

        private void ButtonListar_Clicked(object sender, EventArgs e)
        {
            ListarSites();
        }

        public void ListarSites()
        {
            List<Site> list = Connection.Table<Site>().ToList();
            CtvLista.ItemsSource = list;
        }

        private void ButtonLocalizar_Clicked(object sender, EventArgs e)
        {

            if (EntryId.Text == null)
            {
                DisplayAlert("", "Campo de Id está vazio", "Ok");
            }
            else
            {
                int id = Convert.ToInt32(EntryId.Text);
                var sites = from s in Connection.Table<Site>() where s.Id == id select s;
                Site site = sites.First();
                EntryId.Text = site.Id.ToString();
                EntryEndereco.Text = site.Endereco;
            }
        }

        private void ButtonAlterar_Clicked(object sender, EventArgs e)
        {
            if (EntryId.Text == null)
            {
                DisplayAlert("", "Campo de Id está vazio", "Ok");
            }
            else
            {
                Site site = new Site();
                site.Id = Convert.ToInt32(EntryId.Text);
                site.Endereco = EntryEndereco.Text;
                Connection.Update(site);
                LimparCampos();
                ListarSites();
            }
        }

        public void LimparCampos()
        {
            EntryEndereco.Text = string.Empty;
            EntryId.Text = string.Empty;
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            var label = sender as Label;
            if(label != null && label.BindingContext is Site item)
            {
                var websiteUrl = $"https://{item.Endereco.ToString()}";
                await Launcher.OpenAsync(new Uri(websiteUrl));
            }
        }

        private void TapGestureAlterarSite(object sender, TappedEventArgs e)
        {
            var label = sender as Label;
            if (label != null && label.BindingContext is Site item)
            {
                EntryId.Text = item.Id.ToString();
                EntryEndereco.Text = item.Endereco;
            }
        }
    }

}
