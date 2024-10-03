namespace PaginaLogin
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        private void Btn_SignIn_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Simula uma verificação simples
            if (IsValidCredentials(email, password))
            {
                // Login bem-sucedido
                DisplayAlert("Sucesso", "Login efetuado com sucesso!", "OK");

            }
            else
            {
                // Exibe uma mensagem de erro
                DisplayAlert("Erro", "Usuário ou senha inválidos.", "OK");
                
            }
        }

        // Função para verificar se as credenciais são válidas (exemplo básico)
        private bool IsValidCredentials(string email, string password)
        {
           
            return email == "admin@email.com" && password == "1234";
        }
    }
}


