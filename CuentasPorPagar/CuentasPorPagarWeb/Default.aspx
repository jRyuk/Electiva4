<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CuentasPorPagarWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div class="jumbotron">
    <table style="width: 100%">
        <tr>
            <td style="text-align:center">
                <p>Usuario:<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUser" ErrorMessage="* Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
            </td>
        </tr>
        <tr>
            <td style="text-align:center"><p>Password:<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="* Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        </p></td>
        </tr>
        <tr>
            <td style="text-align:center"><p><asp:Button ID="btnLogin" runat="server" OnClick="Button1_Click" Text="Ingresar" />
        </p>
                <p aria-hidden="False">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </p></td>
        </tr>
    </table>
        
        
        
        
    </div>

   
        <script type="text/javascript">
            $(document).ready(function () {
                $("#liInicio").click(function (e) {
                    e.preventDefault();
                })
            });
        </script>

</asp:Content>
