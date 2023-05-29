<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TicketForm.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="style.css" />
    <title>Login a Ticketera</title>
</head>
<body class="bg-light">
    <div id="login">
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                        <form id="formulario_login" runat="server">
                            <div class="form-control">
                                <h3 class="text-center text-info">Login</h3>
                                <div>
                                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                                    <asp:TextBox ID="tbUsuario" CssClass="form-control" runat="server" placeholder="Nombre de usuario"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                                    <asp:TextBox ID="tbPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:Label ID="lblPrograma" runat="server" Text="Programa:"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="cboPrograma" runat="server">
                                        <asp:ListItem Text="BBVA" Value="BBVA" />
                                        <asp:ListItem Text="POWER PAY" Value="POWER_PAY" />
                                    </asp:DropDownList>
                                </div>
                                <hr />
                                <div class="row">
                                    <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:Button ID="BtnIngresar" CssClass="btn btn-info btn-md" runat="server" Text="Ingresar" OnClick="BtnIngresar_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
