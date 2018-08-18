using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace consultatarjeta
{
    /// <summary>
    /// Descripción breve de ConsultaTarjeta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsultaTarjeta : System.Web.Services.WebService
    {
        SQL.consulta consulta = new SQL.consulta();
        SQL.sql sql = new SQL.sql();

        string saldo;


        [WebMethod]
        public string consultarsaldo(string ID_tarjeta)
        {
          consulta.Id_tarjeta=  ID_tarjeta;
            sql.SetSentencia1(consulta.consultar());
            saldo = sql.EjecutarSQL1();
            return saldo;
        }
    }
}
