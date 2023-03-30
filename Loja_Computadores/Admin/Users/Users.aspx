<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Loja_Computadores.Admin.Users.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gestão de Utilizadores</h2>
    <asp:GridView ID="gvUsers" runat="server" CssClass="table" />
    <h2>Adicionar Utilizador</h2>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbEmail"> Email: </label>
        <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" MaxLength="100" Required placeholder="Email" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbNome"> Nome: </label>
        <asp:TextBox ID="tbNome" CssClass="form-control" runat="server" MaxLength="100" Required placeholder="Nome" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbMorada"> Morada: </label>
        <asp:TextBox ID="tbMorada" CssClass="form-control" runat="server" MaxLength="100" Required placeholder="Morada" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbNif"> Nif: </label>
        <asp:TextBox ID="tbNif" CssClass="form-control" runat="server" MaxLength="100" Required placeholder="Nif" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbPassword"> Password: </label>
        <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="100" Required placeholder="Password" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_dpPerfil"> Perfil: </label>
        <asp:DropDownList runat="server" ID="dpPerfil"> 
            <asp:ListItem Value="0">Admin</asp:ListItem>
            <asp:ListItem Value="1">Leitor</asp:ListItem>
        </asp:DropDownList><br /><br />
    </div>
    <asp:Button runat="server" CssClass="btn btn-lg btn-success" ID="btAdicionar" Text="Adicionar" OnClick="btAdicionar_Click" /><br />
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
