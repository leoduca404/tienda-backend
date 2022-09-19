using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tienda.APP.Controllers;
using Tienda.APP.Helpers;

namespace Tienda.APP
{
    public class Menu
    {
        private readonly ClienteController _clienteController;
        public Menu(ClienteController clienteController)
        {
            _clienteController = clienteController;
        }

        static bool exit = false;
        public async Task InicializarMenu()
        {
            while (!exit)
            {
                Console.ResetColor();
                LogicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Tienda Leo");
                LogicaPantalla.imprimirMenu(new List<string>() { "Registrar Cliente", "Registrar ventas del día", "Reportes de ventas del día", "Busquedas por producto", "Salir" });
                LogicaPantalla.imprimirPie();

                ConsoleKeyInfo key = Console.ReadKey();
                char caracter = key.KeyChar;

                switch (caracter)
                {
                    case '1':
                        {
                            await RegistrarCliente();
                            break;
                        }
                    case '2':
                        {
                           
                            break;
                        }
                    case '3':
                        {
                           
                            break;
                        }
                    case '4':
                        {
                            
                            break;
                        }
                    case '5':
                        {
                            LogicaPantalla.imprimirDespedida("Cerrando...");
                            exit = true;
                            break;
                        }
                }
            }
        }

        public async Task RegistrarCliente()
        {
            LogicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Registrar Cliente");
            string nombre, apellido, dni, direccion, telefono;
            nombre = obtenerValorSoloLetras("nombre");
            apellido = obtenerValorSoloLetras("apellido");
            dni = obtenerValorSoloNumeros("DNI");
            direccion= obtenerValor("direccion");
            telefono = obtenerValorSoloNumeros("telefono");

            await _clienteController.AddCliente(nombre, apellido, dni, direccion, telefono);

            Console.Write("\n--------------------------------------------------------------------------------\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Operación Exitosa.\n"));
            Console.WriteLine(string.Format("\t- El Cliente '{0}' fue dado de alta correctamente", nombre));
            LogicaPantalla.imprimirSalida();
        }
        public static string obtenerValorSoloLetras(string atributo)
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
        public static string obtenerValorSoloNumeros(string atributo)
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

        public static string obtenerValor(string atributo)
        {
            Console.Write(string.Format("Ingrese {0}: ", atributo));
            string valor = Console.ReadLine();      

            return valor;
        }
    }
}
