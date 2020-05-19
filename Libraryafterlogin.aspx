<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="Libraryafterlogin.aspx.cs" Inherits="Siddeswari.Libraryafterlogin" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
         <div class="slider">
  <div class="slide-inner">
    <h2>Books</h2>
  </div>
</div>
    <div class="container-fluid welcome-content">
<div class="container">
<p class="lead"><strong>Swamiji continues to share with the world the knowledge and wisdom received by him through the many siddha yogis during his divine visions.</strong></p>
        <div class="feature-blocks text-left p-0">
			<ol class="list-group">
                <asp:Repeater id="rptbook" runat="server">
                    <ItemTemplate>
				<li class="list-group-item"><%#Eval("SiddOrgSectioncontent") %></li>
                        </ItemTemplate>
				</asp:Repeater>
			</ol>
        </div>
  </div>
</div>

<div class="solutions-section">
  <div class="container text-center mb-5">
  <h3>Here are some of the books written by Poojya Swamiji</h3>
    <h3 class="mb-4"><small class="text-primary font-size-60">Use the following purchase options based on your convenience:</small></h3>

<div class="row text-center">
      <asp:Repeater id="rptbks"  runat="server">
          <ItemTemplate>
		<div class="col-lg-3">
		  <a href="AddToCart.aspx"><img src="<%#Eval("SiddOrgBookimg") %>" border="0" class="img-fluid img-thumbnail max-height-300" /></a>
		  <p class="text-center"><%#Eval("SiddOrgBookname") %> <strike> <%#Eval("SiddOrgBookprice") %> </strike> &nbsp&nbsp&nbsp&nbsp <%#Eval("SiddOrgsaleprice") %><br>
          <asp:LinkButton ID="Lnkbtn" OnClick="Lnkbtn_Click" CommandArgument= '<%#Eval("SiddOrgBookimg")+"&"+ Eval("SiddOrgBookname")+"&"+ Eval("SiddOrgsaleprice")%>' class="btn btn-sm btn-warning mb-4" runat="server">Read More</asp:LinkButton></p>
            <asp:Label ID="Lblbkimg" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="Lblbkname" runat="server" Visible="false" Text=""></asp:Label>
            <asp:Label ID="Lblbkprice" runat="server" Visible="false" Text=""></asp:Label>
		</div>
              </ItemTemplate>
          </asp:Repeater>
	</div>
	<hr />
	<p class="my-4">
	<a href="#" class="btn btn-large btn-primary text-white"><i class="fa fa-shopping-cart"></i> Click here view all Books to purchase online</a>
	</p>
	<div class="alert alert-warning">
		<p><strong>Please mail check favoring Siddheswari Seva Inc.</strong> to: Please provide name of book, mailing address and phone contact number as well.</p>
	</div>
	<div class="alert alert-info">
	<p>If you would like to purchase them please contact:</p>
		<p>Sashibhushan Mocherla,<br>
		<strong>E-mail</strong>: bhushan@srisiddheswariseva.org,<br>
		<strong>Address</strong>: 8725 Colonial Place, Duluth GA 30097.</p>
		</div>
  </div>
</div>
    </body>
</asp:Content>
