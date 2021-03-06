using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

namespace webservice
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]

        public DataSet listado_control()
        {
            //string s;
            //s = ConfigurationManager.ConnectionStrings("mtto").ConnectionString;

            // se debe agregar la referencia al proyecto de systemconfiguracion y agregar el using System.Configuration;

            string conn = ConfigurationManager.ConnectionStrings["mtto"].ConnectionString;
            string s;

            {
                SqlConnection conex = new SqlConnection(conn);
                SqlDataAdapter da = new SqlDataAdapter("select *from control", conex);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }


        [WebMethod]
        public DataSet listado_control_cedula(string cedula )
        {
            //string s;
            //s = ConfigurationManager.ConnectionStrings("mtto").ConnectionString;

            /// se debe agregar la referencia al proyecto de systemconfiguracion y agregar el using System.Configuration;

            string conn = ConfigurationManager.ConnectionStrings["mtto"].ConnectionString;
            string s;
            
            {
                SqlConnection conex = new SqlConnection(conn);
                SqlDataAdapter da = new SqlDataAdapter("select *from control where cedula =  '" +  cedula + "' ", conex);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }

        [WebMethod]

        public DataSet listado_control_sp()
        {

            string conn = ConfigurationManager.ConnectionStrings["mtto"].ConnectionString;
            string s;

            
            {
                SqlConnection conex = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("mostrar_control", conex);
                cmd.CommandType = CommandType.StoredProcedure;
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }

        }


        [WebMethod]

        public DataSet listado_control_sp_cedula(string cedula)
        {

            string conn = ConfigurationManager.ConnectionStrings["mtto"].ConnectionString;
            string s;


            {
                SqlConnection conex = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("mostrar_id_control_cedula", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cedula", SqlDbType.BigInt).Value = cedula;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }

        }


    }
}
