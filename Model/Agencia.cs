using System.Collections.Generic;

namespace BancoWeb.Model
{
    public class Agencia
    {
        public int id { get; set; }

        public string nome { get; set; }

        public virtual List<Conta> listaConta { get; set; }
    }
}