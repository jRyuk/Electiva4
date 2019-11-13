<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CuentasPorPagarWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div class="jumbotron">
        <p>Usuario:<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        </p>
        <p>Password:<asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
        </p>
        <p><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </div>

   
        

</asp:Content>
