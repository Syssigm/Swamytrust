<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswari.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Siddeswari.AboutUs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
 <div class="slider">
  <div class="slide-inner">
  	<h2>About Us</h2>
   </div>
  </div>
<div class="container-fluid welcome-content">
  <div class="container">
   <div class="row">
      <div class="col-lg-8 col-md-8 col-sm-6 col-xs-12">
  <h3>SRI SIDDHESWARI SEVA INC., USA</h3>
	  <p class="lead align-content-lg-start"> <asp:Label ID="lblSevincS1" runat="server" Text=""></asp:Label><br /><br />
          <asp:Label ID="lblSevincS2" runat="server" Text=""></asp:Label>
          
	  </p> 
<h4 class="alert alert-warning text-center mt-4">HONORARY  CHAIRMAN OF THE BOARD</h4>
  <p class="lead"><asp:Label ID="Lblchairmn" runat="server" Text=""></asp:Label></p>
	 </div>
	 <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
	 <img src="images/Swamiji.jpg" class="img-responsive img-thumbnail" />
	 </div>
	 </div>

  </div>
</div>


<div class="container-fluid learnmore-section">
  <div class="container">
	<h3 class="border-bottom border-dark mb-4 pb-2">Volunteers</h3>
       <div class="row">
	 <div class="col-md-4 col-sm-6 col-xs-12">
		<h5><asp:Label ID="lblvolnam1" runat="server" Text=""></asp:Label></h5>
		<p class="lead"><asp:Label ID="lblvoladdr1" runat="server" Text=""></asp:Label> <br />
            <asp:Label ID="lblvoladdr12" runat="server" Text=""></asp:Label>
		</p>
	 </div>
	 <div class="col-md-4 col-sm-6 col-xs-12">
		<h5><asp:Label ID="lblvolnam2" runat="server" Text=""></asp:Label></h5>
		<p class="lead"><asp:Label ID="lbladdr2" runat="server" Text=""></asp:Label> <br />
E-mail: <a class="text-light" href="mailto:bhushan@srisiddheswariseva.org">bhushan@srisiddheswariseva.org</a></p>
	 </div>
	 <div class="col-md-4 col-sm-6 col-xs-12">
	 	<div class="p-3 border border-warning">
		<h5 class="text-warning">For Purchase of Publications</h5>
		<p class="lead m-0">Sashibhushan Mocherla<br>
E-mail: <a class="text-light" href="mailto:bhushan@srisiddheswariseva.org">bhushan@srisiddheswariseva.org</a></p>
	 </div>
      </div>
	  
	 </div>

	
  </div>
</div>

    </body>
</asp:Content>
