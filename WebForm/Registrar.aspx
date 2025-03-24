<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="WebForm.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Regristrar</h2>
    <h4>Complete Los Campos Para Registrarse.</h4>
    <div class="row">
        <div class="col-10">
            <%--Nombre--%>
            <div class="col-md-6 mb-1">
                <asp:Label Text="Nombre" ID="lblNombre" runat="server" />
                <asp:TextBox ID="tbxNombre" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <%--Apellido--%>
            <div class="col-md-6 mb-1">
                <asp:Label Text="Apellido" ID="lblApellido" runat="server" />
                <asp:TextBox ID="tbxApellido" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <%--Correo--%>
            <div class="col-md-6 mb-1">
                <asp:Label Text="Correo" ID="lblUsuarioRegistrar" runat="server" />
                <asp:TextBox ID="tbxEmailRegistrar" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <%--Contraseña--%>
            <div class="col-md-6 mb-3">
                <asp:Label Text="Contraseña" ID="lblContraseñaRegistrar" runat="server" />
                <asp:TextBox type="password" ID="tbxPassRegistrar" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <asp:Button ID="btnAceptarRegistro" Text="Registrarme" CssClass="btn btn-primary" OnClick="btnAceptarRegistro_Click" runat="server" />
            <asp:Button ID="btnCancelarRegistro" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelarRegistro_Click" runat="server" />
            <%--<asp:Label Text="" ID="lblSaludo" runat="server" />--%>
        </div>
    </div>
</asp:Content>
