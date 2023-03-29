<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="KategoriListeleGridView.aspx.cs" Inherits="OyunHavasi_WebApp.AdminPanel.KategoriListeleGridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="gv_Kategoriler" runat="server" Width="100%">
            <HeaderStyle BackColor="Yellow" />
        </asp:GridView>
    </div>
</asp:Content>
