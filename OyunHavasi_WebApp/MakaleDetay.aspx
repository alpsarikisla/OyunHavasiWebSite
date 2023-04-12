<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="OyunHavasi_WebApp.MakaleDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="makaledetay">
        <div class="resim">
            <asp:Image ID="img_resim" runat="server" Width="100%" />
        </div>
        <div class="icerik">
            <h2>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal></h2>
            <div class="bilgi">
                <label>Yazar :
                    <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal></label>
                |
                <label>Kategori :<asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal></label>
                |
                <label>Görüntüleme :
                    <asp:Literal ID="ltrl_goruntuleme" runat="server"></asp:Literal></label>
            </div>
            <p>
                <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
            </p>
        </div>
        <div style="clear: both"></div>
    </div>
    <div class="yorumpanel">
        <div class="yorumPanelBaslik">
            <h3>Yorumlar</h3>
        </div>
        <div class="yorumPanelIcerik">
            <asp:Repeater ID="rp_yorumlar" runat="server">
                <ItemTemplate>
                    <div class="yorum">
                        <label><%# Eval("Uye") %></label> <label><%# Eval("EklemeTarihiStr") %></label>
                        <hr />
                        <p>
                            <%# Eval("Icerik") %>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="yorumPanelIcerik">
             <asp:Panel ID="pnl_basarili" runat="server" CssClass="pnl_basarili" Visible="false">
               Yorumunuz başarıyla eklenmiş bulunup. Admin onayından sonra yayınlanacaktır.
            </asp:Panel>
              <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="pnl_basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnl_girisvar" runat="server" Visible="false">
                <div class="row">
                    Yorum Yazınız:
                </div>
                <div class="row">
                    <asp:TextBox ID="tb_mesaj" runat="server" CssClass="formInput" style="width:98%" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_gonder" runat="server" CssClass="formButton" Style="display:initial; float:right" OnClick="lbtn_gonder_Click" >
                        Yorum Bırak
                    </asp:LinkButton>
                    <div style="clear:both"></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnl_girisYok" runat="server">
                <h3>Makaleye Yorum Yapabilmek İçin Lütfen <a href="UyeGiris.aspx">Giriş Yapınız</a></h3>
            </asp:Panel>
        </div>

    </div>
    <div style="height:200px;"></div>
</asp:Content>
