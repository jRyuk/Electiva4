<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documentos.aspx.cs" Inherits="CuentasPorPagarWeb.Documentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:Label runat="server" Text="Label">Reporte de documentos </asp:Label>
    </div>
    <div class="row">
        
          <asp:GridView ID="GridView1" runat="server" CellPadding="10">
           </asp:GridView>
    </div>
  
    <div class="row">
          <div class="col-lg-8">

        </div>
        <div class="col-lg-2">
            <asp:Button ID="btnEportarCsv" runat="server" Text="Exportar CSV" OnClick="btnEportarCsv_Click"></asp:Button>
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btnExportarPdf" runat="server" Text="Exportar PDF" OnClick="btnExportarPdf_Click"></asp:Button>
        </div>
       
    </div>
</asp:Content>
