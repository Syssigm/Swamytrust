<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="Ourspiritualguru.aspx.cs" Inherits="Siddeswari.Ourspiritualguru" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<body>
 
<div runat="server" class="slider">
  <div class="slide-inner">
    <h2>Our Spiritual Guru</h2>
  </div>
</div>
<div class="container-fluid welcome-content">
  <div class="container">
    <div  class="row mb-3">
        <asp:Repeater id="Rptimg" runat="server">
        <ItemTemplate>
      <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12"> <a><img src="<%# Eval("SiddOrgSectioncontent") %>" border="0" class="img-fluid img-thumbnail"/> </a>
             </ItemTemplate>
     </asp:Repeater>
      </div>
      <div class="col-lg-9 col-md-8 col-sm-6 col-xs-12">
        <p class="align-content-center"> <asp:Label ID="lblsecttwo" runat="server" Text=""></asp:Label>  </p> 
      </div>
      <p class="align-content-center"> <asp:Label ID="Lblsectthree" runat="server" Text=""></asp:Label>  </p> 
      <p class="align-content-center"> <asp:Label ID="Lblsectfour" runat="server" Text=""></asp:Label>  </p> 
    </div>
    
  </div>
</div>

<div class="container-fluid learnmore-section">
  <div class="container">
    <div class="row align-items-center">
      <div class="col-md-9 col-sm-6 col-xs-12">
        <div class="py-3">
          <p class="align-content-center"> <asp:Label ID="Lblsectfive" runat="server" Text=""></asp:Label> </p>
          <p class="m-0 align-content-center"><asp:Label ID="Lblsix" runat="server" Text=""></asp:Label> </p>
        </div>
      </div>
        <asp:Repeater id="Rptimgtwo" runat="server">
        <ItemTemplate>
      <div class="col-md-3 col-sm-6 col-xs-12"> <img src="<%# Eval("SiddOrgSectioncontent") %>" class="img-fluid" /> </div>
             </ItemTemplate>
     </asp:Repeater>
    </div>
  </div>
</div>

    </body>
</asp:Content>
