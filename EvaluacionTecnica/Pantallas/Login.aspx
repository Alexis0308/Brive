<%@ Page Title="" Language="C#" MasterPageFile="~/Pantallas/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EvaluacionTecnica.Pantallas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Estilo/Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="pnlLogin" runat="server" CssClass="centradoLogin pnlLogin">
        <table>
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="lblTitulo" runat="server" Text="Inicio de Sesión" CssClass="lblH1Negro"></asp:Label>
                    <asp:Label ID="lblTitulo2" runat="server" Text="Crear Sucursal" CssClass="lblH1Negro" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:center">
                        <asp:TextBox ID="txtUsuario" runat="server" Width="200px" placeholder="Usuario"></asp:TextBox>
                        <br /><br /><br />
                    </td>
            </tr>
            <tr>
                <td style="text-align:center">
                        <asp:TextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                        <br /><br />
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnInicio" runat="server" Text="Iniciar Sesión" CssClass="cssBotonPanel" OnClick="btnInicio_Click" />
                    <asp:Button ID="btnCrear" runat="server" Text="Crear Sucursal" CssClass="cssBotonPanel" Visible="false" OnClick="btnCrear_Click" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Sucursal" CssClass="cssBotonPanel" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnRegresa" runat="server" Text="Regresar" CssClass="cssBotonPanel" Visible="false" OnClick="btnRegresa_Click" />
                </td>
            </tr>
        </table>
            </asp:Panel>
    </div>
</asp:Content>
