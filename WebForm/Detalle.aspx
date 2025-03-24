<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebForm.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
            <%if (Conexión.Seguridad.esAdmin(Session["usuario"]))
                {%>
            <div>
                <h1>Sos admin, podés ver el ID.</h1>
                <hr />
                <asp:Label Text="ID" runat="server" />
                <asp:TextBox Text="id" ReadOnly="true" CssClass="form-control formGreey rounded-pill border-dark text-body-secondary" runat="server" />
            </div>
            <%} %>
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Código" CssClass="" runat="server" />
                <asp:TextBox Text="código" ReadOnly="true" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" runat="server" />
                <asp:TextBox Text="Nombre" ReadOnly="true" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Descripción" runat="server" />
                <asp:TextBox Text="Descripción" ReadOnly="true" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Marca" runat="server" />
                <asp:TextBox Text="Marca" ReadOnly="true" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Categoría" runat="server" />
                <asp:TextBox Text="Categoría" ReadOnly="true" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Precio" runat="server" />
                <asp:TextBox Text="Precio" ReadOnly="true" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Imagen" runat="server" />
                <asp:TextBox Text="Imagen" ReadOnly="true" CssClass="form-control formGreey border-dark" runat="server" />
            </div>
            <asp:Image CssClass="tamañoImagensDetalle" ImageUrl="https://th.bing.com/th/id/R.ca0f4aeff51ff7e15c440816546f7730?rik=eJ5AEYKPVEnIIA&pid=ImgRaw&r=0&sres=1&sresct=1" runat="server" />
        </div>
    </div>

</asp:Content>
