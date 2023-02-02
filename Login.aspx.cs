using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace TicketForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       // string patron = "bbvakonecta";
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnectionBBVA"].ConnectionString;
            string patron = ConfigurationManager.AppSettings["patron"];
            SqlConnection sqlConectar = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("SP_ValidarUser", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Usuario",SqlDbType.VarChar,50).Value=tbUsuario.Text;
            cmd.Parameters.Add("@Passw", SqlDbType.VarChar, 50).Value = tbPassword.Text;
            cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string nomb = dr.GetString(1);
                string usern = dr.GetString(4);
                string rol = dr.GetString(3);
                Session["loggedUser"] = nomb;
                Session["username"] = usern;
                Session["rol"] = rol;

                if (rol.Equals("Admin"))
                {
                    Response.Redirect("TicketForm.aspx");
                }
                else if (rol.Equals("User"))
                {
                    Response.Redirect("TicketForm_Usr.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                //Agregamos una sesion de usuario
               
            }
            else
            {
                lblError.Text = "Error de Username o Password";
            }
            cmd.Connection.Close();
        }
    }
}