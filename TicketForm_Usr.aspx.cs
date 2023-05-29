using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.IO;

namespace TicketForm
{
    public partial class TicketForm_Usr : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionBBVA"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Row"] != null)
            {
                Observacion_ticket.Rows[Convert.ToInt32(Session["Row"])].BackColor = System.Drawing.Color.Transparent;
            }
            Observacion_ticket.Columns[1].Visible = false;

            if (Session["loggedUser"] != null && Session["rol"].Equals("User"))
            {
                string loggedUser = Session["loggedUser"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + loggedUser;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            //txtTicketMod.Text = txtEstadoMod.Text = txtObservacionMod.Text = "";
            if (!IsPostBack)
            {
                CalendarInicio.Visible = false;
                CalendarFin.Visible = false;
               
            }
        }
        public void clear()
        {

            txtTicketMod.Text  = txtObservacionMod.Text = "";
            txtTicket.Text = txtcAgente.Text = txtEmpresa.Text = txtRUC.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            DDEstadoMod.SelectedIndex = -1;
            DDEstadoMod.Items.FindByValue("-1").Enabled = true;
            txtDataObs.Text = "";
            Observacion_ticket.DataSource = null;
            Observacion_ticket.DataBind();
            Session.Remove("Row");
        }

        public void clearTicket()
        {
            txtTicketMod.Text = txtObservacionMod.Text = "";
            DDEstadoMod.SelectedIndex = -1;
            DDEstadoMod.Items.FindByValue("-1").Enabled = true;
            Observacion_ticket.DataSource = null;
            Observacion_ticket.DataBind();
            txtDataObs.Text = "";
            Session.Remove("Row");
        }

        protected void BtnActualizarPW_Click(object sender, EventArgs e)
        {
            Session.Remove("Row");
            Response.Redirect("ActualizarPassword.aspx");
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("loggedUser");
            Session.Remove("rol");
            Response.Redirect("Login.aspx");
            Session.Remove("Row");

        }
        public void ExportExcel()
        {
            string strFileName = "Tickets_" + DateTime.Now.ToShortDateString() + ".xlsx";
            DataTable dt = new DataTable("GridView_Data");
            bool firstCell = true;
            if (TicketResult.Rows.Count != 0)
            {
                foreach (TableCell cell in TicketResult.HeaderRow.Cells)
                {

                    if (firstCell)
                    {
                        firstCell = false;
                        continue;

                    }
                    dt.Columns.Add(cell.Text);
                }

                foreach (GridViewRow row in TicketResult.Rows)
                {

                    dt.Rows.Add();
                    for (int i = 1; i < row.Cells.Count; i++)
                    {
                        dt.Rows[dt.Rows.Count - 1][i - 1] = row.Cells[i].Text;
                    }
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + strFileName);
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }

            }
            

        }
        protected void Buscar_Click(object sender, EventArgs e)
        {
            if ((txtFecInicio.Text == "" && txtFecFin.Text == "") || (txtFecInicio.Text != "" && txtFecFin.Text != ""))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SP_TicketViewbyID", conn);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlData.SelectCommand.Parameters.AddWithValue("@Ticket", txtTicket.Text);
                sqlData.SelectCommand.Parameters.AddWithValue("@Empresa", txtEmpresa.Text);
                sqlData.SelectCommand.Parameters.AddWithValue("@Ruc", txtRUC.Text);
                sqlData.SelectCommand.Parameters.AddWithValue("@codAgente", txtcAgente.Text);
                sqlData.SelectCommand.Parameters.AddWithValue("@Producto", DDProducto.SelectedItem.ToString());
                sqlData.SelectCommand.Parameters.AddWithValue("@Estado", DDEstado.SelectedItem.ToString());
                sqlData.SelectCommand.Parameters.AddWithValue("@fecInicio", txtFecInicio.Text);
                sqlData.SelectCommand.Parameters.AddWithValue("@fecFin", txtFecFin.Text);
                clear();
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                conn.Close();
                TicketResult.DataSource = dtbl;
                TicketResult.DataBind();
                Observacion_ticket.DataSource = null;
                Observacion_ticket.DataBind();
            }

            else if
                (txtFecInicio.Text != "" && txtFecFin.Text != "")
            {
                lblFiltroOK.Text = "Fechas correctas";
            }

            else
            {
                lblFiltroError.Text = "Ingrese fecha correcta";
            }
        }

        public void GridviewToExcel()
        {

            StringBuilder builder = new StringBuilder();
            //string strFileName = "Tickets_" + DateTime.Now.ToShortDateString() + ".csv";
            string strFileName = "Tickets_" + DateTime.Now.ToShortDateString() + ".xlsx";
            builder.Append("Ticket ,Codigo Agente,Nombre Agente,RUC Agente,Telefono Agente,Direccion,Producto,Fecha Contacto,Plazo, T. Transcurrido, T. Faltante,Fecha Atendido,Estado,Usuario Atencion,Gestor Atencion,Observacion " + Environment.NewLine);
            foreach (GridViewRow row in TicketResult.Rows)
            {
                string ticket = row.Cells[0].Text;
                string codAgente = row.Cells[1].Text;
                string nomAgente = row.Cells[2].Text;
                string rucAgente = row.Cells[3].Text;
                string telAgente = row.Cells[4].Text;
                string direccion = row.Cells[5].Text;
                string producto = row.Cells[6].Text;
                string fecContacto = row.Cells[7].Text;
                string plazo = row.Cells[8].Text;
                string tTranscurrido = row.Cells[9].Text;
                string tFaltante = row.Cells[10].Text;
                string fecAtendido = row.Cells[11].Text;
                string estado = row.Cells[12].Text;
                string userAtencion = row.Cells[13].Text;
                string gesAtencion = row.Cells[14].Text;
                string Observacion = row.Cells[15].Text;


                builder.Append(ticket + "," + codAgente + "," + nomAgente + "," + rucAgente + "," + telAgente + "," + direccion + "," + producto + "," + fecContacto + "," + plazo + "," + tTranscurrido + "," + tFaltante + "," + fecAtendido + "," + estado + "," + userAtencion + "," + gesAtencion + "," + Observacion + Environment.NewLine);
            }
            Response.Clear();
            // Response.ContentType = "text/csv";
            Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + strFileName);
            Response.Write(builder.ToString());
            Response.End();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //GridviewToExcel();
            ExportExcel();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtTicketMod.Text == "")
            {
                lblErrorMessage.Text = "Seleccione ticket para evaluar";
            }
            else
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_TICKETUPDATE", conn);
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Ticket", txtTicketMod.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@estado", DDEstadoMod.SelectedItem.ToString());
                sqlcmd.Parameters.AddWithValue("@UsrTicket", Session["loggedUser"].ToString());
                sqlcmd.Parameters.AddWithValue("@Observacion", txtObservacionMod.Text.Trim());
                sqlcmd.ExecuteNonQuery();

               
                // clear();
                FillGridView();

                SqlDataAdapter sqlData2 = new SqlDataAdapter("SP_BitacoraTicket", conn);
                sqlData2.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData2.SelectCommand.Parameters.AddWithValue("@Ticket", txtTicketMod.Text.Trim());
                DataTable dtbl2 = new DataTable();
                sqlData2.Fill(dtbl2);


                conn.Close();

                Observacion_ticket.DataSource = dtbl2;
                Observacion_ticket.DataBind();
                txtDataObs.Text = "";
            }
        }
        void FillGridView()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SP_TicketView", conn);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlData.SelectCommand.Parameters.Add("@Contactid", SqlDbType.Int).Value = 123;
            DataTable dtbl = new DataTable();

            sqlData.Fill(dtbl);
            conn.Close();
            TicketResult.DataSource = dtbl;
            TicketResult.DataBind();


        }

        protected void lnk_OnClick(object sender, EventArgs e)
        {
            string ticketID = (sender as LinkButton).CommandArgument;
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SP_TicketViewbyID", conn);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Ticket", ticketID);
            sqlData.SelectCommand.Parameters.AddWithValue("@Empresa", "");
            sqlData.SelectCommand.Parameters.AddWithValue("@Ruc", "");
            sqlData.SelectCommand.Parameters.AddWithValue("@codAgente", "");
            sqlData.SelectCommand.Parameters.AddWithValue("@Producto", "");
            sqlData.SelectCommand.Parameters.AddWithValue("@Estado", "");
            sqlData.SelectCommand.Parameters.AddWithValue("@fecInicio", "");
            sqlData.SelectCommand.Parameters.AddWithValue("@fecFin", "");
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            conn.Close();
            txtTicketMod.Text = dtbl.Rows[0]["Ticket"].ToString();
            //  DDEstadoMod.SelectedValue = dtbl.Rows[0]["estado"].ToString();


            //DDEstadoMod.SelectedValue = dtbl.Rows[0]["estado"].ToString();


            txtObservacionMod.Text = dtbl.Rows[0]["Observacion"].ToString();
            DDEstadoMod.Items.FindByValue("-1").Enabled = false;

            SqlDataAdapter sqlData2 = new SqlDataAdapter("SP_BitacoraTicket", conn);
            sqlData2.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData2.SelectCommand.Parameters.AddWithValue("@Ticket", ticketID);
            DataTable dtbl2 = new DataTable();
            sqlData2.Fill(dtbl2);


            conn.Close();

            Observacion_ticket.DataSource = dtbl2;
            Observacion_ticket.DataBind();
            txtDataObs.Text = "";
        }

        protected void ImgButtonInicio_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarInicio.Visible)
            {
                CalendarInicio.Visible = false;
            }
            else
            {
                CalendarInicio.Visible = true;
                CalendarFin.Visible = false;
            }
            CalendarInicio.Attributes.Add("style", "position:absolute");
        }

        protected void CalendarFin_SelectionChanged(object sender, EventArgs e)
        {
            txtFecFin.Text = CalendarFin.SelectedDate.ToString("yyyy-MM-dd");
            CalendarFin.Visible = false;
        }

        protected void CalendarInicio_SelectionChanged(object sender, EventArgs e)
        {
            txtFecInicio.Text = CalendarInicio.SelectedDate.ToString("yyyy-MM-dd");
            CalendarInicio.Visible = false;
        }

        protected void ImageButtonFin_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFin.Visible)
            {
                CalendarFin.Visible = false;
            }
            else
            {
                CalendarFin.Visible = true;
                CalendarInicio.Visible = false;
            }
            CalendarFin.Attributes.Add("style", "position:absolute");
        }
        protected void TicketResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridViewRow grv = e.Row;
                if (grv.Cells[13].Text.Equals("PENDIENTE"))
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                if (grv.Cells[13].Text.Equals("ATENDIDO"))
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                if (grv.Cells[13].Text.Equals("NO PROCEDE"))
                {
                    e.Row.BackColor = System.Drawing.Color.RosyBrown;
                }
                if (grv.Cells[13].Text.Equals("VENCIDO"))
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void CalendarInicio_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.Aquamarine;
            }
        }

        protected void CancelarFooter_Click(object sender, EventArgs e)
        {
            clearTicket();
        }

        protected void ObsTicket_onClick(object sender, EventArgs e)
        {
            string ticketID = (sender as LinkButton).CommandArgument;
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SP_BitacoraTicketByID", conn);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Ticket", txtTicketMod.Text);
            sqlData.SelectCommand.Parameters.AddWithValue("@ID", ticketID);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);


            txtDataObs.Text = dtbl.Rows[0]["Observacion"].ToString();
            conn.Close();
            txtDataObs.Focus();

            foreach (GridViewRow r in Observacion_ticket.Rows)
            {
                r.BackColor = System.Drawing.Color.Transparent;
            }

            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;

            Session["Row"] = row.RowIndex;

            if (row.RowIndex != -1)
            {
                //  int index = Convert.ToInt32(Session["Row"]);
                Observacion_ticket.Rows[row.RowIndex].BackColor = System.Drawing.Color.LightBlue;

            }

        }
    }
}