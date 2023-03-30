<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detalhesproduto.aspx.cs" Inherits="Loja_Computadores.detalhesproduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div Class="row">
        <div class="col">
            <asp:Image CssClass="img-fluid" ID="imgProduto" runat="server" /><br />
        </div>
        <div class="col">
            <asp:Label ID="lbNome" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbDescricao" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbPreco" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lbStock" runat="server" Text=""></asp:Label><br />
            <asp:Button CssClass="btn btn-success" ID="btComprar" runat="server" Text="Comprar" OnClick="btComprar_Click" /><br />
        </div>
    </div>
    
    
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
