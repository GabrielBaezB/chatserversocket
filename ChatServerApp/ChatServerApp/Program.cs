using ChatServerApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando servidor {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);

            if(servidor.Iniciar())
            {
                while(true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Esperando conexion de Cliente");
                    if(servidor.ObtenerCliente())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Cliente Conectado!");
                        //Console.WriteLine("S: Hola Cliente!");
                        //servidor.Escribir("Hola Cliente!");
                        //string mensaje = servidor.Leer();
                        //Console.WriteLine("c: {0}", mensaje);
                        ////<CR><LF> salto de linea
                        //servidor.CerrarConexion();

                        //implementar protocolo
                        //1. El cliente inicia la comunicacion
                        //2. El servidor responde
                        //3. Si alguno de los extremos dice chao, la comunicacion se finaliza
                        string mensaje = "";
                            while(mensaje.ToLower() != "chao")
                        {
                            mensaje = servidor.Leer();
                            Console.WriteLine("C:{0}", mensaje);
                            if(mensaje.ToLower() != "chao")
                            {
                                Console.WriteLine("Digame lo que quiere decirle guruguru");
                                mensaje = Console.ReadLine().Trim();
                                Console.WriteLine("S:{0}", mensaje);
                                servidor.Escribir(mensaje);
                            }
                        }
                        servidor.CerrarConexion();

                    }
                }          
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error al iniciar al servidor");
                Console.ReadKey();
            }
        }
    }
}
