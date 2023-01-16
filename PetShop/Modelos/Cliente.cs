using PetShop.Fluxo;
using PetShop.Filtros;
using PetShop.Modelos;
using PetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
