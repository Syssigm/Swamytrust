﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswari.Master" AutoEventWireup="true" CodeBehind="SwamijiIndiaIternary.aspx.cs" Inherits="Siddeswari.SwamijiIndiaIternary" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <body>
  <div class="slider">
  <div class="slide-inner">
    <h2>Poojya Swamiji's Travel Itinerary</h2>
  </div>
</div>
 <div class="container-fluid welcome-content">
    <div class="container">
        <div class="card-body">
            <div class="row align-items-center justify-content-center">
        <div class="col-lg-2 text-right"> <h6>Select Year: </h6></div>
        <div class="col-lg-3"><asp:DropDownList ID="Drpyr" runat="server" CssClass="form-control d-inline-block" OnSelectedIndexChanged="Drpyr_SelectedIndexChanged"></asp:DropDownList></div>
        <div class="col-lg-2 text-right"><h6>Select Period: </h6></div>
        <div class="col-lg-3"><asp:DropDownList ID="Drpperiod" runat="server" CssClass="form-control d-inline-block" OnSelectedIndexChanged="Drpperiod_SelectedIndexChanged"/></div>
    </div>

        </div>

    <div runat="server" class="row">
      <div class="col-sm-12">
		<h3>India Schedule</h3>
          
        <div runat="server" class="feature-blocks text-left p-0">
            
			<ol class="list-group">
                <asp:Repeater ID="rptevntdtl" runat="server"> 
                    <ItemTemplate>
				<li runat="server" class="list-group-item  text-left">
                    <h4> <%# Eval("SiddOrgEventName") %></h4> 
                    <p><strong></strong> <%#Eval("SiddOrgPeriodStdate") %> to <%#Eval("SiddOrgPeriodEnddate") %> </p>
                    <h6>Schedule Details</h6>
                    <%--<asp:Label ID="lblevntdtl" runat="server" Text='<%#Eval("SiddOrgEventDetails").ToString().Split(Convert.ToChar("*"))[0]%>'/> --%>
                    <p><%#Eval("SiddOrgEventDetails") %></p>
				</li>
	      	  </ItemTemplate></asp:Repeater>
                   
			</ol>
                        
        </div>
                      
      </div>
      
      <%--<div class="col-sm-5">
		<h3>Swamiji Pooja's</h3>
        <div class="feature-blocks text-left p-0">
			<ol class="list-group">
				<li class="list-group-item">We will update soon</li>
				<li class="list-group-item"></li>
				<li class="list-group-item"></li>
				<li class="list-group-item"></li>
			</ol>
        </div>
      </div>--%>

    </div>
  </div>
</div>
          </body>
</asp:Content>
