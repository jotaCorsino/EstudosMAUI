using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Models
{
    public class AllNotes
    {

        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public AllNotes() => LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            //Obtem a pasta onde as notas estão armazenadas.
            string appDataPath = FileSystem.AppDataDirectory;

            //Extensão Linq para carregar os arquivos *.notes.txt (todas as notas)
            //Seleciona os nomes dos arquivos no diretorio   //Cada nome de arquivo é uado para criar uma nova nota
            IEnumerable<Note> notes = Directory.EnumerateFiles(appDataPath, "*.notes.txt").Select(filename => new Note()
            {
                FileName = filename,
                Text = File.ReadAllText(filename),
                Date = File.GetCreationTime(filename)
            }).OrderBy(note => note.Date); // ordena a coleção de notas por data

            foreach (Note note in notes)
            {
                Notes.Add(note);
            }
        }

    }
}
