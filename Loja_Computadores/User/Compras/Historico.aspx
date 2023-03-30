<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="Loja_Computadores.User.Compras.Historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Compras Efetuadas</h1>
    <asp:GridView runat="server" CssClass="table" ID="gv_Historico"></asp:GridView>
</asp:Content>
