<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Comprar.aspx.cs" Inherits="Loja_Computadores.Comprar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Comprar Produto</h1>
    <div class="row">
        <div class="col">
                <asp:Image CssClass="img-fluid" ID="imgProduto" runat="server" /><br />
        </div>
        <div class="col">
        Nome:<asp:Label runat="server" CssClass="form-control" ID="lbNome"></asp:Label><br />
        Tipo:<asp:Label runat="server" CssClass="form-control" ID="lbDescricao"></asp:Label><br />
        Preço:<asp:Label ID="lbPreco" CssClass="form-control" runat="server" Text=""></asp:Label><br />

        <div id="divMorada" runat="server">
            <h3>Morada</h3>
            Rua: <asp:Label runat="server" CssClass="form-control" ID="lbMorada"></asp:Label><br />
        </div> 
        <asp:Button runat="server" CssClass="btn btn-primary" ID="btnMudaMorada" Text="Nova Morada" OnClick="btnMudaMorada_Click" /><br />
        <div id="divNovaMorada" runat="server">
            <h3>Adicionar Morada</h3>
            Rua:<asp:TextBox runat="server" CssClass="form-control" ID="tbMorada"></asp:TextBox><br />
            <asp:Button runat="server" CssClass="btn btn-success" ID="AddMorada" Text="Adicionar Morada"  OnClick="AddMorada_Click" />
            <asp:Button runat="server" CssClass="btn btn-secondary" ID="btCancelAddMorada" Text="Cancelar" OnClick="btCancelAddMorada_Click" /><br />
        </div><br />
        Quantidade: <asp:TextBox runat="server" CssClass="form-control" ID="tbQuatidade" AutoPostBack OnTextChanged="tbQuatidade_TextChanged"></asp:TextBox><br />
        Total: <asp:Label runat="server" ID="lbTotal"></asp:Label><br />
        <asp:Button runat="server"  CssClass="btn btn-success btn-lg" Text="Comprar" ID="btnComprar" OnClick="btnComprar_Click"/>
        <asp:Button runat="server" CssClass="btn btn-secondary btn-lg" Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" /><br />
        <asp:Label runat="server" ID="lbErro"></asp:Label>
        </div>
    </div>
</asp:Content>
