<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" MasterPageFile="~/Site.Master" Inherits="CuentasPorPagarWeb.Reportes" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div class="row">
        <div class="list-group">
          <button type="button" class="list-group-item list-group-item-action active">
            Reportes
          </button>
          <button type="button" class="list-group-item list-group-item-action"  id="todosDocumentos" >
              Todos los documentos
          </button>

          <button id="docProveedor" type="button" class="list-group-item list-group-item-action">Documentos por proveedor</button>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#todosDocumentos").click(function () {

                window.location = "Documentos.aspx";
            });
        });

          $(document).ready(function () {
            $("#docProveedor").click(function () {

                window.location = "Proveedor.aspx";
            });
        });
    </script>
   
        

</asp:Content>
