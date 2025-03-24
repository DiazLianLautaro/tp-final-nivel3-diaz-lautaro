<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Bienvenido al Catálogo de Artículos</h2>

    <%--Sí hay usuario "Ingresaste" sino "Debes loguearte"--%>
    <%if (Session["usuario"] != null){%>
            <asp:Label Text="text" ID="lblUser" class="h4" runat="server" />
            <h4>Ingresaste Correctamente</h4>
    <%}else{ %>
            <h4>Debes Ingresar Para Continuar</h4>
            <a href="Login.aspx" class="btn btn-outline-success me-2">Ingresar</a>
    <%} %>

    <hr />

    <%-- El Repeater puede mandar un dato al CodeBehind--%>
    <div class="row row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 border-black Cardc">
                        <img src="<%#Eval("ImagenUrl") %>" onerror="this.onerror=null; this.src='https://png.pngtree.com/png-clipart/20230812/original/pngtree-photo-gallery-image-element-vector-picture-image_10495065.png'" class="card-img-top tamañoImagens " alt="...">
                        <div class="card-body Cardfooter border-black rounded-bottom-4 card-footer">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <%--Pendiente, navegar llevando el Id a la página necesaria--%>
                            <a href="Detalle.aspx?id=<%#Eval("Id") %>" class="btn btn-danger">Carrito</a>
                            <a href="Detalle.aspx?id=<%#Eval("Id") %>" class="btn btn-danger">Ver Detalles</a>
                            <a href="Detalle.aspx?id=<%#Eval("Id") %>" class="btn btn-danger">favorito</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
