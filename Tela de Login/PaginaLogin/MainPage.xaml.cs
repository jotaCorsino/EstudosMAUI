namespace PaginaLogin
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void Btn_SignIn_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Simula uma verificação simples
            if (IsValidCredentials(email, password))
            {
                // Login bem-sucedido
                await DisplayAlert("Sucesso", "Login efetuado com sucesso!", "OK");

            }
            else
            {
                // Exibe uma mensagem de erro
                await DisplayAlert("Erro", "Usuário ou senha inválidos.", "OK");
                
            }
            await Navigation.PushAsync(new Dashboard());
            PasswordEntry.Text = string.Empty;
        }

        // Função para verificar se as credenciais são válidas (exemplo básico)
        private bool IsValidCredentials(string email, string password)
        {
           
            return email == "admin@email.com" && password == "1234";
        }
    }
}


