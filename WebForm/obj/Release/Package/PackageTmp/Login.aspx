<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForm.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Ingresar</h2>
    <div class="row">
        <div class="col-10">
            <div class="col-md-6 mb-1">
                <asp:Label Text="Correo" ID="lblUsuario" runat="server" />
                <asp:TextBox ID="tbxEmail" class="form-control formGreey border-dark" runat="server" />
            </div>
            <div class="col-md-6 mb-3">
                <asp:Label Text="Contraseña" ID="lblContraseña" runat="server" />
                <asp:TextBox type="password" ID="tbxPass" class="form-control formGreey border-dark" runat="server" />
            </div>
            <asp:Button ID="brnAceptar" CssClass="btn btn-primary" runat="server" Text="Ingresar" OnClick="brnIngresar_Click" />
        </div>
    </div>
    <%--<asp:Label Text="" ID="lblSaludo" runat="server" />--%>
</asp:Content>
