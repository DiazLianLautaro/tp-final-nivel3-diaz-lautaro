<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebForm.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <h2>Lista de Productos</h2>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <%--Filtro Rápido--%>
            <%if (!(chxFiltroAvanzado.Checked)){%> <%--Si filtroAvanzado NO está cheked, mostrar filtro rápido --%>     
                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <asp:Label Text="Filtrar" runat="server" />
                                <asp:TextBox ID="tbxFiltro" CssClass="form-control formGreey border-dark" runat="server" AutoPostBack="true" OnTextChanged="tbxFiltro_TextChanged" />
                            </div>
                        </div>
                    </div>               
            <%} %>


            <%--Filtro Avanzado--%>
            <asp:CheckBox Text="Filtro Avanzado"
                OnCheckedChanged="chxFiltroAvanzado_CheckedChanged"
                AutoPostBack="true"
                ID="chxFiltroAvanzado"
                runat="server" />

            <%if (chxFiltroAvanzado.Checked){%> <%--Si filtroAvanzado SI está cheked, mostrar filtro avanzado --%>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                            <asp:DropDownList runat="server" ID="ddlCampo" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-control formGreey border-dark">
                                <asp:ListItem Text="Nombre" />
                                <asp:ListItem Text="Código" />
                                <asp:ListItem Text="Marca" />
                                <asp:ListItem Text="Categoría" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Criterio" runat="server" />
                            <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                    <div class="col-8">
                        <div class="mb-3">
                            <asp:Label Text="Filtro" runat="server" />
                            <asp:TextBox runat="server" ID="tbxFiltroAvanzado" CssClass="form-control formGreey border-dark" />
                        </div>
                    </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
                        <asp:Button Text="Limpiar" CssClass="btn btn-primary" ID="btnLimpiar" OnClick="btnLimpiar_Click" runat="server" />
                    </div>
                </div>
            <%}%>


            <div class="row">
                <div class="col-12">
                    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id"
                        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                        AllowPaging="True" PageSize="6"
                        CssClass="table table-dark table-bordered"
                        AutoGenerateColumns="false"
                        AutoPostBack="true">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Código" DataField="Codigo" />
                            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca.MDescripcion" />
                            <asp:BoundField HeaderText="Categoría" DataField="Categoria.CDescripcion" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />

                            <%--Acciones del dgv--%>
                            <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Acción" />
                        </Columns>
                    </asp:GridView>
                    <a href="ArticuloFormulario.aspx" class="btn btn-primary">Agregar</a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
