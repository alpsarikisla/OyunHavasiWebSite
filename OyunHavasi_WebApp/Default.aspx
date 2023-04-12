<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OyunHavasi_WebApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lv_makaleler" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="makale">
                <div class="resim">
                    <a href='MakaleDetay.aspx?makid=<%#Eval("ID") %>'> <img src='MakaleResimleri/<%#Eval("KapakResim") %>' width="100%"/></a>
                </div>
                <div class="icerik">
                    <a href='MakaleDetay.aspx?makid=<%#Eval("ID") %>'><h2><%#Eval("Baslik") %></h2></a>
                    <div class="bilgi">
                        <label>Yazar : <%#Eval("Yazar") %></label> | <label>Kategori : <%#Eval("Kategori") %></label> | <label>Görüntüleme : <%#Eval("GoruntulemeSayi") %></label>
                    </div>
                    <p>
                        <%#Eval("Ozet") %>
                    </p>
                </div>
                <div style="clear:both"></div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
