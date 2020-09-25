using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaluacionTecnica.Pantallas
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection("Data source=DESKTOP-LRRUQCG; Initial Catalog=Empresa; User=sae; Password=sae");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Inicio();
        }
        protected void Inicio()
        {
            string script = "alert('Usuario o contraseña incorrecto')";
            if (txtUsuario.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                string usuario = Convert.ToString(txtUsuario.Text);
                string password = Convert.ToString(txtPassword.Text);
                string user="", pass="";
                int ID = 0; 
                try
                {
                    conexion.Open();
                    string query = "select * from sucursales where Nombre_suc = '" + usuario + "' and Contraseña = '" + password + "'";
                    SqlCommand selec = new SqlCommand(query, conexion);
                    SqlDataReader registros = selec.ExecuteReader();
                    if (registros.Read())
                    {
                        ID = Convert.ToInt32(registros["ID_Sucursal"]);
                        Session["ID_s"] = ID;
                        user = Convert.ToString(registros["Nombre_suc"]);
                        pass = Convert.ToString(registros["Contraseña"]);
                    }
                    conexion.Close();
                    if (user.Length > 0 && pass.Length > 0)
                    {
                        HttpContext.Current.Response.Redirect("../Pantallas/Inventario.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script+ex, true);
                }
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblTitulo.Visible = false;
            lblTitulo2.Visible = true;
            btnCrear.Visible = true;
            btnRegresa.Visible = true;
            btnInicio.Visible = false;
            btnAgregar.Visible = false;
        }

        protected void btnRegresa_Click(object sender, EventArgs e)
        {
            btnCrear.Visible = false;
            btnRegresa.Visible = false;
            btnInicio.Visible = true;
            btnAgregar.Visible = true;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string usuario = Convert.ToString(txtUsuario.Text);
            string pass = Convert.ToString(txtPassword.Text);
            conexion.Open();
            string query = "insert into sucursales (Nombre_suc,Contraseña) values ('"+usuario+"','"+pass+"')";
            SqlCommand insertar = new SqlCommand (query, conexion);
            insertar.ExecuteNonQuery();
            conexion.Close();
        }
    }
}