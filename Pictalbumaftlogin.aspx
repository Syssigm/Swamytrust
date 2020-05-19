<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="Pictalbumaftlogin.aspx.cs" Inherits="Siddeswari.Pictalbumaftlogin" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="slider">
 <div class="slide-inner">
    <h2>Photo Gallery Albums</h2>
  </div>
</div>
  <div class="container-fluid welcome-content">
  <div class="container">
    <p class="lead mb-4"><strong>Please find the photo albums of different events:</strong> </p>
	<div class="videogallery">
    <div class="row text-center">
        <asp:Repeater id="Rptalbum" OnItemDataBound="Rptalbum_ItemDataBound" runat="server">
            <ItemTemplate>
      <div class="col-lg-4">
        <div class="card">
			<a href="#"><img src="<%#Eval("SiddOrgImagePath") %>" alt="..." border="0" class="card-img-top"></a>
      
          <div class="card-body">
            <h5 class="card-title"><%#Eval("SiddOrgImageTitle") %></h5>
              <asp:LinkButton ID="LnkAlbum" OnClick="LnkAlbum_Click" class="btn btn-primary" CommandArgument='<%#Eval("SiddOrgImageTitle")%>'  Text="View This Album" runat="server">View This Album</asp:LinkButton></div>
              <%--<a runat="server" id="albumidlnk" class="btn btn-primary"  href="GalleryPictures.aspx?id="<%#Eval("SiddOrgImageTitle") %>"">View this album</a> </div>--%>
        </div>
      </div>
            </ItemTemplate></asp:Repeater>
	  
    </div>
	</div>
  </div>
</div>
    </body>
</asp:Content>
