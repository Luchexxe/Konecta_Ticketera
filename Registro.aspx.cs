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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] != null && Session["rol"].Equals("Admin"))
            {
                string loggedUser = Session["loggedUser"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + loggedUser;
                lblError.Text = "";
                lblErrorPassword.Text = "";
                LeerDatos();

                if (Session["producto"].Equals("POWER_PAY"))
                {
                    RolList.Items.Add("Admin");
                    RolList.Items.Add("User");
                    RolList.Items.Add("Supervisor");
                }
                else
                {
                    RolList.Items.Add("Admin");
                    RolList.Items.Add("User");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
           
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionBBVA"].ConnectionString);

        void Clean()
        {
            tbNombre.Text = "";
            tbApellidos.Text = "";
            tbUsuario.Text = "";
            tbPasswordConfirmar.Text = "";
            tbpassword.Text = "";
            lblError.Text = "";
            lblErrorPassword.Text = "";
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "" || tbApellidos.Text == "" || tbUsuario.Text == "" || tbPasswordConfirmar.Text == "" || tbpassword.Text == "")
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
                    var prog = Session["producto"];
                    conn.Open();
                    SqlCommand sqlcmd = new SqlCommand("SP_ExistUser", conn);
                    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Usuario", tbUsuario.Text);
                    sqlcmd.Parameters.AddWithValue("@Programa", prog);
                    int usr = Convert.ToInt32(sqlcmd.ExecuteScalar());
                    
                    if (usr < 1)
                    {

                        try
                        {
                            
                            string patron = ConfigurationManager.AppSettings["patron"];
                            SqlCommand cmm = new SqlCommand("SP_AddLoginUser", conn);
                            cmm.CommandType = System.Data.CommandType.StoredProcedure;
                            cmm.Parameters.AddWithValue("@Nombres", tbNombre.Text);
                            cmm.Parameters.AddWithValue("@Apellidos", tbApellidos.Text);
                            cmm.Parameters.AddWithValue("@Rol", RolList.SelectedValue.ToString());
                            cmm.Parameters.AddWithValue("@Usuario", tbUsuario.Text);
                            cmm.Parameters.AddWithValue("@Passw", tbpassword.Text);
                            cmm.Parameters.AddWithValue("@Patron", patron);
                            cmm.Parameters.AddWithValue("@Programa", prog);
                            cmm.ExecuteNonQuery();
                            conn.Close();
                            Clean();
                            LeerDatos();
                            lblSuccess.Text = "Usuario creado correctamente";
                        }
                        catch (Exception)
                        {

                            lblError.Text = "Ocurrió un error al crear contacto";
                        }
                      
                    }
                    else
                    {
                        lblError.Text = "El usuario "+tbUsuario.Text+" ya existe";
                        tbUsuario.Text = "";
                    }


                }

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

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            var prog = Session["producto"];
            if (prog.Equals("BBVA"))
            {
                Response.Redirect("TicketForm.aspx");
            }
            else if (prog.Equals("POWER_PAY"))
            {
                Response.Redirect("TicketFormPP.aspx");
            }

            else 
            {
                Response.Redirect("Login.aspx");
            }

            
        }
    }
}