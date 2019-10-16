using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BancoWeb.Model;
using BancoWeb.View;

namespace BancoConsole.Controllers
{
    public class ControllerAgencia
    {
        static string url = "https://localhost:5001/api/agencia/";
        public async static Task getAgencias()
        {
            var agencias = await Requests.Get<List<AgenciaView>>(url);
            foreach (var iterator in agencias)
            {
                Console.WriteLine($"Agencia Número: {iterator.id} nome {iterator.nomeAgencia}");
            }
        }

        public async static Task getAgenciaById(int id)
        {
            await Requests.Get<AgenciaView>(url + id);
        }
        public async static Task addAgencia()
        {
            Agencia ag = new Agencia();
            Console.WriteLine("Digite o nome da agencia");
            ag.nome = Console.ReadLine();
            await Requests.Post<Agencia>(url, ag);
        }
    }
}