<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MudarEstadoProduto.aspx.cs" Inherits="Loja_Computadores.Admin.Produtos.MudarEstadoProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mudar Estado do Produto</h1><br />
    <div class="alert alert-success" role="alert">
        <asp:Label ID="lbSuccess" runat="server"> </asp:Label>
    </div>
    <asp:Image CssClass="figure-img" runat="server" ID="imgProduto" /><br />
    ID Produto: <asp:Label ID="lbId" runat="server" CssClass="form-control"></asp:Label><br />
    Nome: <asp:Label ID="lbNome" runat="server" CssClass="form-control"></asp:Label><br />
    Tipo: <asp:Label runat="server" CssClass="form-control" ID="lbTipo"></asp:Label><br />
    Data de Aquisição: <asp:Label runat="server" CssClass="form-control" ID="lbAquisicao"></asp:Label><br />
    Preço: <asp:Label runat="server" CssClass="form-control" ID="lbPreco"></asp:Label><br />
    Stock: <asp:Label runat="server" CssClass="form-control" ID="lbStock"></asp:Label><br />
    Estado: <asp:Label runat="server" CssClass="form-control" ID="lbEstado"></asp:Label><br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btMuda" Text="Mudar Estado" OnClick="btMuda_Click"/>
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btVoltar" Text="Voltar" OnClick="btVoltar_Click" />
    <br />
    <asp:Label ID="lbErro" runat="server"></asp:Label>
</asp:Content>
