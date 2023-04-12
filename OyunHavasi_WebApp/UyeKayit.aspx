<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeKayit.aspx.cs" Inherits="OyunHavasi_WebApp.UyeKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="registerPanel">
        <div class="row">
            <h1>Üye Ol</h1>
            <br />
            <p class="subtitle">
                Hanımların dikkatine oyun havası ayağınıza geldi.
                Mouse kenarı klavye kenarı itinayla ayarlanır 5dk da teslim edilir.
            </p>
        </div>
       <div class="row">
                <table class="formTable">
                    <tr>
                        <td>İsim</td>
                        <td>
                            <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Soyad</td>
                        <td>
                            <asp:TextBox ID="tb_soyad" runat="server" CssClass="formInput"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Kullanıcı Adı</td>
                        <td>
                            <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="formInput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Mail</td>
                        <td>
                            <asp:TextBox ID="tb_mail" runat="server" CssClass="formInput"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Şifre</td>
                        <td>
                            <asp:TextBox ID="tb_sifre" runat="server" CssClass="formInput"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
       
        <div class="row">
            <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="formButton">Üye Kaydımı Oluştur</asp:LinkButton>
        </div>
    </div>
</asp:Content>
