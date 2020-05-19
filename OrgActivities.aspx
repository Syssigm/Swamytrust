<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswari.Master" AutoEventWireup="true" CodeBehind="OrgActivities.aspx.cs" Inherits="Siddeswari.OrgActivities" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
  <div class="slider">
  <div class="slide-inner">
    <h2>Organization Activities</h2>
  </div>
</div>
  <div class="container-fluid welcome-content">
  <div class="container">
    <div class="row">
      <div class="col-sm-9">
		<h3>IN USA</h3>
        <div class="feature-blocks text-left p-0">
			<ol class="list-group">
                <asp:Repeater ID="Rptusa" runat="server">
                    <ItemTemplate>
                   <li class="list-group-item"><%# Eval("SiddOrgSectioncontent") %></li>
                    </ItemTemplate>
                </asp:Repeater>
				
				<%--<li class="list-group-item">Yoga, Meditation, and Dhyan center.</li>
				<li class="list-group-item">Religious Activities: Performing Prayers, Pujas, and Homas.</li>
				<li class="list-group-item">Dharma Rakshana Yagnams, Vishwa Shanti Practices (Spiritual practices to foster world peace) Ð group chanting of esoteric scriptures, havans for peace etc.</li>
				<li class="list-group-item">Establishing regional resource centers, and support groups for benefit of practitioners in the region.</li>
				<li class="list-group-item">Publishing of reading/ study material related to spiritual practices.</li>
				<li class="list-group-item">Swamiji’s discourses, performing Dharma Rakshana Yagnas, Conduct Satsangs (which typically involves listening to or reading scriptures, reflecting on, discussing and assimilating their meaning,meditating on the source of these words, and bringing their meaning into one’s daily life)</li>
				<li class="list-group-item">Spread of mantra sadhana practice.</li>--%>
			</ol>
        </div>
      </div>
      <div class="col-sm-3">
		<h3>IN INDIA</h3>
        <div class="feature-blocks text-left p-0">
			<ol class="list-group">
                <asp:Repeater ID="RptIND" runat="server">
                    <ItemTemplate>
				<li class="list-group-item"><%# Eval("SiddOrgSectioncontent") %></li>
                         </ItemTemplate>
                </asp:Repeater>

				<%--<li class="list-group-item">Go Shala</li>
				<li class="list-group-item">Old Age Home at Courtallam</li>
				<li class="list-group-item">Sri Sailam Project</li>
				<li class="list-group-item">Dharama Rakshana Yagnas</li>
				<li class="list-group-item">Prayojana Homas</li>--%>
			</ol>
        </div>
      </div>
    </div>
  </div>
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
    </body>
</asp:Content>
