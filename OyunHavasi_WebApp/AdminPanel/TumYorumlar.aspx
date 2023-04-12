<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="TumYorumlar.aspx.cs" Inherits="OyunHavasi_WebApp.AdminPanel.TumYorumlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h2>Tüm Yorumlar Listesi</h2>
        <hr style="margin: 20px 0px" />
        <asp:ListView ID="lv_yorumlar" runat="server" OnItemCommand="lv_yorumlar_ItemCommand">
            <LayoutTemplate>
                <table class="formTable" cellspacing="0" cellpadding="0">
                    <tr>
                        <th>Uye</th>
                        <th>Makale</th>
                        <th>Icerik</th>
                        <th>Tarih</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Uye") %></td>
                    <td><%# Eval("Makale") %></td>
                   <td width="50%"><%# Eval("Icerik") %></td>
                    <td><%# Eval("EklemeTarihiStr") %></td>
                    <td><%# Eval("DurumStr") %></td>
                    <td>
                         <asp:LinkButton ID="lbtn_sil" runat="server" class="btn_sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>

        </asp:ListView>
    </div>
</asp:Content>
