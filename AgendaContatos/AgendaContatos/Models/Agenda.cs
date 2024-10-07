using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Models
{
    internal class Agenda
    {
        List<Contato> contatos = new List<Contato>();
        private int autoId = 1;

        public void CadastroContato()
        {
            Console.Clear();
            Console.WriteLine("[ Cadastro de Contato ]");
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o e-mail: ");
            string email = Console.ReadLine();
            Console.Write("Digite o celular: ");
            string celular = Console.ReadLine();

            contatos.Add(new Contato(autoId, nome, email, celular));
            autoId++;

            Console.WriteLine("Contato cadastrado com sucesso!");
            Console.ReadKey();

        }

        public void ListarContatos()
        {
            Console.WriteLine("[ Contatos cadastrados ]");
            Console.WriteLine("------------------------------------------");
            foreach (Contato contato in contatos)
            {
                Console.WriteLine($"Id: {contato.Id},  Nome: {contato.Nome},  Email: {contato.Email},  Celular: {contato.Celular}");

            }
            Console.WriteLine("------------------------------------------");
            Console.ReadKey();
        }

        public void EditarContato()
        {
            Console.Clear();
            Console.WriteLine("[ Editar Contato ]");
            Console.Write("Digite o Id do contato: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Contato contato = contatos.FirstOrDefault(c => c.Id == id);
            if (contato != null)
            {
                int opcao = -1;

                while (opcao != 0)
                {
                    Console.Clear();
                    Console.WriteLine("[ Editar Contato ]");
                    Console.WriteLine("Contato selecionado:");
                    Console.WriteLine($"Nome: {contato.Nome},  Email: {contato.Email},  Celular: {contato.Celular}");
                    Console.WriteLine();
                    Console.WriteLine("Opções de edição:");
                    Console.WriteLine("1 - Nome");
                    Console.WriteLine("2 - E-mail");
                    Console.WriteLine("3 - Celular");
                    Console.WriteLine("0 - Sair");
                    opcao = Convert.ToInt32(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.Write("Digite o nome: ");
                            string nome = Console.ReadLine();
                            if (nome == null)
                            {
                                Console.WriteLine("O nome não pode estar vazio.");
                            }
                            else
                            {
                                contato.Nome = nome;
                            }
                            break;
                        case 2:
                            Console.WriteLine();
                            Console.Write("Digite o email: ");
                            string email = Console.ReadLine();
                            if (email == null)
                            {
                                Console.WriteLine("O email não pode estar vazio.");
                            }
                            else
                            {
                                contato.Email = email;
                            }
                            break;
                        case 3:
                            Console.WriteLine();
                            Console.Write("Digite o celular: ");
                            string celular = Console.ReadLine();
                            if (celular == null)
                            {
                                Console.WriteLine("O celular não pode estar vazio.");
                            }
                            else
                            {
                                contato.Celular = celular;
                            }
                            break;

                        case 0:
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }

        }

        public void RemoverContato()
        {
            Console.Clear();
            Console.WriteLine("[ Excluir Contato ]");
            Console.Write("Digite o Id do contato: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Contato contato = contatos.FirstOrDefault(c => c.Id == id);
            if (contato != null)
            {
                contatos.Remove(contato);
                Console.WriteLine("Contato removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Contato não encontrado");
            }
        }
    }
}
