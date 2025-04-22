<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebForm.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="tbxEmail" CssClass="form-control formGreey border-dark" runat="server" />  
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Email no debe estar vacío." ControlToValidate="tbxEmail" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Asunto</label>
                <asp:TextBox ID="tbxAsunto" CssClass="form-control formGreey border-dark" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Asunto no debe estar vacío." ControlToValidate="tbxAsunto" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:TextBox ID="tbxMensaje" CssClass="form-control formGreey border-dark" TextMode="MultiLine" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Mensaje no debe estar vacío." ControlToValidate="tbxMensaje" runat="server" />
            </div>
            <asp:Button ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server" />
            <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" runat="server" />
        </div>
        <div class="col"></div>
    </div>

</asp:Content>
