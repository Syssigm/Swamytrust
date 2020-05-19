<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswari.Master" AutoEventWireup="true" CodeBehind="SiddeswariHome.aspx.cs" Inherits="Siddeswari.SiddeswariHome" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="slider" runat="server">
    
<div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
  <div class="carousel-inner">
  <asp:Repeater id="Rptcarousel" runat="server">
        <ItemTemplate>
  
    <div class="carousel-item <%# (Container.ItemIndex == 0 ? "active" : "") %>">
    <img class="d-block w-100" src="<%# Eval("SiddOrgSectioncontent") %>" alt="First slide">
    </div>
     </ItemTemplate>
     </asp:Repeater>
     </div>
 
     
    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
    
    </div>
</div>
    
<div class="three-banner-blocks">
    <div class="banner-below-block b-right text-center">
      <h2 class="pt-3">SRI SIDDHESWARI SEVA INC.</h2>
      <p class="container text-center"><asp:Label ID="Lblsectone" runat="server" ></asp:Label>
</p>
<p>
<asp:Button ID="BtnSchdPuja" class="btn btn-warning mb-2" runat="server" Text="Schedule Pooja/Homa" OnClick="BtnSchdPuja_Click" />
</p>
  </div>
</div>
 <div class="container-fluid welcome-content">
  <div class="container text-center">
  <h3>Our Mission</h3>
  <p class="container text-center"><asp:Label ID="Lblmission" runat="server"></asp:Label>&nbsp&nbsp&nbsp
  <p class="container text-center"><asp:Label ID="Lblmissionone" runat="server"></asp:Label>
</p>
    <div class="row">
      <div class="col-sm-4 col-xs-12">
        <div class="feature-blocks">
		<h4 class="mt-0">SWAMIJI USA SCHEDULE</h4>

        <%--<a href="#"><img src="images/Naaga_Yagnam_Flyer-05June2019.jpg" alt="..." border="0" class="d-block w-100"></a>--%>
        <asp:Label ID="Lblevntnam" CssClass="mt-0" runat="server" Text="Event Name:"></asp:Label>
        <asp:Label ID="Lblevntval" CssClass="mt-0" runat="server" Text=""></asp:Label> <br/>
        <asp:Label ID="LblPlace" CssClass="mt-0" runat="server" Text="Place of Event:"></asp:Label>
        <asp:Label ID="LblPlaceval" CssClass="mt-0" runat="server" Text=""></asp:Label> <br />
        <asp:Label ID="Lblyear" CssClass="mt-0" runat="server" Text="Year:"></asp:Label>
        <asp:Label ID="Lblyearval" CssClass="mt-0" runat="server" Text=""></asp:Label>  <br />
        <asp:Label ID="LblPdstrdt" CssClass="mt-0" runat="server" Text="Period Start Date:"></asp:Label>
        <asp:Label ID="LblPdstrdtval" CssClass="mt-0" runat="server" Text=""></asp:Label> <br />
        <asp:Label ID="LblPdtenddt" CssClass="mt-0" runat="server" Text="Period End Date:"></asp:Label>
        <asp:Label ID="LblPdtenddtval" CssClass="mt-0" runat="server" Text=""></asp:Label> <br />
        <div class="text-center mt-2">
            <asp:Button ID="BtnSchd" class="btn btn-sm btn-warning" runat="server" Text="Complete USA Details" OnClick="BtnSchd_Click" /></div> <br /> <br /><br />
        <h4 class="mt-0">SWAMIJI INDIA SCHEDULE</h4>
        <asp:Label ID="LblIndEvn" CssClass="mt-0" runat="server" Text="Event Name:"></asp:Label>
        <asp:Label ID="LblIndEvnval" CssClass="mt-0" runat="server" Text=""></asp:Label> <br/>
        <asp:Label ID="LblIndpl" CssClass="mt-0" runat="server" Text="Place of Event:"></asp:Label>
        <asp:Label ID="LblIndplval" CssClass="mt-0" runat="server" Text=""></asp:Label> <br />
        <asp:Label ID="LblIndYr" CssClass="mt-0" runat="server" Text="Year:"></asp:Label>
        <asp:Label ID="LblIndYrvl" CssClass="mt-0" runat="server" Text=""></asp:Label>  <br />
        <asp:Label ID="LblIndPdSt" CssClass="mt-0" runat="server" Text="Period Start Date:"></asp:Label>
        <asp:Label ID="LblIndPdStval" CssClass="mt-0" runat="server" Text=""></asp:Label> <br />
        <asp:Label ID="LblIndPdEnd" CssClass="mt-0" runat="server" Text="Period End Date:"></asp:Label>
        <asp:Label ID="LblIndPdEndval" CssClass="mt-0" runat="server" Text=""></asp:Label> <br />
        
        
        
        <%--<asp:Label ID="Lblevtdt" CssClass="mt-0" runat="server" Text="Event Details:"></asp:Label> 
        <p class="align-content-center"><asp:Label ID="Lblevntdetl" CssClass="mt-0" runat="server" Text=""></asp:Label> </p>    --%>

