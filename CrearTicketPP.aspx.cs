using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketForm
{
    public partial class CrearTicketPP: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] != null && Session["producto"].Equals("POWER_PAY") && !Session["rol"].Equals("Supervisor"))
            {
                string loggedUser = Session["loggedUser"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + loggedUser;
                lblOK.Text = "";
                lblError.Text = "";

                //LLenarSegmento();

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
           
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionBBVA"].ConnectionString);

        void Clean()
        {
            lblOK.Text= lblError.Text= tbAsunto.Text= tbRUC.Text= tbEmpresa.Text = tbPerContacto.Text = tbDNI.Text= tbCorreoCli.Text= tbObservacion.Text="";
            cboTipoCaso.ClearSelection();
            cboSubTipoCaso.ClearSelection();
            
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (tbAsunto.Text == "" || tbPerContacto.Text == "" || tbCorreoCli.Text == "" || tbDNI.Text == "" || cboTipoCaso.Text=="SELECCIONE" || cboSubTipoCaso.SelectedItem.Text == "SELECCIONE")
            {
                lblError.Text = "Llenar Todos los campos";
            }
            else 
            {

                var usrname = Session["loggedUser"];
                conn.Open();
                SqlCommand sqlcmd = new SqlCommand("GC_PP_CrearTicket_Correo", conn);
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@PP_Buzon", cboBuzon.Text);
                sqlcmd.Parameters.AddWithValue("@PP_Asunto", tbAsunto.Text); 
                sqlcmd.Parameters.AddWithValue("@PP_agente", usrname); 
                sqlcmd.Parameters.AddWithValue("@PP_medio", "CORREO");
                sqlcmd.Parameters.AddWithValue("@PP_segmentoCliente", cboSegmento.SelectedItem.ToString());
               
                sqlcmd.Parameters.AddWithValue("@PP_tipoCaso", cboTipoCaso.SelectedItem.ToString()+" - "+cboSubTipoCaso.SelectedItem.ToString());
                sqlcmd.Parameters.AddWithValue("@PP_estado", "ABIERTO");
                sqlcmd.Parameters.AddWithValue("@PP_dni", tbDNI.Text);
                sqlcmd.Parameters.AddWithValue("@PP_ruc", tbRUC.Text);
                sqlcmd.Parameters.AddWithValue("@PP_cliente", tbPerContacto.Text);
                sqlcmd.Parameters.AddWithValue("@PP_razonSocial", tbEmpresa.Text);
                sqlcmd.Parameters.AddWithValue("@PP_correo", tbCorreoCli.Text);
                sqlcmd.Parameters.AddWithValue("@PP_cargo", tbCargo.Text);
                sqlcmd.Parameters.AddWithValue("@PP_contactoAutorizado", DDCAutorizado.SelectedItem.ToString());
                sqlcmd.Parameters.AddWithValue("@PP_observacion", tbObservacion.Text);
                
                sqlcmd.Parameters.Add("@PP_ticket", SqlDbType.NVarChar, 255);
                sqlcmd.Parameters["@PP_ticket"].Direction = ParameterDirection.Output;
                sqlcmd.ExecuteNonQuery();
                var TicketBD = sqlcmd.Parameters["@PP_ticket"].Value.ToString();
                conn.Close();
                Clean();
                lblOK.Text = "Ticket creado correctamente " + TicketBD;

            }

        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            var rolPP = Session["rol"];
            if (rolPP.Equals("Admin"))
            {
                Response.Redirect("TicketFormPP.aspx");
            }
            else if (rolPP.Equals("User"))
            {
                Response.Redirect("TicketFormPP_Usr.aspx");
            }
           
        }

        protected void cboSegmento_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboSegmento.Text.Equals("USUARIO_FINAL"))
            {
                trSegmentoComercio.Visible = false;
                trSegmentoComercio2.Visible = false;
                tbRUC.Text = tbEmpresa.Text = tbCargo.Text = "";
                cboBuzon.ClearSelection();
                cboTipoCaso.ClearSelection();
                cboSubTipoCaso.ClearSelection();
                DDCAutorizado.Text="";
            }
            else if (cboSegmento.Text.Equals("COMERCIO"))
            {
                trSegmentoComercio.Visible = true;
                trSegmentoComercio2.Visible = true;
                cboBuzon.ClearSelection();
                cboTipoCaso.ClearSelection();
                cboSubTipoCaso.ClearSelection();
                DDCAutorizado.ClearSelection();
            }
            
        }

        protected void cboTipoCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var usrname = Session["loggedUser"];
            conn.Open();
            SqlCommand sqlcmd = new SqlCommand("GC_PP_Tipificaciones", conn);
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@PP_Segmento", cboSegmento.SelectedItem.ToString());
            sqlcmd.Parameters.AddWithValue("@PP_Tipo", cboTipoCaso.SelectedItem.ToString());
            sqlcmd.Parameters.AddWithValue("@PP_Flag", "2");
            //sqlcmd.ExecuteNonQuery();
            cboSubTipoCaso.DataSource = sqlcmd.ExecuteReader();
            cboSubTipoCaso.DataTextField = "TIPIFICACION";
            cboSubTipoCaso.DataValueField = "TIPIFICACION";
            cboSubTipoCaso.DataBind();
            cboSubTipoCaso.Items.Insert(0, new ListItem("SELECCIONE", "0"));
            conn.Close();
            //Clean();

        }

        //protected void LLenarSegmento()
        //{
        //    //var usrname = Session["loggedUser"];
        //    conn.Open();
        //    SqlCommand sqlcmd = new SqlCommand("GC_PP_Tipificaciones", conn);
        //    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    sqlcmd.Parameters.AddWithValue("@PP_Segmento","");
        //    sqlcmd.Parameters.AddWithValue("@PP_Tipo", "");   
        //    sqlcmd.Parameters.AddWithValue("@PP_Flag", "0");
        //    //sqlcmd.ExecuteNonQuery();
        //    cboSegmento.DataSource = sqlcmd.ExecuteReader();
        //    cboSegmento.DataTextField = "SEGMENTO";
        //    cboSegmento.DataValueField = "SEGMENTO";
        //    cboSegmento.DataBind();
        //    cboSegmento.Items.Insert(0, new ListItem("SELECCIONE", "0"));
        //    conn.Close();
        //    //Clean();

        //}
    }
}