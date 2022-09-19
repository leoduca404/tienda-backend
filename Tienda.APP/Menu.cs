using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private readonly CarritoController _carritoController;

        public Menu(ClienteController clienteController, CarritoController carritoController)
        {
            _clienteController = clienteController;
            _carritoController = carritoController;
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
                            await RegistrarVentas();
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

        public async Task RegistrarVentas()
        {
            LogicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Registrar Ventas");

            //Busco el cliente y valido que exista.
            string clienteId;
            clienteId = obtenerValorSoloNumeros("ClienteId");

            //TODO: NO DEBERIA SER UN CLIENTE SINO UNA INTERFACE DE ICLIENTE
            Cliente cliente;            
            cliente = _clienteController.GetById(Int32.Parse(clienteId));

            while (cliente == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Format("Ingrese cliente valido"));
                clienteId = obtenerValorSoloNumeros("ClienteId");
                Console.ResetColor();
                cliente = _clienteController.GetById(Int32.Parse(clienteId));
            }

            //Creo el carrito para el cliente.
            Carrito carrito;
            carrito = await _carritoController.Add(cliente);


            //Registro ventas

            Console.Write("\n--------------------------------------------------------------------------------\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Operación Exitosa.\n"));
            Console.WriteLine(string.Format("\t- El Cliente '{0}' fue dado de alta correctamente", cliente.Nombre));
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