<div class="text-center mt-2"><asp:Button ID="BtnInd" class="btn btn-sm btn-warning" runat="server" Text="Complete India Details" OnClick="BtnInd_Click" /></div>

        </div>
      </div>
      <div class="col-sm-8 col-xs-12">
        <div class="feature-blocks">
		<img src="images/swamy5_28.png" class="max-height-200" alt="12a" />
		<h4>WELCOME</h4>
		<p class="container text-center"><asp:Label ID="Lblwelcome" runat="server"/></p>
		<h4>PRESENT SWAMIJI</h4>
        <p class="container text-center"><asp:Label ID="Lblpresentswamiji" runat="server"/></p>
        </div>
      </div>
    </div>
  </div>
</div>
<div class="learnmore-section">
<div class="container">
<div class="row">
      <div class="col-lg-4">
<h3>Video Gallery -<asp:Button ID="BtnVdgal" Class="btn btn-sm btn-light" runat="server" Text="Click here for more" OnClick="BtnVdgal_Click1" /> <%--<button class="btn btn-sm btn-light">Click here for more</button>--%> </h3>

 
<div class="text-center">
    <asp:Repeater id="Rptvideohome" runat="server">
 <ItemTemplate>
    <%--<a href="#"><img src="<%#Eval("SiddOrgVideoPath") %>" border="0" class="img-fluid" /></a>--%>
     <iframe width="347" height="195" src='<%#Eval("SiddOrgVideoPath") %>' frameborder="1" allowfullscreen style="border-radius: 5px; margin: 0 10px;"></iframe>
	<hr /> 
      </ItemTemplate>
  </asp:Repeater>
</div>


<hr class="d-block d-lg-none border-warning" />
</div>

      <div class="col-lg-6 offset-lg-1">
