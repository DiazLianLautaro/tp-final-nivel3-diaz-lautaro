<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="WebForm.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repFavoritos">
                <ItemTemplate>
                    <div class="card h-100">
                        <div class="card-body">
                            <img src="'<%#Eval("ImagenUrl") %>'" onerror="this.onerror=null; this.src='https://png.pngtree.com/png-clipart/20230812/original/pngtree-photo-gallery-image-element-vector-picture-image_10495065.png'" class="card-img-top" alt="..." />
                            <div class="card-title">
                                <asp:label runat="server" Text='<%#Eval("Nombre") %>' class="card-title" />
                                <asp:label runat="server" Text='<%#Eval("Descripcion") %>' class="card-title" />
                                <asp:label runat="server" Text='<%#Eval("idFavorito") %>' class="card-title" />
                                <asp:label runat="server" Text='<%#Eval("idUser") %>' class="card-title" />
                                <asp:label runat="server" Text='<%#Eval("idArticulo") %>' class="card-title" />
                                
                                
                                <asp:Button ID="btnEliminarFav" CssClass="btn btn-danger" Text="Eliminar Favorito" OnClick="btnEliminarFav_Click" CommandArgument='<%#Eval("idFavorito") %>' CommandName="FavoritoId" runat="server" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>



</asp:Content>
