<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="WebForm.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style> 
        .validacion{
            color: red;
            font-size: 15px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="tbxNombre" CssClass="form-control formGreey border-dark" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Nombre no debe estar vacío." ControlToValidate="tbxNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="tbxApellido" CssClass="form-control formGreey border-dark" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Apellido no debe estar vacío." ControlToValidate="tbxApellido" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="tbxEmail" Type="Email" AutoPostBack="true" CssClass="form-control formGreey border-dark" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Correo no debe estar vacío." ControlToValidate="tbxEmail" runat="server" />
            </div>
        </div>

        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" id="txtImagen" class="form-control bg-dark text-light border-dark" runat="server" />
            </div>
            <%--<asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
                    <asp:Image ID="imgImagenPerfil" ImageUrl="https://th.bing.com/th/id/R.ca0f4aeff51ff7e15c440816546f7730?rik=eJ5AEYKPVEnIIA&pid=ImgRaw&r=0&sres=1&sresct=1"
                        CssClass="img-fluid mb-3" runat="server" />
                <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" />
            <a href="Default.aspx">Regresar</a>
        </div>
    </div>

</asp:Content>
