<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vendas.aspx.cs" Inherits="Loja_Computadores.Admin.Vendas.Vendas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Vendas Efetuadas</h1>
    <asp:GridView runat="server" CssClass="table" ID="gv_Vendas"></asp:GridView>
</asp:Content>