<h3>Books by Swamiji - <asp:LinkButton ID="Btnbook" Class="btn btn-sm btn-light" Text="Click here for more" OnClick="Btnbook_Click"  runat="server">Read More</asp:LinkButton> <%--<button class="btn btn-sm btn-light">Click here for more</button>--%> </h3>
	<div class="row text-center">
        <asp:Repeater id="Rptbookhome" runat="server">
        <ItemTemplate>
           
		<div class="col-lg-3">
		  <asp:LinkButton ID="lnkimg" Class="text-light" OnClick="lnkimg_Click" CommandArgument='<%# Eval("SiddOrgBookimg")+"&"+ Eval("SiddOrgBookname")+"&"+ Eval("SiddOrgsaleprice")+"&"+ Eval("SiddOrgBkstck")+"&"+Eval("SiddOrgbkrating") %>' runat="server">
              <img src="<%# Eval("SiddOrgBookimg") %>" border="0" class="img-fluid img-thumbnail" /> </asp:LinkButton>
		<p class="text-center">
            <asp:LinkButton ID="lnBtnbook" Class="text-light"  OnClick="lnBtnbook_Click" CommandArgument='<%#Eval("SiddOrgBookimg")+"&"+ Eval("SiddOrgBookname")+"&"+ Eval("SiddOrgsaleprice")+"&"+ Eval("SiddOrgBkstck")+"&"+Eval("SiddOrgbkrating") %>' runat="server">
            <%# Eval("SiddOrgBookname") %>
		                       </asp:LinkButton></p>

		</div>
            
                </ItemTemplate>
     </asp:Repeater>
		</div>
   
		<%--<div class="col-lg-3">
		  <a href="#"><img src="http://www.siddheswaripeetham.org/wp-content/uploads/2015/01/Rasaganga.png" border="0" class="img-fluid img-thumbnail" /></a>
		<p class="text-center">Rasa Ganga</p>
		</div>
		<div class="col-lg-3">
		  <a href="#"><img src="http://www.siddheswaripeetham.org/wp-content/uploads/2015/01/Vraja-Bhagavatham.png" border="0" class="img-fluid img-thumbnail" /></a>
		<p class="text-center">Vraja Bhagatham</p>
		</div>
		<div class="col-lg-3">
		  <a href="#"><img src="http://www.siddheswaripeetham.org/wp-content/uploads/2015/01/Dasamaha-Vidyalu.png" border="0" class="img-fluid img-thumbnail" /></a>
		<p class="text-center">Dasa Mahavidhyalu</p>
		</div>
		<div class="col-lg-3">
		  <a href="#"><img src="http://www.siddheswaripeetham.org/wp-content/uploads/2015/01/Prathyangira-Sadhana.png" border="0" class="img-fluid img-thumbnail" /></a>
		<p class="text-center">Pratyangira Sadhana</p>
		</div>
		<div class="col-lg-3">
		  <a href="#"><img src="http://www.siddheswaripeetham.org/wp-content/uploads/2015/01/Sri-Lalitha-Charithra.png" border="0" class="img-fluid img-thumbnail" /></a>
		<p class="text-center">History of Lalitha Devi</p>
		</div>
		<div class="col-lg-3">
		  <a href="#"><img src="http://www.siddheswaripeetham.org/wp-content/uploads/2015/01/Bhairava-Sadhana.png" border="0" class="img-fluid img-thumbnail" /></a>
		<p class="text-center">Bhairava Sadhana</p>
		</div>
		<div class="col-lg-3">
		  <a href="#"><img src="http://www.siddheswaripeetham.org/wp-content/uploads/2015/01/Naga-Sadhana.png" border="0" class="img-fluid img-thumbnail" /></a>
		<p class="text-center">Naga  Sadhana</p>
		</div>--%>
	 </div>
    <div class="solutions-section">
  <div class="container text-center mb-5">
    <h3>Organization Activities<br/>
<small class="text-primary font-size-60">SPONSOR / DONATE TO ANY OF THE PROJECTS LISTED BELOW</small></h3>
      
    <div class="row">
        
 <asp:Repeater id="Rptdonate" runat="server" OnItemCommand="Rptdonate_ItemCommand">
        <ItemTemplate>
      <div class="col-sm-4 col-xs-12 margin-top-20"><a href="Login.aspx"> <img src="<%# Eval("SiddOrgDonschemimagepath") %>" class="img-fluid img-thumbnail center-block" />
        <h4 class="my-2"> <a href="Login.aspx"><%# Eval("SiddOrgDonschemename") %></h4>
          <asp:Button ID="Btndonate" Class="btn btn-danger" runat="server" Text="Donate Now" /><%--<button class="btn btn-danger">Donate Now</button>--%>
          
      </div>
        </ItemTemplate>
     </asp:Repeater>
      
    </div>
       
	
   
  </div>
</div>

</div>
</div>
</div>

</asp:Content>
