namespace BancoWeb.Model
{
    public class Conta
    {
        public int id { get; set; }
        public double saldo { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Agencia agencia { get; set; }

        public void Depositar(double deposito)
        {
            saldo += deposito;
        }

        public int Sacar(double saque)
        {
            if (saque < saldo)
            {
                saldo -= saque;

                return 1;
            }
            return 0;
        }
    }
}