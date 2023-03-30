<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddStockProduto.aspx.cs" Inherits="Loja_Computadores.Admin.Produtos.AddStockProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Adicionar Stock</h1>
    <div class="row">
        <div class="col">
    <asp:Image CssClass="figure-img" runat="server" ID="imgProduto" /><br />
        
    ID Produto: <asp:Label ID="lbId" runat="server"></asp:Label>
    Nome: <asp:Label ID="lbNome" runat="server"></asp:Label><br />
    Tipo: <asp:Label runat="server" ID="lbTipo"></asp:Label>
    Data de Aquisição: <asp:Label runat="server" ID="lbAquisicao"></asp:Label><br />
    Preço: <asp:Label runat="server" ID="lbPreco"></asp:Label>
    Stock: <asp:Label runat="server" ID="lbStock"></asp:Label><br />
    Estado: <asp:Label runat="server" ID="lbEstado"></asp:Label><br />
    <asp:Label runat="server"  CssClass="form-control" ID="lbErro"></asp:Label>
            </div>
        <div class="col">
    <h3>Adicionar Stock</h3>
    Stock a Adicionar: <asp:TextBox runat="server" CssClass="form-control" ID="tbAddStock"></asp:TextBox>
        <asp:Button runat="server" CssClass="btn btn-lg btn-success" Text="Adicionar Stock" ID="btnAddStock" OnClick="btnAddStock_Click" />
        <asp:Button runat="server" CssClass="btn btn-lg btn-secondary" Text="Voltar" ID="btnVoltar" OnClick="btnVoltar_Click" />
            </div>
    </div>
</asp:Content>
