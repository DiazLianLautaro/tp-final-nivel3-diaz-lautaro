<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="WebForm.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col">
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                
                <h2>Artículos Favoritos</h2>
                
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <asp:Repeater runat="server" ID="repFavoritos">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card h-100 border-black Cardc">
                                    <img src="<%#Eval("ImagenUrl") %>" onerror="this.onerror=null; this.src='https://png.pngtree.com/png-clipart/20230812/original/pngtree-photo-gallery-image-element-vector-picture-image_10495065.png'" class="card-img-top" alt="..." />
                                    <div class="card-body Cardfooter border-black rounded-bottom-4 card-footer">
                                        <h4 class="card-title"><%#Eval("Nombre") %></h4>
                                        <h6 class="card-text"><%#Eval("Descripcion") %></h6>
                                        <p class="card-text">Marca: <%#Eval("Marca") %></p>
                                        <p class="card-text">Categoría: <%#Eval("Categoria") %></p>
                                        <h5 class="card-text">$<%#Eval("Precio") %></h5>
                                        <asp:Button ID="btnEliminarFav" CssClass="btn btn-danger" Text="Eliminar Favorito" OnClick="btnEliminarFav_Click" CommandArgument='<%#Eval("idFavorito") %>' CommandName="FavoritoId" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>




</asp:Content>
