using System.Threading.Tasks;
using BancoWeb.Model;
using System;
using System.Collections.Generic;
using BancoConsole.View;
using BancoWeb.View;

namespace BancoConsole.Controllers
{
    public class ControllerConta
    {
        static string url = "https://localhost:5001/api/conta/";
        public async static Task addConta()
        {
            Conta conta = new Conta();
            Agencia ag = new Agencia();
            Cliente cli = new Cliente();

            ControllerAgencia.getAgencias().GetAwaiter().GetResult();
            Console.WriteLine("Digite o ID da Agencia");
            int agenciaID = int.Parse(Console.ReadLine());
            ag = Requests.Get<Agencia>($"https://localhost:5001/api/agencia/true/{agenciaID}").GetAwaiter().GetResult();

            ControllerCliente.getClientes().GetAwaiter().GetResult();
            Console.WriteLine("Digite o ID do Cliente");
            int clienteID = int.Parse(Console.ReadLine());
            cli = Requests.Get<Cliente>($"https://localhost:5001/api/cliente/{clienteID}").GetAwaiter().GetResult();

            conta.agencia = ag;
            conta.cliente = cli;
            conta.saldo = 0;

            await Requests.Post<Conta>(url, conta);
        }

        public static async Task getContas()
        {
            var contas = await Requests.Get<List<ContaView>>(url);
            foreach (var iterator in contas)
            {
                Console.WriteLine($"Conta Número: {iterator.id} do Cliente {iterator.nomeCliente} da Agencia {iterator.nomeAgencia} com o saldo de {iterator.saldo}R$");
            }
        }

        public static async Task getContaById(int id)
        {
            var conta = await Requests.Get<ContaView>(url + id);
            Console.WriteLine($"Conta número {conta.id} do Cliente {conta.nomeCliente} da Agencia {conta.nomeAgencia} com o saldo de {conta.saldo}");
        }

        // Fazer request direto para ter acesso as variaveis
        public static async Task depositar()
        {
            ContaDepositoView depositoView = new ContaDepositoView();
            
            getContas().GetAwaiter().GetResult();
            Console.WriteLine("Digite o número da conta a ser depositada");
            int contaId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantia a ser depositada");
            double deposito = double.Parse(Console.ReadLine());

            depositoView.deposito = deposito;
            depositoView.id = contaId;

            await Requests.Post<ContaDepositoView>(url + "depositar", depositoView);
        }

        public static async Task sacar()
        {
            ContaSaqueView saqueView = new ContaSaqueView();

            getContas().GetAwaiter().GetResult();
            Console.WriteLine("Digite o número da conta para efetuar o saque");
            int contaId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantia a ser sacada");
            double saque = double.Parse(Console.ReadLine());

            saqueView.id = contaId;
            saqueView.saque = saque;

            await Requests.Post<ContaSaqueView>(url + "sacar", saqueView);
        }
    }
}