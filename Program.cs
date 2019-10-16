using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BancoConsole.View;
using BancoConsole.Controllers;
using System.Net;

namespace BancoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Valida o certificado SSL */
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => { return true; };

            int opc = 1;

            while (opc != 0)
            {
                Console.WriteLine("1- Add Cliente");
                Console.WriteLine("2- Add Agencia");
                Console.WriteLine("3- Add Conta");
                Console.WriteLine("4- Depositar na conta");
                Console.WriteLine("5- Saque Conta");
                Console.WriteLine("6- Listar Contas");
                Console.WriteLine("7- Listar Clientes");
                Console.WriteLine("8- Listar Agencias");
                Console.WriteLine("0- Sair");
                Console.WriteLine("Digite sua ação: ");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("-- Adicionar Cliente --");
                        ControllerCliente.addCliente().GetAwaiter().GetResult();
                        break;
                    case 2:
                        Console.WriteLine("-- Adicionar Agencia --");
                        ControllerAgencia.addAgencia().GetAwaiter().GetResult();
                        break;
                    case 3:
                        Console.WriteLine("-- Adicionar Conta --");
                        ControllerConta.addConta().GetAwaiter().GetResult();
                        break;
                    case 4:
                        Console.WriteLine("-- Depositar na Conta --");
                        ControllerConta.depositar().GetAwaiter().GetResult();
                        break;
                    case 5:
                        Console.WriteLine("-- Sacar da Conta --");
                        ControllerConta.sacar().GetAwaiter().GetResult();
                        break;
                    case 6:
                        Console.WriteLine("-- Lista de Contas --");
                        ControllerConta.getContas().GetAwaiter().GetResult();
                        break;
                    case 7:
                        Console.WriteLine("-- Lista de Clientes --");
                        ControllerCliente.getClientes().GetAwaiter().GetResult();
                        break;
                    case 8:
                        Console.WriteLine("-- Lista de Agencias --");
                        ControllerAgencia.getAgencias().GetAwaiter().GetResult();
                        break;
                    case 0:
                        Console.WriteLine("-- SAIR --");
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
