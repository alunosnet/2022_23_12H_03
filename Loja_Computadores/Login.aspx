﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Loja_Computadores.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
        Email:<asp:TextBox CssClass="form-control" TextMode="Email" runat="server" ID="tb_Email"></asp:TextBox><br />
        Password:<asp:TextBox CssClass="form-control" runat="server" ID="tb_Password" TextMode="Password"></asp:TextBox><br />
        <asp:Label runat="server" ID="lb_erro"></asp:Label><br />
        <asp:Button  CssClass="btn btn-info" runat="server" ID="bt_login" Text="Login" OnClick="bt_login_Click" />
        <asp:Button  CssClass="btn btn-danger" runat="server" ID="bt_recuperar" Text="Recuperar password" OnClick="bt_recuperar_Click" />
</asp:Content>
