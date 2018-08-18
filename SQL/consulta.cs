using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
  public  class consulta
    {

        private string id_tarjeta;

        public string Id_tarjeta { get => id_tarjeta; set => id_tarjeta = value; }

        public string consultar()
        {
            return "SELECT saldo FROM Pacientes WHERE(Nombres LIKE '" + this.id_tarjeta + "%')";
        }
    }
}
