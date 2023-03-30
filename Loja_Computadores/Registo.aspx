<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registo.aspx.cs" Inherits="Loja_Computadores.Registo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registo</h2>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbEmail">Email: </label>
        <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" MaxLength="100" placeholder="Email" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbNome">Nome: </label>
        <asp:TextBox ID="tbNome" CssClass="form-control" runat="server" MaxLength="100" placeholder="Nome (Primeiro e Ultimo)" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbMorada">Morada: </label>
        <asp:TextBox ID="tbMorada" CssClass="form-control" runat="server" MaxLength="100" placeholder="Morada" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbNif">Nif: </label>
        <asp:TextBox ID="tbNif" CssClass="form-control" runat="server" MaxLength="100" placeholder="Nif" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbPassword">Password: </label>
        <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="100" placeholder="Password" /><br />
    </div>
    <asp:Button runat="server" CssClass="btn btn-lg btn-success" ID="btRegistar" Text="Registar" OnClick="btRegistar_Click" /><br />
    <asp:Label runat="server" ID="lbErro" /><br />
    <!-- Recaptcha -->
    <div class="g-recaptcha" data-sitekey="6LczdM8jAAAAAMje4BXy1d-vly027TN18ZuO0YcK"></div>
</asp:Content>

