<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Loja_Computadores.User.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Área de utilizador</h1>
    <div runat="server" id="divPerfil">
        Nome: <asp:Label runat="server" CssClass="form-control" ID="lbNome"></asp:Label>
        <br /> Morada: <asp:Label runat="server" CssClass="form-control" ID="lbMorada"></asp:Label>
        <br />Nif: <asp:Label runat="server" CssClass="form-control" ID="lbNif"></asp:Label>
        <br /> <asp:Button runat="server" CssClass="btn btn-lg btn-primary" ID="Editar" Text="Editar Perfil" OnClick="Editar_Click"/>
    </div>
    <div runat="server" id="divEditar">
        Nome: <asp:TextBox CssClass="form-control" runat="server" ID="tbNome"></asp:TextBox>
        <br /> Morada: <asp:TextBox CssClass="form-control" runat="server" ID="tbMorada"></asp:TextBox>
        <br />Nif: <asp:TextBox CssClass="form-control" runat="server" ID="tbNif"></asp:TextBox>
        <br />
        <asp:Button runat="server" CssClass="btn btn-lg btn-success" ID="btAtualizar" Text="Atualizar Perfil" OnClick="btAtualizar_Click"/>
        <asp:Button runat="server" CssClass="btn btn-lg btn-danger" ID="btCancelar" Text="Cancelar" OnClick="btCancelar_Click"/>
    </div>
</asp:Content>
