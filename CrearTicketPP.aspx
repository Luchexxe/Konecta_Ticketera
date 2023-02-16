<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearTicketPP.aspx.cs" Inherits="TicketForm.CrearTicketPP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="css/bootstrap.min.css" rel="stylesheet"/>
<script src="js/bootstrap.bundle.min.js"></script>
<script src="js/bootstrap.min.js"></script>
 <link rel="stylesheet" href="style.css"/>
    
    <title></title>
</head>
<body class="form-control bg-light">
    <div class="container small">
        <div class="row">
            <h2 class="text-center">Formulario Registro Ticket</h2>
             <br />
             <br />
              <div>
               <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>

          </div>
             <br />
             <br />
        
            <div class="col" >
                <form id="formulario_registro" class="form-check" runat="server">
                <div>
                    <fieldset>
                        <legend>Datos Ticket</legend>
                     
                        <asp:Table runat="server" CellPadding="3" CellSpacing="3" Gridlines="both" Width="95%" HorizontalAlign="Left" VerticalAlign="Middle">
                            <asp:TableRow>
                                 <asp:TableCell>
                                      <asp:Label runat="server" ID="lblSegmento"  Width="150px" Text="Segmento"></asp:Label>
                                  </asp:TableCell>
                                <asp:TableCell>
                                   <asp:DropDownList ID="cboSegmento" Width="300px" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="cboSegmento_SelectedIndexChanged">
                                    <asp:ListItem Text="COMERCIO" Value="COMERCIO" />
                                    <asp:ListItem Text="USUARIO_FINAL" Value="USUARIO_FINAL" />
                                    
                                                                         
                                    </asp:DropDownList>

                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Width="100px" ID="lblBuzon" Text="Buzón"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                  <asp:DropDownList ID="cboBuzon" Width="300px" runat="server">
                                    <asp:ListItem Text="usuario@powerpay.pe" Value="usuario@powerpay.pe" />
                                    <asp:ListItem Text="comercio@powerpay.pe" Value="comercio@powerpay.pe" />
                                    <asp:ListItem Text="atenciónreclamos@powerpay.pe" Value="atenciónreclamos@powerpay.pe" />
                                    <asp:ListItem Text="privacidad@powerpay.pe" Value="privacidad@powerpay.pe" />
                                      
                                    </asp:DropDownList>
                                </asp:TableCell>

                                

                               

                               

                            </asp:TableRow>
                            
                            <asp:TableRow>

                                 <asp:TableCell>
                                    <asp:Label runat="server" ID="lblAsunto" Width="100px"  Text="Asunto"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" Width="300px" runat="server" ID="tbAsunto" placeholder="Ingrese asunto"></asp:TextBox>
                                </asp:TableCell>

                                 <asp:TableCell>
                                    <asp:Label runat="server" ID="lblDNI" Width="100px"  Text="DNI"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" Width="300px"  runat="server" ID="tbDNI" placeholder="Ingrese DNI"></asp:TextBox>
                                </asp:TableCell>

                             
                            </asp:TableRow>
                        
                            <asp:TableRow ID="trSegmentoComercio">   

                                    <asp:TableCell>
                                    <asp:Label runat="server" ID="lblRUC" Width="150px"  Text="RUC"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" Width="300px"  runat="server" ID="tbRUC" placeholder="Ingrese RUC"></asp:TextBox>
                                </asp:TableCell>


                                
                                <asp:TableCell>
                                      <asp:Label runat="server" ID="lblEmpresa" Width="150px"  Text="Nombre Empresa"></asp:Label>
                                  </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" Width="300px"  runat="server" ID="tbEmpresa" placeholder="Ingrese Empresa"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>

                             <asp:TableRow ID="trSegmentoComercio2">  

                                    <asp:TableCell>
                                    <asp:Label runat="server" ID="lblCargo" Width="150px"  Text="Cargo"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" Width="300px"  runat="server" ID="tbCargo" placeholder="Ingrese Cargo"></asp:TextBox>
                                </asp:TableCell>


                                    <asp:TableCell>
                                    <asp:Label runat="server" ID="lblCAutorizado" Width="150px"  Text="Contacto Autorizado"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                  <asp:DropDownList ID="DDCAutorizado" Width="300px" runat="server">
                                    <asp:ListItem Text="SI" Value="SI" />
                                     <asp:ListItem Text="NO" Value="NO" />
                                       </asp:DropDownList>
                                </asp:TableCell>



                                  </asp:TableRow>

                            <asp:TableRow>

                                   <asp:TableCell>
                                      <asp:Label runat="server" ID="lblPerContacto" Width="150px" Text="Persona Contacto"></asp:Label>
                                  </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" Width="300px"  runat="server" ID="tbPerContacto" placeholder="Ingrese Persona"></asp:TextBox>
                                </asp:TableCell>


                                   <asp:TableCell>
                                      <asp:Label runat="server" ID="lblCorreoCliente" Width="150px"  Text="Correo Cliente"></asp:Label>
                                  </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" Width="300px" runat="server" ID="tbCorreoCli" placeholder="Ingrese Correo"></asp:TextBox>
                                </asp:TableCell>

                                 
                                

                                  
                            </asp:TableRow>

                            <asp:TableRow>  
                                  <asp:TableCell>
                                      <asp:Label runat="server" ID="lblTipoCaso"  Width="150px" Text="Tipo Caso"></asp:Label>
                                  </asp:TableCell>
                                <asp:TableCell>
                                   <asp:DropDownList ID="cboTipoCaso" Width="300px" runat="server">
                                    <asp:ListItem Text="CONSULTA" Value="CONSULTA" />
                                    <asp:ListItem Text="REQUERIMIENTO" Value="REQUERIMIENTO" />
                                    <asp:ListItem Text="RECLAMO" Value="RECLAMO" />
                                                                         
                                    </asp:DropDownList>

                                </asp:TableCell>

                                <asp:TableCell>
                                      <asp:Label runat="server" ID="lblObservacion" Width="150px" Text="Observacion"></asp:Label>
                                  </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" Width="300px" Height="90px" runat="server" TextMode="MultiLine" ID="tbObservacion" placeholder="Ingrese Observacion"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </fieldset>
                    <br />
                    <br />
                <asp:Label ID="lblOK" runat="server" Text="" ForeColor="Green"></asp:Label>
                      <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <br />

                   

                    <div>
                          

                        <asp:Button ID="BtnRegistrar" Text="Registrar" CssClass="botones" runat="server" OnClick="BtnRegistrar_Click" />
                    </div>
                    <br/>
                    <div>

                        <asp:Button ID="BtnRegresar" Text="Regresar" CssClass="botones" runat="server" OnClick="BtnRegresar_Click" />
                    </div>
                 </div>
                 </form>
            </div>
        
        </div>
    </div>
    
</body>
</html>
