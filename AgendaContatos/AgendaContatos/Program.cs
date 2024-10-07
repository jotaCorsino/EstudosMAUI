using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaContatos.Models;

namespace AgendaContatos
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();

            int opcao = -1;
            while(opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("[ Agenda de contatos ]");
                Console.WriteLine();
                Console.WriteLine("Escolha uma opção");
                Console.WriteLine(" 1 - Cadastrar Contato");
                Console.WriteLine(" 2 - Editar Contato");
                Console.WriteLine(" 3 - Listar Contato");
                Console.WriteLine(" 4 - Remover Contato");
                Console.WriteLine(" 0 - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        break;
                    case 1:
                        agenda.CadastroContato();
                        break;
                    case 2:
                        agenda.EditarContato();
                        break;
                    case 3:
                        agenda.ListarContatos();
                        break;
                    case 4:
                        agenda.RemoverContato();
                        break;


                }
            }
        }
    }
}
