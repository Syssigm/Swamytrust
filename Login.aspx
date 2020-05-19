<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswarinomenu.Master" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="Siddeswari.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <body> 
<div class="container-fluid welcome-content">
  <div class="container">
   <p class=" text-center"><asp:Label ID="lblmsg" class="text-center font-weight-bold padding-left-300" runat="server" Text=""></asp:Label></p>
  <h3 class=" text-center">Login Page</h3>
  <p class=" text-center">Enter your login details to Schedule Puja or Donate/Sponsor for a Scheme or Buy Books Online.</p>
    <div class="row align-items-center justify-content-center">
      <div class="col-md-5">
        <div class="card">
		<div class="card-body">
			<form>
			  <div class="form-group">
				<label for="exampleInputEmail1">Email address</label>
				<%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">--%>
                  <asp:TextBox ID="Txtemail" class="form-control" AutoCompleteType="Email" placeholder="Enter email" runat="server"></asp:TextBox>
			      <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
			  </div>
			  <div class="form-group">
				<label for="exampleInputPassword1">Password</label>
				<%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                <asp:TextBox ID="Txtpassword" type="password" class="form-control" placeholder="Enter email" runat="server"></asp:TextBox>
				<label class="mt-2"><a href="ChangePassword.aspx">Forgot Password?</a></label>
			  </div>
			  <%--<button type="submit" class="btn btn-lg btn-success">Submit</button>--%>
              <asp:Button ID="Btnsub" class="btn btn-lg btn-success" runat="server" Text="Login" OnClick="Btnsub_Click" />
			  <div class="mt-3"> If you are not registered, click now to <a href="CustRegistration.aspx" class="btn btn-light btn-link">Register Here</a></div>
			</form>
            </div>

        </div>
      </div>
      
	  
    </div>
  </div>
</div>
        </body>
    </asp:Content>

