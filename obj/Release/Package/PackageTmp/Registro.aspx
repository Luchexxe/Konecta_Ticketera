<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TicketForm.Registro" %>

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
            <h2 class="text-center">Formulario Registro</h2>
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
                    <fieldset>
                        <legend>Datos Personales</legend>
                     
                        <asp:Table runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" ID="lblNombre" Text="Nombres:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" runat="server" ID="tbNombre" placeholder="Ingrese Nombre"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow>
                                  <asp:TableCell>
                                      <asp:Label runat="server" ID="lblApellidos" Text="Apellidos:"></asp:Label>
                                  </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox CssClass="form-control" runat="server" ID="tbApellidos" placeholder="Ingrese Apellidos"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                  <asp:TableCell>
                                      <asp:Label runat="server" ID="lblRol" Text="Rol:"></asp:Label>
                                  </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="RolList"  runat="server">
                                                                     
                                    </asp:DropDownList>

                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </fieldset>
                    <br />
                    <br />
                    <fieldset>
                        <legend>Datos Login</legend>
                        <asp:Table runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" ID="lblUsuario" Text="Nombre de usuario:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                      <asp:TextBox CssClass="form-control" runat="server" ID="tbUsuario" placeholder="Ingrese username"></asp:TextBox>
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
                                     <asp:Label runat="server" CssClass="alert-danger" ID="lblErrorPassword"></asp:Label>
                                     <asp:Label runat="server" CssClass="alert-success" ID="lblSuccess"></asp:Label>
                                 </asp:TableCell>
                               
                            </asp:TableRow>
                        </asp:Table>
                    </fieldset>
                    <br />
                    <div>

                        <asp:Button ID="BtnRegistrar" Text="Registrar" CssClass="botones" runat="server" OnClick="BtnRegistrar_Click" />
                    </div>
                    <div>

                        <asp:Button ID="BtnRegresar" Text="Regresar" CssClass="botones" runat="server" OnClick="BtnRegresar_Click" />
                    </div>
                 </div>
                 </form>
            </div>
            <div class="col">
                <fieldset>
                    <legend>Registros Existentes</legend>
                    <div>
                         <asp:DataGrid runat="server" ID="gvUsers" CssClass="table"></asp:DataGrid>
                    </div>
                </fieldset>
               
            </div>
        </div>
    </div>
    
</body>
</html>
