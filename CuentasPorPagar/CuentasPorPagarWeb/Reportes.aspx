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

          <button type="button" class="list-group-item list-group-item-action">Morbi leo risus</button>
          <button type="button" class="list-group-item list-group-item-action">Estado por proveedor</button>
          <button type="button" class="list-group-item list-group-item-action" disabled>Vestibulum at eros</button>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#todosDocumentos").click(function () {

                window.location = "Documentos.aspx";
            });
        });
    </script>
   
        

</asp:Content>
