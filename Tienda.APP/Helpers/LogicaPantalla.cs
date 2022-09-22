using Microsoft.Extensions.Configuration;
using System.Configuration;
using Tienda.APP.Ventas.Services;

namespace Tienda.APP.Helpers
{
    public class LogicaPantalla
    {
        private readonly IConfiguration _config;
        private int tableWidth = 100;


        public LogicaPantalla(IConfiguration config)
        {
            _config = config;
        }

        public void imprimirEncabezado(ConsoleColor color, string titulo)
        {
            Console.Clear();
            Console.Write("\n-----------------------------------------------------------------------------------------\n\n");
            Console.ForegroundColor = color;
            Console.Write("\t\t    Trabajo Practico integrador ");
            Console.Write("- " + titulo + "\r\n");
            Console.ResetColor();
            Console.Write("\n-----------------------------------------------------------------------------------------\n\n\n");
        }

        public void imprimirPie()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\n - Materia: " + _config.GetSection("Materia").Value);
            Console.Write("\n - Profesor: "+ _config.GetSection("Profesor").Value);
            Console.ResetColor();
        }

        public void imprimirMenu(List<string> lOpciones)
        {
            int cont = 0;
            foreach (string opcion in lOpciones)
            {
                cont++;
                Console.WriteLine(string.Format("{0}. {1}", cont.ToString(), opcion));
            }
            Console.Write("\n\n\n-----------------------------------------------------------------------------------------\n");

        }

        public void imprimirDespedida(string mensaje)
        {
            Console.Clear();
            Console.Write("\n-----------------------------------------------------------------------------------------\n\n");
            Console.Write("\t\t" + mensaje + "...\r\n");
            Console.Write("\n-----------------------------------------------------------------------------------------\n\n\n\t");
            Thread.Sleep(1000);
        }
        
        public void imprimirColumna( params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCenter(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public void imprimirColumnaHead(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCenter(column, width) + "|";
            }

            Console.WriteLine(row);
            Console.Write("------------------------------------------------------------------------------------------------------\n");
        }

        private string AlignCenter(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }

            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        public void imprimirSalida()
        {
            Console.Write("\n\n\n-------------------------------------------------------------------------------------------\n");
            Console.Write("\r\n\r\nPresione enter para finalizar...\r\n");
            Console.ReadKey();
        }

        public void imprimirResultado(string mensaje, bool resultado)
        {
            Console.Write(mensaje + " ---> ");

            if (resultado)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("MAL");
            }

            Console.ResetColor();
        }
        public string obtenerValorSoloLetras(string atributo)
        {
            Console.Write(string.Format("Ingrese {0}: ", atributo));
            string valor = Console.ReadLine();

            while (!valor.All(Char.IsLetter) || valor.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(string.Format("Ingrese {0} valido: ", atributo));
                valor = Console.ReadLine();
                Console.ResetColor();
            }

            return valor;
        }
        public string obtenerValorSoloNumeros(string atributo)
        {
            Console.Write(string.Format("Ingrese {0}: ", atributo));
            string valor = Console.ReadLine();

            while (!valor.All(Char.IsNumber) || valor.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(string.Format("Ingrese {0} valido: ", atributo));
                valor = Console.ReadLine();
                Console.ResetColor();
            }

            return valor;
        }
        public string obtenerValor(string atributo)
        {
            Console.Write(string.Format("Ingrese {0}: ", atributo));
            string valor = Console.ReadLine();

            return valor;
        }
        public string obtenerValorSoloLetras(string atributo, int length)
        {
            Console.Write(string.Format("Ingrese {0}: ", atributo));
            string valor = Console.ReadLine();

            while (!valor.All(Char.IsLetter) || valor.Length == 0 || valor.Length > length)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(string.Format("Ingrese {0} valido: ", atributo));
                valor = Console.ReadLine();
                Console.ResetColor();
            }

            return valor;
        }
        public string obtenerValorSoloNumeros(string atributo, int length)
        {
            Console.Write(string.Format("Ingrese {0}: ", atributo));
            string valor = Console.ReadLine();

            while (!valor.All(Char.IsNumber) || valor.Length == 0 || valor.Length > length)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(string.Format("Ingrese {0} valido: ", atributo));
                valor = Console.ReadLine();
                Console.ResetColor();
            }

            return valor;
        }
        public string obtenerValor(string atributo, int length)
        {
            Console.Write(string.Format("Ingrese {0}: ", atributo));
            string valor = Console.ReadLine();

            while (valor.Length == 0 || valor.Length > length)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(string.Format("Ingrese {0} valido: ", atributo));
                valor = Console.ReadLine();
                Console.ResetColor();
            }

            return valor;
        }

    }
}
