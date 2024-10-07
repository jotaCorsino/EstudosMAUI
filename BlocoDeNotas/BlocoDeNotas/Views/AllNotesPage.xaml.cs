using BlocoDeNotas.Models;
namespace BlocoDeNotas.Views;

public partial class AllNotesPage : ContentPage
{
	public AllNotesPage()
	{
		InitializeComponent();
		BindingContext = new AllNotes();
	}

    protected override void OnAppearing()
    {
		// atualiza a tela de todas as notas sempre que uma nova nota é criada
		((AllNotes)BindingContext).LoadNotes();
    }

    private async void AllNotesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection.Count != 0)
        {
            //pega a nota selecionada
            var note = (Note)e.CurrentSelection[0];
            // chama a tela de notes
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.FileName}");
            //libera o item selcionado
            AllNotesList.SelectedItem = null;
        }
    }

    private async void ItemAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }
}