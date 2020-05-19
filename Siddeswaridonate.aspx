<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="Siddeswaridonate.aspx.cs" Inherits="Siddeswari.Siddeswaridonate" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
  <div class="container-fluid welcome-content">
  <div class="container">
    <h3 class=" text-center">Donate For a Cause</h3>
     <p class="text-center"> <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label> </p>
    <p class=" text-center">Fill your details to donate for a cause here, We'll never share your details with anyone else.</p>
    <div class="row align-items-center justify-content-center">
      <div class="col-md-10">
        <div class="card">
          <div class="card-body">
            <form>
              <div class="row">
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="SelectPuja">Select the scheme</label>
                        <%--<select class="form-control" id="SelectPuja">
						  <option>Select</option>
						  <option>Ganapathy Homam</option>
						  <option>Sri Maha Lakshmi Homam</option>
						  <option>Naga Homam</option>
						  <option>Guru Homam</option>
						</select>--%>
                      <asp:DropDownList ID="Drppujlst" class="form-control"  runat="server"></asp:DropDownList>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Price">Currency</label>
                      <%--<select class="form-control">
						  <option>USD</option>
						  <option>INR</option>
						  <option>GBP</option>
						</select>--%>
                      <asp:DropDownList ID="Drpcurrency" class="form-control"  runat="server"></asp:DropDownList>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="DateofPuja">Donation Amount</label>
                    <%--<input type="number" class="form-control" id="Donation-Amount" placeholder="Donation Amount">--%>
                    <asp:TextBox ID="Txtdonamt" type="number" class="form-control" placeholder="Donation Amount" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="EmailID">Email ID</label>
                    <%--<input type="email" class="form-control" id="EmailID" placeholder="Email ID">--%>
                    <asp:TextBox ID="TxtemailID" class="form-control" placeholder="Email ID" runat="server"></asp:TextBox>
                  </div>
                </div>

                <div class="col-md-6">
                  <div class="form-group">
                    <label for="FirstName">First Name</label>
                    <%--<input type="text" class="form-control" id="FirstName" placeholder="First Name">--%>
                    <asp:TextBox ID="Txtfirstname" class="form-control" placeholder="First Name" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="LastName">Last Name</label>
                    <%--<input type="text" class="form-control" id="LastName" placeholder="Last Name">--%>
                    <asp:TextBox ID="Txtlastname" class="form-control" placeholder="Last Name" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Phone Number</label>
                    <div class="input-group">
                      <asp:DropDownList ID="Drpcntcode" class="form-control" runat="server"></asp:DropDownList>
                      <%--<input type="number" aria-label="Code" class="form-control" placeholder="Code">--%>
                      <%--<input type="number" aria-label="Phone number" class="form-control w-50" placeholder="Phone Number">--%>
                      <asp:TextBox ID="Txtphone" placeholder="Phone number" class="form-control w-50" runat="server"></asp:TextBox>
                    </div>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="BuildingNumber">Building Number</label>
                    <%--<input type="text" class="form-control" id="BuildingNumber" placeholder="Building Number">--%>
                   <asp:TextBox ID="Txtbuild" placeholder="Building Number" class="form-control" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Street1">Street 1</label>
                    <%--<input type="text" class="form-control" id="Street1" placeholder="Street 1">--%>
                    <asp:TextBox ID="Txtstreet" placeholder="Street 1" class="form-control" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Street2">Street 2</label>
                    <%--<input type="text" class="form-control" id="Street2" placeholder="Street 2">--%>
                    <asp:TextBox ID="Txtstreet2" placeholder="Street 2" class="form-control" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="City">City</label>
                    <%--<input type="text" class="form-control" id="City" placeholder="City">--%>
                   <asp:TextBox ID="Txtcity" placeholder="City" class="form-control" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="State">State</label>
                    <%--<input type="text" class="form-control" id="State" placeholder="State">--%>
                    <asp:TextBox ID="Txtstate" placeholder="State" class="form-control" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Zip">Zip code</label>
                    <%--<input type="text" class="form-control" id="Zip" placeholder="Zip code">--%>
                    <asp:TextBox ID="Txtzip" placeholder="Zip code" class="form-control" runat="server"></asp:TextBox>
                  </div>
                </div>
				<div class="col-md-6">
                  <div class="form-group">
                    <label for="Country">Country</label>
                    <%--<input type="text" class="form-control" id="Country" placeholder="Country">--%>
                    <asp:DropDownList ID="Drpcntry" class="form-control" runat="server"></asp:DropDownList>
                  </div>
                </div>
              </div>
            </form>
          </div>
          <div class="card-footer text-center">
           <%-- <button type="submit" class="btn btn-lg btn-success">Donate</button>--%>
           <%--<asp:Button ID="Btnsub" class="btn btn-lg btn-success" runat="server" Text="Donate" OnClick="Btnsub_Click" />--%>
              <asp:Label ID="lblpymtsucc" Visible="false" runat="server" Text=""></asp:Label>
              <asp:LinkButton id="lnkpymtsucs" Visible="false" runat="server" OnClientClick="updatepymtdetails();"/>
<div id="paypal-button-container"></div>
<script src="https://www.paypal.com/sdk/js?client-id=AVmI_K0xAzgZC2ZogGbHQ_XAcJV_MA7sck4LMSQmWXk4hLQPzjKVX6O_l7A0ZBYXsIiOfVZB7qM0yydr&currency=USD"></script>
<script>
    paypal.Buttons({
        style: {
            shape: 'pill',
            color: 'gold',
            layout: 'horizontal',
            label: 'buynow',
            
        },
        createOrder: function (data, actions) {

            var donamt = $("[id*=Txtdonamt]").val().toString();

             $("[id*=lblpymtsucc]").text("Y");
             $("[id*=lnkpymtsucs]").click(updatepymtdetails);
          
            return actions.order.create({
                purchase_units: [{
                    amount: {
                        value: donamt
                    }
                }]
            });
        },
        onApprove: function(data, actions) {
            return actions.order.capture().then(function (details) {
                $("[id*=lblpymtsucc]").text("Y");
                alert('Transaction Details: ' + $("[id*=Txtfirstname]").val().toString() + " " + $("[id*=Txtlastname]").val().toString() +"Amount: "+"USD" + $("[id*=Txtdonamt]").val().toString());
                $("[id*=lnkpymtsucs]").click(updatepymtdetails);
                
            });
        }
    }).render('#paypal-button-container');
</script>

              <asp:Button class="btn btn-secondary btn-lg" ID="Butcan" runat="server" Text="Cancel" OnClick="Butcan_Click" />

            <%--<asp:Button ID="Btncancel" class="btn btn-light btn-lg" runat="server" Text="Cancel" OnClick="Btncancel_Click" />--%>
            <%--<a href="#" class="btn btn-light btn-lg">Cancel</a> </div>--%>

        </div>
      </div>
    </div>
  </div>
</div>
 
    </div>
        </body>
</asp:Content>
