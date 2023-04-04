<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="OyunHavasi_WebApp.AdminPanel.KategoriDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <div class="formTitle">
            <h3>Kategori Düzenle</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="pnl_basarili" Visible="false">
                Kategori Düzenleme Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="pnl_basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_kategoriAdi" runat="server" CssClass="inputbox"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_Duzenle" runat="server" OnClick="lbtn_Duzenle_Click" CssClass="formButton">Kategori Düzenle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>

