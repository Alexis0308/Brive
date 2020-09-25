<%@ Page Title="" Language="C#" MasterPageFile="~/Pantallas/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="EvaluacionTecnica.Pantallas.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Estilo/Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="pnlInventario" runat="server" CssClass=" pnlGenerico">
            <asp:Label ID="lblTitulo" runat="server" Text="Productos" CssClass="lblH1Negro"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="cssBotonPanel" OnClick="btnCerrarSesion_Click" />
            <br />
            <br />
        <table style="width: 100%;">
            <tr style="height: 20px;">
                    <td style="width: 100%; float:left;">
                <asp:GridView ID="grProductos" runat="server" CssClass="mGrid1" DataKeyNames="Codigo de barras" OnSelectedIndexChanged="grProductos_SelectedIndexChanged">
                     <Columns>
                                <asp:TemplateField HeaderText="Visualizar">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="ImagenSelec" runat="server" CommandName="Select" ImageUrl="~/Imagenes/vision.png"/>
                                   </ItemTemplate>
                               </asp:TemplateField>
                            </Columns>
                </asp:GridView>
                </td>
            </tr>
            <tr style="height:20px;">
                <td style="width:50%; float:left">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" CssClass="cssBotonPanel" OnClick="btnInsertar_Click"/>
                    <br />
                    <br />
                </td>
            </tr>
            <tr style="height:20px;">
                <td style="width:25%; float:left">
                     <asp:Label ID="lblNombre" runat="server" Text="Nombre producto:" Visible="false"></asp:Label>                
                </td>
                <td style="width:25%; float:left">
                    <asp:TextBox ID="txtNombre" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:20px;">
                <td style="width:25%; float:left">
                    <asp:Label ID="lblCodigo" runat="server" Text="Codigo de barras:" Visible="false"></asp:Label>
                </td>
                <td style="width:25%; float:left">
                    <asp:TextBox ID="txtCodigo" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:20px;">
                <td style="width:25%; float:left">
                    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" Visible="false"></asp:Label>
                </td>
                <td style="width:25%; float:left">
                    <asp:TextBox ID="txtCantidad" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:20px;">
                <td style="width:25%; float:left">
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio:" Visible="false"></asp:Label>
                </td>
                <td style="width:25%; float:left">
                    <asp:TextBox ID="txtPrecio" runat="server" placeholder="$ 0.00" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:20px;">
                <td style="width:25%; float:left">
                    <asp:Label ID="lblSucursal" runat="server" Text="Sucursal" Visible="false"></asp:Label>
                </td>
                <td style="width:25%; float:left">
                    <asp:DropDownList ID="DrSucursal" runat="server" AutoPostBack="false" Visible="false" OnSelectedIndexChanged="grProductos_SelectedIndexChanged"></asp:DropDownList>
                    <br />
                    <br />
                </td>
            </tr>
            <tr style="height:20px;">
                <td style="width:25%; float:left">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="cssBotonPanel" Visible="false" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="cssBotonPanel" Visible="false" OnClick="btnActualizar_Click" />
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>
</asp:Content>
