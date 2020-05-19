<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswarinomenu.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Siddeswari.ChangePassword" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body> 
<div class="container-fluid welcome-content">
  <div class="container">
  <p class=" text-center"><asp:Label ID="lblmsg"  Visible="false" class="text-center font-weight-bold padding-left-300" runat="server" Text=""></asp:Label></p>
  <h3 class=" text-center">Change Password</h3>
   <p class=" text-center">Please enter the details.</p>
    <div class="row align-items-center justify-content-center">
      <div class="col-md-5">
        <div class="card">
		<div class="card-body">
			<form>
                <div runat="server" id="Emailidn" visible="false" class="form-group">
				<label for="exampleInputPassword1">User Id</label>
				<%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                <asp:TextBox ID="Txtusrid" class="form-control" placeholder="Enter User ID" runat="server"></asp:TextBox> <br />
                <asp:LinkButton ID="Lnkusrid" class="btn btn-lg btn-success"  runat="server" OnClick="Lnkusrid_Click">Validate UserID</asp:LinkButton>
	    		  </div>
                                
			    <div runat="server" id="cnfmpass" visible="false" class="form-group">
				<label for="exampleInputPassword1">New Password</label>
				<%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                <asp:TextBox ID="Txtpassword" type="password" class="form-control" placeholder="Enter New Password" runat="server"></asp:TextBox>
	    		  </div>
                <div runat="server" id="cnfmnewpass" visible="false" class="form-group">
				<label for="exampleInputPassword2">Confirm New Password</label>
				<%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                <asp:TextBox ID="Txtcnfrmpass" type="password" class="form-control" placeholder="Confirm New Password" runat="server"></asp:TextBox>
				
			  </div>

			  <%--<button type="submit" class="btn btn-lg btn-success">Submit</button>--%>
              <asp:Button ID="Btnsub" class="btn btn-lg btn-success" Visible="false" runat="server" Text="Submit" OnClick="Btnsub_Click" />
			  
			</form>
            </div>

        </div>
      </div>
      
	  
    </div>
  </div>
</div>
        </body>
</asp:Content>
