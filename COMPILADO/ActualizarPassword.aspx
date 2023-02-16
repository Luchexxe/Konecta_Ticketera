<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarPassword.aspx.cs" Inherits="TicketForm.ActualizarPassword" %>

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
            <h2 class="text-center">Actualizar Password</h2>
             <br />
             <br />
              <div>
               <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>

          </div>
             <br />
             <br />
        
            <div class="col">
                <form id="formulario_registro" class="form-check" runat="server">
                <div>
                 
                    <br />
                    <br />
                    <fieldset>
                        <legend>Datos Login</legend>
                        <asp:Table runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" ID="lblUsuario" Text="Nombre de usuario: "></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" ID="lblusername" Text=""></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                             <asp:TableCell>
                                    <asp:Label runat="server" ID="lblPassword"  Text="Password:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                      <asp:TextBox CssClass="form-control" runat="server" TextMode="Password" ID="tbpassword" placeholder="Ingrese password"></asp:TextBox>
                                </asp:TableCell>

                                 <asp:TableCell>
                                    <asp:Label runat="server" ID="lblPasswordConfirmar" Text="Confirme Password:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                      <asp:TextBox CssClass="form-control" runat="server" TextMode="Password" ID="tbPasswordConfirmar" placeholder="Confirme password"></asp:TextBox>
                                </asp:TableCell>

                            </asp:TableRow>
                            <asp:TableRow>
                                 <asp:TableCell ColumnSpan="2">
                                     <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                                     <asp:Label runat="server"  CssClass="alert-danger" ID="lblErrorPassword"></asp:Label>
                                     <asp:Label runat="server" CssClass="alert-success" ID="lblSuccess"></asp:Label>
                                 </asp:TableCell>
                               
                            </asp:TableRow>
                        </asp:Table>
                    </fieldset>
                    <br />
                    <div>

                        <asp:Button ID="BtnActualizar" Text="Actualizar" CssClass="botones" runat="server" OnClick="BtnActualizar_Click" />
                    </div>
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
