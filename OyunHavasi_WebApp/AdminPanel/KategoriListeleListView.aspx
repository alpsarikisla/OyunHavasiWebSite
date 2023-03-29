<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="KategoriListeleListView.aspx.cs" Inherits="OyunHavasi_WebApp.AdminPanel.KategoriListeleListView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Kategori Listesi</h2>
        <hr style="margin:20px 0px"/>
        <asp:ListView ID="lv_kategoriler" runat="server">
            <LayoutTemplate>
                <table class="formTable" cellspacing="0" cellpadding="0">
                    <tr>
                        <th>No</th>
                        <th>Isim</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td>
                        <a href="" class="btn_duzenle">Düzenle</a>
                        <a href="" class="btn_sil">Sil</a>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                 <tr class="alternate">
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td>
                        <a href="" class="btn_duzenle">Düzenle</a>
                        <a href="" class="btn_sil">Sil</a>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
