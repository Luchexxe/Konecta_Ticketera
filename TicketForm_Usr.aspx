<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="TicketForm_Usr.aspx.cs" Inherits="TicketForm.TicketForm_Usr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="style.css" />
    <title>BÚSQUEDA DE SOLICITUDES PENDIENTES DE ATENCIÓN</title>
</head>
<body class="bg-light bg-gradient">
    <h3>BÚSQUEDA DE SOLICITUDES PENDIENTES DE ATENCIÓN</h3>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="BtnActualizarPW" runat="server" Text="Cambiar Password" CssClass="botones" OnClick="BtnActualizarPW_Click" />
            </div>
            <div>
                <asp:Button ID="BtnCerrar" runat="server" Text="Cerrar Sesion" CssClass="botones" OnClick="BtnCerrar_Click" />
            </div>
            <br />
            <div class="filtroAll">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Ticket"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtTicket" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Empresa"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtEmpresa" runat="server" Height="25px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="RUC"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtRUC" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Fec. Inicio"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFecInicio" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImgButtonInicio" runat="server" ImageUrl="~/img/calendar.png" ImageAlign="AbsBottom" OnClick="ImgButtonInicio_Click" /></td>
                        <td>
                            <asp:Calendar ID="CalendarInicio" runat="server" OnDayRender="CalendarInicio_DayRender" OnSelectionChanged="CalendarInicio_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <WeekendDayStyle BackColor="#FFFFCC" />
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Cod. Agente"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtcAgente" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Producto"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDProducto" runat="server" Style="width: 134px">
                                <asp:ListItem Enabled="true" Text="" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="EMISION DE VOUCHER MANUAL" Value="1"></asp:ListItem>
                                <asp:ListItem Text="DESBLOQUEO DE CUENTA" Value="2"></asp:ListItem>
                                <asp:ListItem Text="CAMBIO DE NUMERO Y OPERADOR" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Estado"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DDEstado" runat="server" Style="width: 134px">
                                <asp:ListItem Enabled="true" Text="" Value="-1"></asp:ListItem>

                                <asp:ListItem Text="PENDIENTE" Value="PENDIENTE"></asp:ListItem>
                                <asp:ListItem Text="ATENDIDO" Value="ATENDIDO"></asp:ListItem>
                                <asp:ListItem Text="NO PROCEDE" Value="NO PROCEDE"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Fec. Fin"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFecFin" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButtonFin" runat="server" OnClick="ImageButtonFin_Click" ImageUrl="~/img/calendar.png" ImageAlign="AbsBottom" />
                        </td>
                        <td>
                            <asp:Calendar ID="CalendarFin" runat="server" OnSelectionChanged="CalendarFin_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" VisibleDate="2022-05-11" Width="200px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <WeekendDayStyle BackColor="#FFFFCC" />
                            </asp:Calendar>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Label ID="lblFiltroOK" runat="server" Text="" ForeColor="Green"></asp:Label>
            <asp:Label ID="lblFiltroError" runat="server" Text="" ForeColor="Red"></asp:Label>
            <div class="PadreBotones">
                <div class="HijoBotones">
                    <asp:Button ID="Buscar" runat="server" Text="Buscar" CssClass="botones" OnClick="Buscar_Click" />
                </div>
                <div class="HijoBotones">
                    <asp:Button ID="Exportar" runat="server" Text="Exportar" CssClass="botones" OnClick="Button1_Click1" />
                </div>
                <div class="HijoBotones">
                    <asp:Button ID="Limpiar" runat="server" Text="Limpiar" CssClass="botones" OnClick="Button3_Click" />
                </div>
            </div>
            <br />
        </div>
        <div style="overflow: scroll;">
            <asp:GridView ID="TicketResult" CssClass="table" OnRowDataBound="TicketResult_RowDataBound" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("Ticket") %>' OnClick="lnk_OnClick">Evaluar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="Ticket" HeaderText="Ticket" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="codAgente" HeaderText="Codigo Agente" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="nomAgente" HeaderText="Nombre Agente" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="rucAgente" HeaderText="RUC Agente" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="telAgente" HeaderText="Telefono Agente" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="Direccion" HeaderText="Direccion" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="Producto" HeaderText="Producto" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="fecContacto" HeaderText="Fecha Contacto" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="Plazo" HeaderText="Plazo" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="tTranscurrido" HeaderText="T. Transcurrido" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="tFaltante" HeaderText="T. Faltante" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="fecAtendido" HeaderText="Fecha Atendido" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="estado" HeaderText="Estado" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="userAtencion" HeaderText="Usuario Atencion" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="gestorAtencion" HeaderText="Gestor Atencion" />
                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="Observacion" HeaderText="Observacion" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <h3>Modificar Estado</h3>
        <div class="modEstado">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Ticket"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTicketMod" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Estado"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DDEstadoMod" runat="server" Width="168px">
                            <asp:ListItem Enabled="true" Text="" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="PENDIENTE" Value="PENDIENTE"></asp:ListItem>
                            <asp:ListItem Text="ATENDIDO" Value="ATENDIDO"></asp:ListItem>
                            <asp:ListItem Text="NO PROCEDE" Value="NO PROCEDE"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Observacion"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtObservacionMod" runat="server" TextMode="MultiLine" Height="100px" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="botones" Text="Grabar" OnClick="Button1_Click" />
                        <asp:Button ID="CancelarFooter" CssClass="botones" runat="server" Text="Cancelar" OnClick="CancelarFooter_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <h3>Bitacora Observación</h3>
        <div class="modEstado">
            <table>
                <thead>
                    <tr>
                        <th class="text-center">Data</th>
                        <th class="text-center">Observacion</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:GridView ID="Observacion_ticket" CellPadding="-1" CellSpacing="-1" CssClass="GridView" GridLines="none" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="ObsTicket_onClick">Visualizar</asp:LinkButton>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="ID" HeaderText="ID" />
                                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="FechaObservacion" HeaderText="Fecha Observacion" />
                                    <asp:BoundField HeaderStyle-Wrap="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" DataField="GestorAtencion" HeaderText="Gestor Atencion" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataObs" Enabled="false" TextMode="MultiLine" Height="200px" Width="400px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
