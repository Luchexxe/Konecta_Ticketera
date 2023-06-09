﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketForm
{
    public partial class ActualizarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["loggedUser"] != null && (Session["rol"].Equals("User")|| Session["rol"].Equals("Supervisor")))
            {
                string loggedUser = Session["loggedUser"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + loggedUser;
                lblError.Text = "";
                lblErrorPassword.Text = "";
                lblSuccess.Text = "";
                lblusername.Enabled = false;
                lblusername.Text = Session["username"].ToString();

            }
            else
            {
                Response.Redirect("Login.aspx");
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
                    string patron = ConfigurationManager.AppSettings["patron"];
                    SqlCommand cmm = new SqlCommand("SP_UpdatePass", conn);
                        cmm.CommandType = System.Data.CommandType.StoredProcedure;
                      
                        cmm.Parameters.AddWithValue("@Usuario", lblusername.Text);
                        cmm.Parameters.AddWithValue("@Pass", tbpassword.Text);
                        cmm.Parameters.AddWithValue("@Patron", patron);
                    cmm.Parameters.AddWithValue("@Programa", prod);
                    cmm.ExecuteNonQuery();
                        conn.Close();
                        Clean();
                    lblSuccess.Text = "Se actualizó contraseña";
                    }
                   


                }

            }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {

            if (Session["producto"].Equals("BBVA"))
            {
                Response.Redirect("TicketForm_Usr.aspx");
            }
            else if (Session["producto"].Equals("POWER_PAY"))
            {
                if (Session["rol"].Equals("User"))
                {
                    Response.Redirect("TicketFormPP_Usr.aspx");
                }
                else
                {
                    Response.Redirect("TicketFormPP.aspx");
                }
                    
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            


         
               
        }

    }

    
    }
