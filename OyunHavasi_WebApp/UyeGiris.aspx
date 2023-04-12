<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="OyunHavasi_WebApp.UyeGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="loginPanel">
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="pnl_basarisiz" Visible="false">
            <label>Giriş Başarısız</label>
        </asp:Panel>
        <div class="left">
            <h1 style="margin-top:40px;">Oyun Havasına hoş geldiniz.</h1>
            <h3>Şık şıkı şık şıkı</h3>
        </div>
         <div class="right">
            <div class="row">
                 <h3>Hesabına Giriş Yap</h3>
             <br />
             <p>

             </p>
            </div>
             <div class="row">
                  <asp:TextBox ID="tb_mail" runat="server" CssClass="formInput" placeholder="Mail Adresiniz" ></asp:TextBox>
             </div>
             <div class="row">
                  <asp:TextBox ID="tb_sifre" runat="server" CssClass="formInput" TextMode="Password" placeholder="Şifreniz"></asp:TextBox>
             </div>
             <div class="row">
                  <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="formButton" OnClick="lbtn_giris_Click">Hesabıma Giriş Yap</asp:LinkButton>
             </div>
        </div>
        <div style="clear:both"></div>
    </div>
</asp:Content>
