using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace consumir_ws
{
    public partial class Listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se agrega la referencia de servicio con el proyecto webservice creado
            // se instancia el nombre del archivo webservice
            Ws_listado.WebService1SoapClient ws = new Ws_listado.WebService1SoapClient();
            //la definicion del dataset se asocia a un metodo del objeto instanciado del webservice.
            DataSet ds = ws.listado_control();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
}