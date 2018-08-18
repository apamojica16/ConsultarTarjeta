using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SQL
{
   public class sql
    {
        private string sentenciaSQL1;

        private string mensaje;

        System.Data.OleDb.OleDbConnection conn;
        System.Data.OleDb.OleDbTransaction miTran;
        SqlConnection MiConexion;

        public void Conexion()
        {
            //       conn = new System.Data.OleDb.OleDbConnection();

            //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=D:\Ventas.mdb";
            //            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Consultorio.accdb;Persist Security Info=False";
            MiConexion = new SqlConnection("Data Source=DESKTOP-78R5FNV\\SQLEXPRESS;Initial Catalog=saldo;Integrated Security=False;User Id=prueba;Password=prueba16;MultipleActiveResultSets=True");
            //      MiConexion.Open();
        }

        public void SetSentencia1(string s1)
        {
            sentenciaSQL1 = s1;
        }


        public System.Data.DataSet Consultar()
        {
            try
            {
                // conn.Open();
                MiConexion.Open();
                //  System.Data.OleDb.OleDbDataAdapter objRes;// se referencia el objeto dataadapter
                // objRes = new System.Data.OleDb.OleDbDataAdapter(sentenciaSQL1, conn);// se instancia el objeto dataadapter
                SqlDataAdapter objRes = new SqlDataAdapter(sentenciaSQL1, MiConexion);
                System.Data.DataSet datos = new System.Data.DataSet();
                objRes.Fill(datos, "Tabla");// se llena el dataset "datos" con la tabla virtual "Tabla"
                mensaje = "Todo OK";
                return datos;
            }
            catch (Exception MiExc)
            {
                System.Data.DataSet datos2 = new System.Data.DataSet();
                mensaje = "Se presento el Siguiente Error " + MiExc.Message;
                return datos2;

            }
            finally
            {
                MiConexion.Close();
            }
        }

        public string EjecutarSQL1()//este metodo se usa para operaciones de crear, modificar y eliminar
        {
            try
            {
                // System.Data.OleDb.OleDbCommand miComando = new System.Data.OleDb.OleDbCommand();
                //miComando.Connection=conn;//se relaciona el objeto comando con el objeto conexion
                MiConexion.Open();//abri la conexion
                SqlCommand MiComando = new SqlCommand(sentenciaSQL1, MiConexion);
                MiComando.ExecuteNonQuery();
                //string g = MiComando.ExecuteScalar().ToString();

                return "Todo OK";
            }
            catch (Exception e)
            {
                miTran.Rollback();// anula operacion
                return "Se presento el siguiente error " + e.Message;
            }
            finally
            {
                MiConexion.Close();
            }
        }


        public string getmen()
        {
            return mensaje;
        }




        public string consultaruno()
        {
            int seleccionados; // se define un entero para manejar el resultado de la consulta

            System.Data.OleDb.OleDbDataAdapter objSql2;// se referencia un objeto ObjSql2 de la clase OleDbDataAdapter se utilizan para rellenar DataSet y actualizar el origen de datos.
            objSql2 = new System.Data.OleDb.OleDbDataAdapter(sentenciaSQL1, conn);//se instancia el objeto ObjSql2 que recibe dos parametros el String con la sentencia SQL y el objeto OleDbConnection

            System.Data.DataSet ds2 = new System.Data.DataSet();// se instancia el objeto ds2  de la clase Dataset
            objSql2.Fill(ds2, "tabla1");//Agrega filas a DataSet o las actualiza para hacerlas coincidir con las filas del origen de datos utilizando una tabla "tabla1"

            seleccionados = ds2.Tables["tabla1"].Rows.Count;//retorna el Número de filas agregadas o actualizadas correctamente 
            if (seleccionados == 0)//si  no encontro registro
            {
                return " No se encuentra el nombre ";// mensaje retornado al no encontrar registro de consulta
            }
            else
            {
                string a;
                a = ds2.Tables["tabla1"].Rows[0][0].ToString();
                return a;
            }

        }
    }
}
