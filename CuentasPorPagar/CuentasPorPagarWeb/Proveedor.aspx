<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedor.aspx.cs" Inherits="CuentasPorPagarWeb.Proveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <span>
        Estado de cuenta proveedor
    </span>
    <br />
    <br />
    Codigo de proveedor (NRC): <asp:TextBox ID="txtNRC" runat="server"></asp:TextBox> <asp:Button runat="server" Text="Buscar" OnClick="Unnamed1_Click"></asp:Button>
    <br />
    <br />
    Desde: <asp:TextBox ID="txtInicio" type="date" runat="server"></asp:TextBox>
     Hasta: <asp:TextBox ID="txtFin" type="date" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:GridView ID="dataGridView" runat="server"></asp:GridView>
    <br />
    <br />
    <asp:Button runat="server" Text="Exportar CSV" OnClick="Unnamed2_Click"></asp:Button>  
    <asp:Button runat="server" Text="Exportar PDF" OnClick="Unnamed3_Click"></asp:Button>
</asp:Content>
