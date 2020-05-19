<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswarinomenu.Master"  AutoEventWireup="true" CodeBehind="CustRegistration.aspx.cs" Inherits="Siddeswari.CustRegistration" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="container-fluid welcome-content">
  <div class="container">
    <p class=" text-center"><asp:Label ID="lblmsg"  Visible="false" class="text-center font-weight-bold padding-left-300" runat="server" Text=""></asp:Label></p>
    <h5 style="font:bold"><a style="color:red">*</a> Indicates field is mandatory</h5>
    <h3 class="text-center">Customer Registration</h3>
    <p class=" text-center">Register with us, We'll never share your details with anyone else.</p>
    <div class="row align-items-center justify-content-center">
      <div class="col-md-10">
        <div class="card">
          <div class="card-body">
            <form>
              <div class="row">
                <div class="col-md-6">
                  <div class="form-group">
                   <label for="FirstName">First Name</label><a style="color:red">*</a>
                   <asp:TextBox ID="TxtFirstName" class="form-control" placeholder="First Name" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="TxtFirstNamVld" Display="Dynamic" runat="server" ControlToValidate="TxtFirstName" ForeColor="Red" ValidationGroup="Regvldgrp" ErrorMessage="Please Enter First Name"></asp:RequiredFieldValidator>
                    <%--<input type="text" class="form-control" id="FirstName" placeholder="First Name">--%>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="LastName">Last Name</label><a style="color:red">*</a>
                    <asp:TextBox ID="TxtLastName" class="form-control" placeholder="Last Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="TxtLastvld" runat="server" Display="Dynamic" ControlToValidate="TxtLastName" ValidationGroup="Regvldgrp" ForeColor="Red" ErrorMessage="Please Enter Last Name"></asp:RequiredFieldValidator>
                    <%--<input type="text" class="form-control" id="LastName" placeholder="Last Name">--%>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="EmailID">Email ID</label><a style="color:red">*</a>
                    <%--<input type="email" class="form-control" id="EmailID" placeholder="Email ID">--%>
                    <asp:TextBox ID="TxtEmail" type="Email" class="form-control" placeholder="Email ID" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Emailvld" runat="server" Display="Dynamic" ControlToValidate="TxtEmail" ValidationGroup="Regvldgrp" ForeColor="Red" ErrorMessage="Please Enter Email ID"></asp:RequiredFieldValidator>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Phone Number</label><a style="color:red">*</a>
                    <div class="input-group">
                      <%--<input type="number" aria-label="Code" class="form-control" placeholder="Code">--%>
                        <asp:DropDownList ID="Drpcode" class="form-control w-25" runat="server"></asp:DropDownList>
                     <%-- <asp:DropDownList ID="TelCntrCod" Width="100"class="form-control" placeholder="Code"  runat="server"></asp:DropDownList> --%>
                      
                      <%--<input type="number" aria-label="Phone number" class="form-control w-50" placeholder="Phone Number">--%>
                      
                      <asp:TextBox ID="TxtTelnumb" type ="number"   class="form-control w-50" placeholder="Phone Number" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="CnrtycdVld" runat="server" Display="Dynamic" ControlToValidate="Drpcode" ValidationGroup="Regvldgrp" ForeColor="Red" ErrorMessage="Please enter country code"></asp:RequiredFieldValidator>
                      <asp:RequiredFieldValidator ID="Telvld" runat="server" Display="Dynamic" ControlToValidate="TxtTelnumb" ValidationGroup="Regvldgrp" ForeColor="Red" ErrorMessage="Please enter mobile number"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="BuildingNumber">Building Number</label>
                    <%--<input type="text" class="form-control" id="BuildingNumber" placeholder="Building Number"> --%>
                    <asp:TextBox ID="TxtBldgNum" type ="number" class="form-control" placeholder="Building Number" runat="server"></asp:TextBox> 
                    
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Street1">Street 1</label><a style="color:red">*</a>
                    <%--<input type="text" class="form-control" id="Street1" placeholder="Street 1">--%>
                    <asp:TextBox ID="Txtstreet" class="form-control" placeholder="Street 1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="StrtVld" runat="server" Display="Dynamic" ControlToValidate="Txtstreet" ForeColor="Red" ValidationGroup="Regvldgrp" ErrorMessage="Please enter street details"></asp:RequiredFieldValidator>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Street2">Street 2</label>
                    <%--<input type="text" class="form-control" id="Street2" placeholder="Street 2">--%>
                   <asp:TextBox ID="Txtstreet2" class="form-control" placeholder="Street 2" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="City">City</label><a style="color:red">*</a>
                    <%--<input type="text" class="form-control" id="City" placeholder="City">--%>
                    <asp:TextBox ID="Txtcity" class="form-control" placeholder="City Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Citvld" runat="server" Display="Dynamic" ControlToValidate="Txtcity" ForeColor="Red" ValidationGroup="Regvldgrp" ErrorMessage="Please enter city name"></asp:RequiredFieldValidator>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="State">State</label><a style="color:red">*</a>
                    <%--<input type="text" class="form-control" id="State" placeholder="State">--%>
                    <asp:TextBox ID="Txtstate" class="form-control" placeholder="State Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Statvld" runat="server" Display="Dynamic" ControlToValidate="Txtstate" ForeColor="Red" ValidationGroup="Regvldgrp" ErrorMessage="Please enter state name"></asp:RequiredFieldValidator>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Zip">Zip code</label><a style="color:red">*</a>
                    <%--<input type="text" class="form-control" id="Zip" placeholder="Zip code">--%>
                    <asp:TextBox ID="TxtZipcode" class="form-control" placeholder="Zip Code" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Rqzipvld" runat="server" Display="Dynamic" ControlToValidate="TxtZipcode" ForeColor="Red" ValidationGroup="Regvldgrp" ErrorMessage="Please enter zip code"></asp:RequiredFieldValidator>
                  </div>
                </div>
				<div class="col-md-6">
                  <div class="form-group">
                    <label for="Country">Country</label><a style="color:red">*</a>
                    <%--<input type="text" class="form-control" id="Country" placeholder="Country">--%>
                    <asp:DropDownList ID="CntryName" class="form-control" placeholder="Country" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="Rqdvld" runat="server" InitialValue="Select Country Name" Display="Dynamic" ControlToValidate="CntryName" ForeColor="Red" ValidationGroup="Regvldgrp" ErrorMessage="Please Enter Country Name"></asp:RequiredFieldValidator>
                  </div>
                </div>
              </div>
            </form>
          </div>
          <div class="card-footer text-center">
            <%--<button type="submit" class="btn btn-lg btn-success">Register</button>--%>
            <asp:Button ID="Btnsubmit" class="btn btn-lg btn-success" CausesValidation="true" ValidationGroup="Regvldgrp" runat="server" Text="Register" OnClick="Btnsubmit_Click" />
            <asp:Button ID="BtnCancel" class="btn btn-light btn-lg" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
            <%--<a href="#" class="btn btn-light btn-lg">Cancel</a> </div>--%>
        </div>
      </div>
    </div>
  </div>
</div>
</div>

    </body>
</asp:Content>
