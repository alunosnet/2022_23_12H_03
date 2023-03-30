<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Loja_Computadores.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table">
        <div class="row">
                <!--Pesquisa-->
    <div class="col-sm-8 float-start">
        <h1>Pesquisar</h1>
        <div class=" col-sm-8 input-group">
            <asp:TextBox CssClass="form-control" ID="tbPesquisa" runat="server"></asp:TextBox>
            <span class="input-group-btn">
                <asp:Button CssClass="btn btn-info" runat="server" ID="btPesquisar" Text="Pesquisar" OnClick="btPesquisar_Click" />
            </span>
        </div>
    </div><br />
        </div>
        </div>
            <div class="row">
                <div class="col-2">
                 <!-- filtros -->
    <asp:RadioButtonList runat="server" ID="rbfiltra" AutoPostBack="true">
        <asp:ListItem Value="0" Selected="True">Todos</asp:ListItem>
        <asp:ListItem Value="1">CPU</asp:ListItem>
        <asp:ListItem Value="2">Motherboard</asp:ListItem>
        <asp:ListItem Value="3">Ram</asp:ListItem>
        <asp:ListItem Value="4">Gráfica</asp:ListItem>
        <asp:ListItem Value="5">PSU</asp:ListItem>
        <asp:ListItem Value="6">Armazenamento</asp:ListItem>
        <asp:ListItem Value="7">Caixa</asp:ListItem>
    </asp:RadioButtonList>
            </div>
            <div class="col">
                <!-- Lista Produtos -->
    <div class="float-start col-md-8 m-1" id="divProdutos" runat="server"></div>

            </div>
        </div>
   
</asp:Content>
    
   

    
