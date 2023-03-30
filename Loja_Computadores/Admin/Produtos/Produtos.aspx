<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Loja_Computadores.Admin.Produtos.Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ver Produtos</h2><br />
    <h4>Filtrar Produtos</h4>
    <asp:RadioButtonList runat="server" ID="rbfiltra" AutoPostBack="true" OnSelectedIndexChanged="rbfiltra_SelectedIndexChanged">
        <asp:ListItem Value="1" Selected="True">Todos</asp:ListItem>
        <asp:ListItem Value="2">Descontinuados</asp:ListItem>
        <asp:ListItem Value="3">Disponíveis</asp:ListItem>
    </asp:RadioButtonList>
    <asp:GridView ID="gv_Produtos" CssClass="table" runat="server" /><br />
    <h2>Adicionar Produto</h2><br /><br />
    <h3>Nome:</h3><br/>
    <asp:TextBox runat="server" CssClass="form-control" ID="tbNome" /><br />
    <h3>Tipo</h3><br />
    <asp:DropDownList runat="server" CssClass="form-control" ID="dpTipo" AutoPostBack="true" OnSelectedIndexChanged="dpTipo_SelectedIndexChanged" /><br />
    <div runat="server" id="divCPU">
        <h3>Marca</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpMarcaCPU" AutoPostBack="true" OnSelectedIndexChanged="dpMarcaCPU_SelectedIndexChanged" /><br />
        <h3>Socket</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpSocketCPU" AutoPostBack="true" OnSelectedIndexChanged="dpSocketCPU_SelectedIndexChanged"/><br />
        <h3>Modelo</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpModeloCPU" /><br />
        <h3>Geração</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpGeracaoCPU" /><br />
    </div>
    <div runat="server" id="divMotherboard">
        <h3>Marca</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpMarcaMotherBoard" /><br />
        <h3>Formato</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpFormatoMotherboard" /><br />
        <h3>Fabricante de Processadores Compatíveis</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpCPUMotherboard" AutoPostBack="true" OnSelectedIndexChanged="dpCPUMotherboard_SelectedIndexChanged"/><br />
        <h3>Socket</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpSocketMotherboard" AutoPostBack="true" OnSelectedIndexChanged="dpSocketMotherboard_SelectedIndexChanged"/><br />
        <h3>Chipset</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpChipset" /><br />
        <h3>Tipo de Memória Ram</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpTipoRamMotherboard" AutoPostBack="true" OnSelectedIndexChanged="dpTipoRamMotherboard_SelectedIndexChanged"/><br />
        <h3>Slots de Memória Ram</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpRamSlots" /><br />
        <h3>Velocidade de Ram compatível</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpVelocidadeMax" /><br />
        <h3>Slots de SSDs M.2</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpSlotsM2" /><br />
        <asp:CheckBox runat="server" CssClass="form-control" ID="chkWifi" /> Wi-fi <br />
    </div>
    <div runat="server" id="divRam">
        <h3>Marca</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpMarcaRam" /><br />
        <h3>Tipo de Memória Ram</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpTipoRam" AutoPostBack="true" OnSelectedIndexChanged="dpTipoRam_SelectedIndexChanged"/><br />
        <h3>Capacidade da Memória Ram</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpCapacidadeRam" /><br />
        <h3>Velocida da Memória Ram</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpVelocidadeRam" /><br />
    </div>
    <div runat="server" id="divGrafica">
        <h3>Marca</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpMarcaGrafica" /><br />
        <h3>Modelo</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpModeloGrafica" /><br />
    </div>
    <div runat="server" id="divPSU">
        <h3>Marca</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpMarcaPSU" /><br />
        <h3>Watts</h3><br />
        <asp:TextBox TextMode="Number" runat="server" CssClass="form-control" ID="tbWatts" /><br />
        <asp:CheckBox runat="server" CssClass="form-control" ID="chkModular" /> Modular<br />
    </div>
    <div runat="server" id="divArmazenamento">
        <h3>Marca</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpMarcaArmazenamento" /><br />
        <h3>Tipo</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpTipoArmazenamento" /><br />
        <h3>Tamanho</h3><br />
        <asp:TextBox TextMode="number" runat="server" CssClass="form-control" ID="tbTamanho" /><br />
    </div>
    <div runat="server" id="divCaixa">
        <h3>Marca</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpMarcaCaixa" /><br />
        <h3>Formato</h3><br />
        <asp:DropDownList runat="server" CssClass="form-control" ID="dpFormatoCaixa" /><br />
    </div>
    <h3>Preço</h3><br />
    <asp:TextBox runat="server" CssClass="form-control" ID="tbPreco" /><br />
    <h3>Data Aquisição:</h3><br />
    <asp:TextBox TextMode="Date" runat="server" CssClass="form-control" ID="tbAquisicao" /><br />
    <h3>Stock</h3><br />
    <asp:TextBox TextMode="Number" runat="server" CssClass="form-control" ID="tbStock" /><br />
    <h3>Imagem</h3><br />
    <asp:FileUpload ID="fuImg" runat="server" CssClass="form-control" /><br />
    <asp:Button runat="server" CssClass="btn btn-lg btn-success" ID="btAdicionar" Text="Adicionar" OnClick="btAdicionar_Click"/>
    <asp:Button runat="server" CssClass="btn btn-lg btn-secondary" ID="btCancelar" Text="Cancelar" OnClick="btCancelar_Click"/>
</asp:Content>
