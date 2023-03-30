<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PcPartPicker.aspx.cs" Inherits="Loja_Computadores.PcPartPicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Configurador de PC - Beta  <h3>Total:<asp:Label runat="server" ID="lbTotal"></asp:Label></h3></h1><br />
<h3>Processador</h3>
<asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="dpCPU" OnSelectedIndexChanged="dpCPU_SelectedIndexChanged"></asp:DropDownList>
<h3>Motherboard</h3>
<asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="dpMotherboard" OnSelectedIndexChanged="dpMotherboard_SelectedIndexChanged"></asp:DropDownList>
<h3>Ram</h3>
<asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="dpRam" OnSelectedIndexChanged="dpRam_SelectedIndexChanged"></asp:DropDownList>
<h3>PlacaGráfica</h3>
<asp:DropDownList runat="server" CssClass="form-control" ID="dpGrafica"></asp:DropDownList>
<h3>Fonte de Alimentação</h3>
<asp:DropDownList runat="server" CssClass="form-control" ID="dpPSU"></asp:DropDownList>
<h3>Armazenamento</h3>
<asp:DropDownList runat="server" CssClass="form-control" ID="dpArmazenamento"></asp:DropDownList>
<h3>Caixa</h3>
<asp:DropDownList runat="server" CssClass="form-control" ID="dpCaixa"></asp:DropDownList>
<br />

</asp:Content>
