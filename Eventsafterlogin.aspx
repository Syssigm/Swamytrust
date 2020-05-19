<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="Eventsafterlogin.aspx.cs" Inherits="Siddeswari.Eventsafterlogin" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="slider">
  <div class="slide-inner">
    <h2>Events</h2>
  </div>
</div>
<div class="container-fluid welcome-content">
  <div class="container">
       
  <ul class="nav nav-tabs" id="myTab" role="tablist">
  <li class="nav-item">
    <a class="nav-link active" id="upcoming-tab" data-toggle="tab" href="#upcoming" role="tab" aria-controls="upcoming" aria-selected="true"><h5 class="mb-0">Upcoming Events</h5></a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="past-tab" data-toggle="tab" href="#past" role="tab" aria-controls="past" aria-selected="false"><h5 class="mb-0">Past Events</h5></a>
  </li>
</ul>
<div class="tab-content text-center mb-4" id="myTabContent">
  <div class="tab-pane fade show active" id="upcoming" role="tabpanel" aria-labelledby="upcoming-tab">
  <div class="container-fluid">
		<div class="row justify-content-around">
			<div runat="server" class="col-lg-5">
                <asp:Repeater id="rptevnts" runat="server">
                    <ItemTemplate>
				<a  href="" target="_blank"><img  src="<%#Eval("SiddOrgSectioncontent") %>" border="0" class="img-fluid img-thumbnail" /></a>
				<p><em>Click on the image to open in large size</em></p>
                </ItemTemplate></asp:Repeater>
                
				<%--<h5>Kadalee Phala Yagnam</strong></h5>
				<h6>18th MAY 2019, 9 am(Vaisakha Purnima)</h6>
				<p>Shangri-La,2786 Mitchell Road, Warrenton, GA</p>--%>
<hr>		</div>
		</div></div>
  </div>
  <div class="tab-pane fade" id="past" role="tabpanel" aria-labelledby="past-tab">
  <div class="container-fluid">
		<div class="row justify-content-around">
            <asp:Repeater id="Rptpastevnts"  runat="server">
                    <ItemTemplate>
			<div runat="server" class="col-lg-5">
                
				<a href="" target="_blank"><img src="<%# Eval("SiddOrgSectioncontent")%>" border="0" class="img-fluid img-thumbnail" /></a>
				<p><em>Click on the image to open in large size</em></p>
                        
				<%--<h5>Kadalee Phala Yagnam</strong></h5>
				<h6>18th MAY 2019, 9 am (Vaisakha Purnima)</h6>
				<p>Shangri-La,2786 Mitchell Road, Warrenton, GA</p>--%>
<hr>
				</div>
			 </ItemTemplate></asp:Repeater>
				
				
		</div>

  </div>
  
  </div>
</div>
 
		
  </div>
</div>
        <div class="solutions-section">
  <div class="container text-center mb-5">
    <h3 class="mb-4"><small class="text-primary font-size-60">For More Details About All Our Events, Please Contact</small></h3>

	<div class="alert alert-info">
		<p>Sashibhushan Mocherla,<br>
		<strong>E-mail</strong>: bhushan@srisiddheswariseva.org,<br>
		<strong>Address</strong>: 8725 Colonial Place, Duluth GA 30097.</p>
		</div>
  </div>
</div>
    </body>
</asp:Content>
