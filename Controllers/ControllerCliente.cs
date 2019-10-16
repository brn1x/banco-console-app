using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BancoWeb.Model;

namespace BancoConsole.Controllers
{
    public class ControllerCliente
    {
        static string url = "https://localhost:5001/api/cliente/";
        public async static Task getClientes()
        {
            var clientes = await Requests.Get<List<Cliente>>(url);
            foreach (var iterator in clientes)
            {
                Console.WriteLine($"Cliente número {iterator.id} nome {iterator.nome}");
            }
        }

        public async static Task getClienteById(int id)
        {
            await Requests.Get<Cliente>(url + id);
        }

        public async static Task addCliente()
        {
            Cliente cli = new Cliente();
            Console.WriteLine("Digite o nome do Cliente");
            cli.nome = Console.ReadLine();
            await Requests.Post<Cliente>(url, cli);
        }
    }
}