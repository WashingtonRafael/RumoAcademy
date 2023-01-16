using PetShop.Fluxo;
using PetShop.Modelos;
using PetShop.Visualizacao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetShop.Filtros
{
    public class FiltroDeDados
    {
        public bool TratarNome(string nome)
        {
            if (nome.Trim().Length >= 80 || nome.Trim().Length < 3)
            {
                return false;
            }
            return true;
        }

        public bool TratarCPF(string cpf)
        {
            string cpfValido = cpf.Replace(".", "");

            cpfValido = cpfValido.Replace("-", "");

            if (cpfValido.Length != 11)
            {
                return false;
            }
            return true;
        }

        public bool TratarNascimento(string dataNascimento)
        {
            DateTime data = Convert.ToDateTime(ConversaoData(dataNascimento));

            int anos = DateTime.Today.Year - data.Year;

            if (anos <= 16 || anos >= 120)
            {
                return false;
            }
            return true;
        }

        public string ConversaoData(string data)
        {
            string dataString = "";
            int dataInteiro = 0;

            if (data.Contains("/"))
            {
                var digitoData = string.Join("", data.ToCharArray().Where(Char.IsDigit));

                dataInteiro = Convert.ToInt32(digitoData);
                dataString = dataInteiro.ToString(@"00\/00\/0000");

                return dataString;
            }

            dataInteiro = Convert.ToInt32(data);
            dataString = dataInteiro.ToString(@"00\/00\/0000");

            return dataString;
        }
        public string ConversaoCPF(string cpf)
        {
            {
                if (cpf.Trim().Length < 3)
                {
                    Console.Clear();
                    Titulos titulo = new Titulos();
                    titulo.TituloErro();
                    Console.WriteLine("\n\nInsira o CPF completo.");
                }
            }
            long cpfInteiro = 0;
            string cpfString = "";

            if (cpf.Contains(".") || cpf.Contains("-"))
            {
                var cpfData = string.Join("", cpf.ToCharArray().Where(Char.IsDigit));

                cpfInteiro = Convert.ToInt64(cpfData);
                cpfString = cpfInteiro.ToString(@"000\.000\.000\-00");

                return cpfString;
            }
            else if (cpf == "" || cpf == " ")
            {
                return cpfString;
            }

            cpfInteiro = Convert.ToInt64(cpf);
            cpfString = cpfInteiro.ToString(@"000\.000\.000\-00");

            return cpfString;
        }
    }
}
