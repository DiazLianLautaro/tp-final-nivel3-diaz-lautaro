<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ArticuloFormulario.aspx.cs" Inherits="WebForm.ArticuloFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (txtId.Text == ""){%>

    <h2>Formulario de Carga</h2>

    <%}else{%>

    <h2>Formulario de Modificación</h2>

    <%} %>

    <asp:ScriptManager runat="server" />
    <%--Para que UpdatePanel funciones--%>
    <div class="row">
        <div class="col-6">

            <%if (txtId.Text != ""){%>
            <div class="mb-3">
                <asp:Label ID="lblId" for="tbxId" Text="Id (Solo lectura)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtId" CssClass="form-control formGreey border-dark" ReadOnly="true" runat="server" />
            </div>
            <%}%>

            <div class="mb-3">
                <asp:Label ID="lblCodigo" for="tbxCodigo" Text="Código" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtCodigo" class="form-control formGreey border-dark" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Código no debe estar vacío." ControlToValidate="txtCodigo" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblNombre" for="tbxNombre" Text="Nombre" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" class="form-control formGreey border-dark" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Nombre no debe estar vacío." ControlToValidate="txtNombre" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblMarca" Text="Marca" runat="server" />
                <asp:DropDownList ID="ddlMarca" CssClass="form-select formGreey border-dark" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblCategoria" Text="Categoría" runat="server" />
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select formGreey border-dark" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label ID="lblPrecio" Text="Precio" runat="server" />
                <asp:TextBox ID="txtPrecio" CssClass="form-control formGreey border-dark" runat="server" placeHolder="0000" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Precio no debe estar vacío." ControlToValidate="txtPrecio" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" runat="server" />
            </div>
                <%if (txtId.Text != ""){%>
                <%--Funcionalidad para Eliminar un Artículo--%>
            <div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                        </div>
                        <%if (confirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox ID="chbxConfirmarEliminar" Text="Confirmar Eliminación" runat="server" />
                            <asp:Button ID="btnConfirmarEliminar" Text="Confirmar" OnClick="btnConfirmarEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                        <%} %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <%}%>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblDescripcion" Text="Descripción" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control formGreey border-dark" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Descripción no debe estar vacío." ControlToValidate="txtDescripcion" runat="server" />
            </div>
            <asp:UpdatePanel ID="udpImagen" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label ID="lblImagen" Text="Imagen" runat="server" />
                        <asp:TextBox ID="txtaImagen" AutoPostBack="true" OnTextChanged="txtaImagen_TextChanged" CssClass="form-control formGreey border-dark" runat="server" />
                        <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Campo Imagen no debe estar vacío." ControlToValidate="txtaImagen" runat="server" />
                    </div>
                    <asp:Image ID="imgArticulo" class="tamañoImagensDetalle" ImageUrl="https://th.bing.com/th/id/R.ca0f4aeff51ff7e15c440816546f7730?rik=eJ5AEYKPVEnIIA&pid=ImgRaw&r=0&sres=1&sresct=1" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
