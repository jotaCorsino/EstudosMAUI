using BlocoDeNotas.Models;

namespace BlocoDeNotas.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class NotePage : ContentPage
{

    public string ItemId
    {
        set
        {
            LoadNote(value);
        }
    }

    //string fileName = Path.Combine(FileSystem.AppDataDirectory, "nota.txt"); // uma única nota
    public NotePage()
    {
        InitializeComponent();

        //criar uma nota com nome aleatorio quando for adicionar uma nova nota
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void BtnSalvar_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
        {
            File.WriteAllText(note.FileName, EditorTexto.Text);
        }

        await Shell.Current.GoToAsync("..");

    }

    private async void BtnExcluir_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
        {
            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
                DisplayAlert("A nota foi deletada!", "", "Ok");
                //EditorTexto.Text = string.Empty;
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                DisplayAlert("Erro ao deletar a nota!", "", "Ok");
            }
        }

    }

    public void LoadNote(string fileName)
    {
        Note note = new Note();
        note.FileName = fileName;
        if (File.Exists(fileName))
        {
            note.Date = File.GetCreationTime(fileName);
            note.Text = File.ReadAllText(fileName);
        }

        BindingContext = note;
    }
}