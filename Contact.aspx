<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswari.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Siddeswari.Contact" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
  <div class="slider">
  <div class="slide-inner">
    <h2>Contact Us</h2>
      <p class="text-center"> <asp:Label ID="Lblmesg" runat="server" Text=""></asp:Label></p>
  </div>
</div>
<div class="container-fluid welcome-content">
<div class="container">
<form class="form-horizontal" method="post" id="contact-form">
	  
	<div runat="server" class="row justify-content-around">

        <div runat="server" class="col-md-5">
		<h4><strong>Write To Us:</strong> </h4>
          <%--<asp:TextBox ID="Txtfullname" type="text" placeholder="Full Name" class="form-control margin-bottom-20" runat="server"></asp:TextBox>--%>
          <asp:TextBox ID="Txtname" placeholder="Full Name" class="form-control margin-bottom-20" runat="server"></asp:TextBox>
          <asp:TextBox ID="TxtSubject" type="text" placeholder="Subject Line" class="form-control margin-bottom-20" runat="server"></asp:TextBox>
          <asp:TextBox ID="Txtphone" type="text" placeholder="Phone Number" class="form-control margin-bottom-20" runat="server"></asp:TextBox>
          <asp:TextBox ID="Txtmail" type="text" placeholder="Email Address" class="form-control margin-bottom-20" runat="server"></asp:TextBox>
          <asp:TextBox ID="Txtmessage" type="text" placeholder="Enter your massage for us here. We will get back to you ASAP" TextMode="MultiLine" class="form-control margin-bottom-20" runat="server"></asp:TextBox>

      <div class="form-actions text-center margin-top-bottom-20">
          <%--<button type="submit" class="btn btn-lg btn-success" name="mig_contact" value="Sign Up">Submit</button>--%>
          <asp:Button ID="Btnsub" class="btn btn-lg btn-success"  runat="server" Text="Submit" OnClick="Btnsub_Click" />
          <%--<button type="reset" class="btn btn-lg btn-default margin-left-20" name="mig_contact" value="Reset">Reset</button>--%>
          <asp:Button ID="Btnreset" class="btn btn-lg btn-default margin-left-20"  runat="server" Text="Reset" OnClick="Btnreset_Click" />
      </div>
        </div>

 <div class="col-md-6 text-left brandcolor1">
				        <h4><strong>Sri Siddheswari Seva Inc., USA:
</strong> </h4>
<div><iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3304.717187638947!2d-84.13997198478435!3d34.07676338059917!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x88f599a3da4f76f7%3A0x8984fe1a53de0313!2s8725%20Colonial%20Pl%2C%20Duluth%2C%20GA%2030097%2C%20USA!5e0!3m2!1sen!2sin!4v1567517850703!5m2!1sen!2sin" width="100%" height="390" frameborder="0" style="border:0;" allowfullscreen=""></iframe></div>

</div>

      </div>
    </form>

  </div>
</div>
        <div class="container-fluid learnmore-section">
  <div class="container">
	<h3 class="border-bottom border-dark mb-4 pb-2">Volunteers</h3>
       <div class="row">
	 <div class="col-md-4 col-sm-6 col-xs-12">
		<h5>Anil Kumar Polisetty</h5>
		<p class="lead">1075 N Escondido Blvd , Unit 112
Escondido , CA 92026.</p>
	 </div>
	 <div class="col-md-4 col-sm-6 col-xs-12">
		<h5>Sashibhushan Mocherla</h5>
		<p class="lead">8725 Colonial Place, Duluth GA 30097.<br>
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
