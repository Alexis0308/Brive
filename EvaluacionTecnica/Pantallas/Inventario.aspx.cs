using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaluacionTecnica.Pantallas
{
    public partial class Inventario : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection("Data source=DESKTOP-LRRUQCG; Initial Catalog=Empresa; User=sae; Password=sae");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AgregarGrid();
                DrSucursalMe();
            }
        }
        protected void AgregarGrid()
        {
            List<string> Lista = new List<string>();
            string Codigo="", Nombre="", Cantidad="", Sucursal="",con1 ="";
            string Precio_unitario = "";
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] {new DataColumn("Codigo de barras",typeof(string)),
                                                   new DataColumn("Nombre",typeof(string)),
                                                   new DataColumn("Cantidad",typeof(string)),
                                                   new DataColumn("Precio unitario",typeof(string)),
                                                   new DataColumn("Sucursal",typeof(string))});
            conexion.Open();
            string query = "select * from v_productos where ID_Sucursal = "+Session["ID_s"];
            SqlCommand productos = new SqlCommand(query,conexion);
            SqlDataReader registros = productos.ExecuteReader();
            while (registros.Read())
            {
                con1 = registros[0].ToString();
                Lista.Add(con1);
                for (int i = 0; i < Lista.Count; i++)
                {
                    Codigo = Convert.ToString(registros["Codigo_deBarras"]);
                    Nombre = Convert.ToString(registros["Nombre"]);
                    Cantidad = Convert.ToString(registros["Cantidad"]);
                    Precio_unitario = Convert.ToString(registros["Precio_unitario"]);
                    Sucursal = Convert.ToString(registros["Nombre_suc"]);
                }
                dt.Rows.Add(Codigo,Nombre,Cantidad,"$"+decimal.Parse(Precio_unitario).ToString("N"),Sucursal);
                grProductos.DataSource = dt;
                grProductos.DataBind();
            }
            conexion.Close();
        }

        protected void grProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            txtNombre.Enabled = false;
            lblCantidad.Visible = true;
            txtCantidad.Visible = true;
            lblCodigo.Visible = true;
            txtCodigo.Visible = true;
            txtCodigo.Enabled = false;
            lblPrecio.Visible = true;
            txtPrecio.Visible = true;
            txtPrecio.Enabled = false;
            lblSucursal.Visible = true;
            DrSucursal.Visible = true;
            DrSucursal.Enabled = false;
            btnActualizar.Visible = true;
            btnAgregar.Visible = false;
            string nombre = "", Codigo = "", Cantidad = "", Precio = "";
            int Sucursal = 0;
            GridViewRow row = grProductos.SelectedRow;
            int id = Convert.ToInt32(grProductos.DataKeys[row.RowIndex].Value);
            conexion.Open();
            string query = "select * from productos where Codigo_deBarras = '"+id+"'";
            SqlCommand productos = new SqlCommand(query,conexion);
            SqlDataReader registros = productos.ExecuteReader();
            if (registros.Read())
            {
                nombre = Convert.ToString(registros["Nombre"]);
                Codigo = Convert.ToString(registros["Codigo_deBarras"]);
                Cantidad = Convert.ToString(registros["Cantidad"]);
                Precio = Convert.ToString(registros["Precio_unitario"]);
                Sucursal = Convert.ToInt32(registros["Sucursal"]);
            }
            conexion.Close();
            txtNombre.Text = nombre;
            txtCodigo.Text = Codigo;
            txtCantidad.Text = Cantidad;
            txtPrecio.Text = "$" + decimal.Parse(Precio).ToString("N");
            DrSucursal.SelectedIndex = Sucursal;
        }
        private void DrSucursalMe()
        {
            DrSucursal.DataSource = Consultar("select * from sucursales");
            DrSucursal.DataTextField = "Nombre_suc";
            DrSucursal.DataValueField = "ID_Sucursal";
            DrSucursal.DataBind();
            DrSucursal.Items.Insert(0, new ListItem("Seleccionar..", "0"));
        }
        public DataSet Consultar(string strSQL)
        {
            string conexion = "Data source=DESKTOP-LRRUQCG; Initial Catalog=Empresa; User=sae; Password=sae";
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string script = "alert('Producto Actualizado')";
            string cantidad = txtCantidad.Text;
            string codigo = txtCodigo.Text;
            conexion.Open();
            string query = "update productos set Cantidad = "+cantidad+" where Codigo_deBarras='"+codigo+"' and Sucursal = "+ Session["ID_s"];
            SqlCommand productos = new SqlCommand(query, conexion);
            productos.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            conexion.Close();
            AgregarGrid();
        }
       
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            txtNombre.Enabled = true;
            txtNombre.Text = "";
            lblCantidad.Visible = true;
            txtCantidad.Visible = true;
            txtCantidad.Text = "";
            lblCodigo.Visible = true;
            txtCodigo.Visible = true;
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            lblPrecio.Visible = true;
            txtPrecio.Visible = true;
            txtPrecio.Enabled = true;
            txtPrecio.Text = "";
            lblSucursal.Visible = true;
            DrSucursal.Visible = true;
            DrSucursal.Enabled = true;
            DrSucursal.SelectedIndex = 0;
            btnAgregar.Visible = true;
            btnActualizar.Visible = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string script = "alert('Producto Agregado')";
            string nombre = Convert.ToString(txtNombre.Text);
            string codigo = Convert.ToString(txtCodigo.Text);
            string cantidad = Convert.ToString(txtCantidad.Text);
            string Precio = Convert.ToString(txtPrecio.Text);
            int sucursal = Convert.ToInt32(DrSucursal.SelectedValue);
            conexion.Open();
            string query = "insert into productos (Nombre,Codigo_deBarras,Cantidad,Precio_unitario,Sucursal) " +
                "values ('" + nombre + "','" + codigo + "'," + cantidad + "," + Precio + "," + sucursal + ")";
            SqlCommand insertar = new SqlCommand(query, conexion);
            insertar.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            conexion.Close();
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtCodigo.Text = "";
            txtPrecio.Text = "";
            DrSucursal.SelectedIndex = 0;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Pantallas/Login.aspx");
        }
    }
}