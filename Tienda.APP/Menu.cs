using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.APP.Helpers;

namespace Tienda.APP
{
    public class Menu
    {
        static bool exit = false;
        public static void InicializarMenu()
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
    }
}
