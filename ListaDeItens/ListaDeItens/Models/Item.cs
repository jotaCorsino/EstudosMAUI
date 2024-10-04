using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeItens.Models
{
    public class Item
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Item()
        {

        }

        public Item(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
