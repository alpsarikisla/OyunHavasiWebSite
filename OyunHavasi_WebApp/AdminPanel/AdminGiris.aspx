<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="OyunHavasi_WebApp.AdminPanel.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="assets/css/adminGiris.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panelContainer">
            <div class="panelheader">
                <h3>Admin Giriş</h3>
            </div>
            <div class="panelContent">
              
                <div class="row">
                    <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="inputbox" placeholder="Kullanıcı Adı" Text="JoDo"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:TextBox ID="tb_sifre" runat="server"  CssClass="inputbox" placeholder="Şifre" Text="1234"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btn_giris" runat="server" CssClass="girisButton" Text="Giriş Yap" OnClick="btn_giris_Click" />
                </div>
                  <div class="row">
                      <asp:Label ID="lbl_mesaj" runat="server" style="color:red"></asp:Label>
                  </div>
            </div>
        </div>
    </form>
</body>
</html>
