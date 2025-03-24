<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ArticuloFormulario.aspx.cs" Inherits="WebForm.ArticuloFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Formulario de carga o modificar</h2>

    <asp:ScriptManager runat="server" />
    <%--Para que UpdatePanel funciones--%>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblId" for="tbxId" Text="Id (Solo lectura)" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtId" CssClass="form-control formGreey border-dark" ReadOnly="true" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblCodigo" for="tbxCodigo" Text="Código" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtCodigo" class="form-control formGreey border-dark" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblNombre" for="tbxNombre" Text="Nombre" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" class="form-control formGreey border-dark" runat="server" />
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
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" runat="server" />
            </div>
            <div>
                <%--Funcionalidad para Eliminar un Artículo--%>
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
        </div>

        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblDescripcion" Text="Descripción" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <asp:UpdatePanel ID="udpImagen" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label ID="lblImagen" Text="Imagen" runat="server" />
                        <asp:TextBox ID="txtaImagen" AutoPostBack="true" OnTextChanged="txtaImagen_TextChanged" CssClass="form-control formGreey border-dark" runat="server" />
                    </div>
                    <asp:Image ID="imgArticulo" class="tamañoImagens" ImageUrl="https://coffective.com/wp-content/uploads/2018/06/default-featured-image.png.jpg" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
