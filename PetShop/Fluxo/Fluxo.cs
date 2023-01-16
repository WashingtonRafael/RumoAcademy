using Microsoft.VisualBasic.FileIO;
using PetShop.Filtros;
using PetShop.Modelos;
using PetShop.Visualizacao;
using PetShop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Fluxo
{
    public class Controle
    {
        public List<Cliente> ListaDeClientes = new List<Cliente>();

        public bool CadastrarCliente(string nome, string cpf, string data)
        {
            Cliente cliente = new Cliente();
            FiltroDeDados filtro = new FiltroDeDados();

            var dataValida = filtro.ConversaoData(data);
            var cpfValidado = filtro.ConversaoCPF(cpf);

            cliente.Nome = nome.ToUpper().Trim();
            cliente.CPF = cpfValidado;
            cliente.DataNascimento = Convert.ToDateTime(dataValida);

            ListaDeClientes.Add(cliente);

            return true;
        }

        public Cliente BuscarCliente(string valor)
        {
            Cliente clientes = new Cliente();
            FiltroDeDados filtro = new FiltroDeDados();

            Cliente clienteEncontrado = null;

            clienteEncontrado = ListaDeClientes.FirstOrDefault(x => x.CPF.Contains(valor));
            if (clienteEncontrado == null)
            {
                clienteEncontrado = ListaDeClientes.FirstOrDefault(x => x.CPF.Contains(valor));
                if (clienteEncontrado == null)
                {
                    var cpfValidado = filtro.ConversaoCPF(valor);
                    clienteEncontrado = ListaDeClientes.FirstOrDefault(x => x.CPF.Contains(cpfValidado));

                    return clienteEncontrado;
                }

            }
            return clienteEncontrado;

        }

        public List<Cliente> BuscarAniversariantesMes()
        {
            List<Cliente> Aniversariantes = new List<Cliente>();

            foreach (var cliente in ListaDeClientes)
            {
                if (cliente.DataNascimento.Month == DateTime.Now.Month)
                {
                    Aniversariantes.Add(cliente);
                }
            }
            return Aniversariantes;
        }
        public void ClientesCadastrados()
        {
            var titulo = new Titulos();
            titulo.ListaClientes();


            foreach (var cliente in ListaDeClientes)
            {
                Console.WriteLine($"Cliente: {cliente.Nome.ToUpper()} || CPF: {cliente.CPF} || Data de nascimento: {cliente.DataNascimento.ToString("dd/MM/yyy")}\n\n");
            }

            Start repetir = new Start();
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu.\n");
            Console.ReadKey();
            repetir.FluxoHome();
        }
    }
}