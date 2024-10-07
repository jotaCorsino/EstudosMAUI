using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos.Models
{
    internal class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public Contato(int id, string nome, string email, string celular)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Celular = celular;
        }
    }
}
