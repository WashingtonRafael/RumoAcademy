using PetShop.Fluxo;
using PetShop.Filtros;
using PetShop.Modelos;
using PetShop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Visualizacao
{
    public class Start
    {
        
        Controle funcCliente = new Controle();
        FiltroDeDados filtro = new FiltroDeDados();
        Titulos titulo = new Titulos();
        public void FluxoHome()
        {

            while (true)
            {
                Console.Clear();
                titulo.TituloInicio();
                Console.WriteLine("     DIGITE A OPÇÃO DESEJADA\n");
                Console.WriteLine("\n     [1] - Cadastrar novo cliente");
                Console.WriteLine("\n     [2] - Visualizar clientes cadastrados");
                Console.WriteLine("\n     [3] - Buscar cliente por CPF");
                Console.WriteLine("\n     [4] - Listar aniversariantes");
                Console.WriteLine("\n     [0] - Sair\n\n");
                var opcao = (Console.ReadLine());
                var caso = new Start();

                
                
                switch (opcao)
                {
                    case "1":
                            Console.Clear();
                            CadastrarCliente();
                            break;
                    case "2":
                            Console.Clear();
                            funcCliente.ClientesCadastrados();
                            break;
                    case "3":
                            Console.Clear();
                            BuscarCliente();
                            break;
                    case "4":
                            Console.Clear();
                            BuscarAniversariante();
                            break;
                    case "0":
                            Console.Clear();
                            titulo.Encerrarsistema();
                            Environment.Exit(10000);
                            break;
                    default:
                            Console.Clear();
                            titulo.TituloErro();
                            Console.WriteLine("\n\nEscolha uma opção válida!");
                            Task.Delay(3000).Wait();
                            FluxoHome();
                            break;
                }
            }
        }

        public void CadastrarCliente()
        {
            Titulos titulo = new Titulos();
            titulo.TituloCadastro();
            Console.WriteLine("\n\nInsira o nome do cliente: \n");
            var nome = Console.ReadLine();
            if (!filtro.TratarNome(nome))
                throw new InvalidOperationException("\nInsira um nome que contenha entre 3 e 80 caracteres!\n");

            Console.WriteLine("\nInsira o CPF do cliente: (000.000.000-00) \n");
            var CPF = Console.ReadLine();
            if (!filtro.TratarCPF(CPF))
                throw new InvalidOperationException("\nErro! CPF inválido!\n");

            Console.Write("\nInsira a data de nascimento: (dd/mm/aaaa) \n");
            var dataNascimento = Console.ReadLine();
            if (!filtro.TratarNascimento(dataNascimento))
                throw new InvalidOperationException("\nErro! Cliente precisa ter entre 16 e 120 anos!\n");

            var cadastrado = funcCliente.CadastrarCliente(nome, CPF, dataNascimento);

            if (!cadastrado)
                throw new InvalidOperationException("\nErro! Data de nascimento inválida!\n");
            
            Task.Delay(2000).Wait();
            Console.Clear();
            titulo.CadastroSucesso();
            Task.Delay(2000).Wait();
            FluxoHome();

        }

        public void BuscarCliente()
        {
            Console.Clear();
            titulo.BuscaClientes();

            Console.WriteLine("\n\nInsira o CPF procurado: (123.456.789-00)\n ");
            var CPF = Console.ReadLine();
            if (!filtro.TratarCPF(CPF))
            {
                Console.WriteLine("\nErro! CPF inválido!");
                Task.Delay(2000);
                BuscarCliente();
            }

            Cliente clienteEncontrado = funcCliente.BuscarCliente(CPF);

            if (clienteEncontrado == null)
            {
                Console.WriteLine("\nErro! CPF inválido ou inexistente!");
                Task.Delay(2000);
                BuscarCliente();
            }

            Console.Clear();
            titulo.ClienteEncontrado();
            Console.WriteLine($"\n\nCliente: {clienteEncontrado.Nome} || CPF: {clienteEncontrado.CPF} || Data de Nasci: {clienteEncontrado.DataNascimento.ToString("dd/MM/yyyy")}\n");
            Console.WriteLine("\n\nPressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            FluxoHome();
        }

        public void BuscarAniversariante()
        {
            titulo.Aniversariantes();

            List<Cliente> Aniversariantes = funcCliente.BuscarAniversariantesMes();

           

            foreach (var cliente in Aniversariantes)
            {
                Console.WriteLine($"Cliente: {cliente.Nome.ToUpper()} || CPF: {cliente.CPF} || Data de nascimento: {cliente.DataNascimento.ToString("dd/MM/yyyy")}\n");
            }

            Console.Write("\n\nPressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            FluxoHome();
        }
    }
}