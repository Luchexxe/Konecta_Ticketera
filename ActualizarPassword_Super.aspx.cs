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
    public partial class ActualizarPassword_Super : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loggedUser"] != null && Session["rol"].Equals("Admin"))
            {
                string loggedUser = Session["loggedUser"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + loggedUser;
                lblError.Text = "";
                lblErrorPassword.Text = "";
                lblSuccess.Text = "";
               
               
                LeerDatos();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
   
            if (!IsPostBack)
            {
                tbUsuario.Text = Session["username"].ToString();
                //  FillGridView();
            }


        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionBBVA"].ConnectionString);
        void Clean()
        {

            tbPasswordConfirmar.Text = "";
            tbpassword.Text = "";
            lblError.Text = "";
            lblErrorPassword.Text = "";
        }
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (tbPasswordConfirmar.Text == "" || tbpassword.Text == "")
            {
                lblError.Text = "Llenar todos los campos";
            }
            else
            {
                if (tbpassword.Text != tbPasswordConfirmar.Text)
                {
                    lblErrorPassword.Text = "Las contraseñas no coinciden";
                }
                else
                {

                    conn.Open();
                    var prod = Session["producto"];
                    SqlCommand sqlcmd = new SqlCommand("SP_ExistUser", conn);
                    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Usuario", tbUsuario.Text);
                    sqlcmd.Parameters.AddWithValue("@Programa", prod);
                    int cusr = Convert.ToInt32(sqlcmd.ExecuteScalar());
                    if (cusr == 1)
                    {
                        string patron = ConfigurationManager.AppSettings["patron"];
                        //string patron = "bbvakonecta";
                        string usr = tbUsuario.Text;
                        SqlCommand cmm = new SqlCommand("SP_UpdatePass", conn);
                        cmm.CommandType = System.Data.CommandType.StoredProcedure;

                        cmm.Parameters.AddWithValue("@Usuario", usr);
                        cmm.Parameters.AddWithValue("@Pass", tbpassword.Text);
                        cmm.Parameters.AddWithValue("@Patron", patron);
                        cmm.Parameters.AddWithValue("@Programa", prod);
                        cmm.ExecuteNonQuery();
                        conn.Close();
                        Clean();
                        lblSuccess.Text = "Se actualizó contraseña de usuario " + tbUsuario.Text;
                    }
                    else
                    {
                        lblError.Text = "El usuario "+tbUsuario.Text +" no existe";
                    }
                       
                   
                }



            }


        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {


            if (Session["producto"].Equals("BBVA"))
            {
                Response.Redirect("TicketForm.aspx");
            }
            else if (Session["producto"].Equals("POWER_PAY"))
            {
                Response.Redirect("TicketFormPP.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }





          
        }

        void LeerDatos()
        {

            var prog = Session["producto"];
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SP_UsersView", conn);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@programa", prog);

            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            conn.Close();
            gvUsers.DataSource = dt;
            gvUsers.DataBind();


        }

     protected void BtnEliminar_Click(object sender, EventArgs e)
        { 
            if (tbUsuario.Text == "")
            {
                lblError.Text = "Llenar campo Usuario";
            }
            else
            {
                    conn.Open();
                var prog = Session["producto"];
                    SqlCommand sqlcmd = new SqlCommand("SP_ExistUser", conn);
                    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Usuario", tbUsuario.Text);
                      sqlcmd.Parameters.AddWithValue("@Programa", prog);
                int usr = Convert.ToInt32(sqlcmd.ExecuteScalar());

                    if (usr == 1)
                    {
                       
                        SqlCommand cmm = new SqlCommand("SP_DeleteUser", conn);
                        cmm.CommandType = System.Data.CommandType.StoredProcedure;
                        cmm.Parameters.AddWithValue("@Usuario", tbUsuario.Text);
                          cmm.Parameters.AddWithValue("@Programa", prog);

                    cmm.ExecuteNonQuery();
                        conn.Close();
                         lblSuccess.Text = "El usuario " + tbUsuario.Text+ " fue eliminado" ;
                          Clean();
                        LeerDatos();
                    }
                    else
                    {
                        lblError.Text = "El usuario " + tbUsuario.Text + " no existe";
                        tbUsuario.Text = "";
                        conn.Close();
                    }


             }

        }



    }
    }