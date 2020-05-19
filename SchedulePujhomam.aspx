<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="SchedulePujhomam.aspx.cs" Inherits="Siddeswari.SchedulePujhomam" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <body>
<div class="container-fluid welcome-content">
  <div class="container">
    
    <h3 class=" text-center">Schedule a Puja/Homam</h3>
       <p class="text-center"> <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label> </p>
    <p class=" text-center">You can enter details to Schedule a Puja/Homam here, We'll never share your details with anyone else.</p>
    <div class="row align-items-center justify-content-center">
      <div class="col-md-10">
        <div class="card">
          <div class="card-body">
            <form>
              <div class="row">
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="SelectPuja">Select Puja/Homam</label>
                      <asp:DropDownList ID="Drpmastpuj" class="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="Drpmastpuj_SelectedIndexChanged"></asp:DropDownList>
                        <%--<select class="form-control" id="SelectPuja">
						  <option>Select</option>
						  <option>Ganapathy Homam</option>
						  <option>Sri Maha Lakshmi Homam</option>
						  <option>Naga Homam</option>
						  <option>Guru Homam</option>
						</select>--%>

                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Price">Price</label>
                    <div class="input-group">
                        <asp:DropDownList ID="Drpprice" class="form-control" runat="server"></asp:DropDownList>
                      <%--<select class="form-control">
						  <option>USD</option>
						  <option>INR</option>
						  <option>GBP</option>
						</select>--%>
                      <%--<input type="number" aria-label="Price" class="form-control w-50" placeholder="Price">--%>
                        <asp:TextBox ID="Txtprice" class="form-control w-50" placeholder="Price" runat="server"></asp:TextBox>
                    </div>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="DateofPuja">Date of Puja</label>
                    <input type="date" runat="server" class="form-control" id="txtdateofpuja" placeholder="yyyy-mm-dd"/>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="LastName">Family Details</label>
                    <%--<textarea class="form-control" id="FamilyDetails" aria-multiline="true" placeholder="Family Details"></textarea>--%>
                    <asp:TextBox ID="Txtfamildet" class="form-control" TextMode="MultiLine" placeholdwer="Family Details"  runat="server"></asp:TextBox>
                  </div>
                </div>
                  <div class="col-md-6">
                  <div class="form-group">
                    <label for="Gothram">Gothram</label>
                    <%--<input type="text" class="form-control" id="FirstName" placeholder="First Name">--%>
                    <asp:TextBox ID="TxtGothram" class="form-control" placeholdwer="Gothram"  runat="server"></asp:TextBox>
                  </div>
                </div>
                  <div class="col-md-6">
                  <div class="form-group">
                    <label for="PujaLocation">Puja Location</label>
                    <%--<input type="text" class="form-control" id="FirstName" placeholder="First Name">--%>
                    <asp:TextBox ID="TxtPujloc" class="form-control" placeholdwer="Puja Location"  runat="server"></asp:TextBox>
                  </div>
                </div>
                
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="FirstName">First Name</label>
                    <%--<input type="text" class="form-control" id="FirstName" placeholder="First Name">--%>
                    <asp:TextBox ID="Txtfirstnam" class="form-control" placeholdwer="First Name"  runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="LastName">Last Name</label>
                    <%--<input type="text" class="form-control" id="LastName" placeholder="Last Name">--%>
                    <asp:TextBox ID="Txtlastnam" class="form-control" placeholdwer="Last Name"  runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="EmailID">Email ID</label>
                    <%--<input type="email" class="form-control" id="EmailID" placeholder="Email ID">--%>
                    <asp:TextBox ID="Txtemail" class="form-control" placeholder="Email ID"  runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Phone Number</label>
                    <div class="input-group">
                      <%--<input type="number" aria-label="Code" class="form-control" placeholder="Code">--%>
                      <asp:DropDownList ID="Drpcntrcode" class="form-control" runat="server"></asp:DropDownList>
                      <%--<input type="number" aria-label="Phone number" class="form-control w-50" placeholder="Phone Number">--%>
                      <asp:TextBox ID="Txtphone" type="number" class="form-control w-50" placeholder="Phone Number" runat="server"></asp:TextBox>
                    </div>
                  </div>
                </div>
                 <div class="col-md-6">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Alternate Phone Number</label>
                    <div class="input-group">
                      <%--<input type="number" aria-label="Code" class="form-control" placeholder="Code">--%>
                      <asp:DropDownList ID="Dropcntrcod" class="form-control" runat="server"></asp:DropDownList>
                      <%--<input type="number" aria-label="Phone number" class="form-control w-50" placeholder="Phone Number">--%>
                      <asp:TextBox ID="Txtalterphone" type="number" class="form-control w-50" placeholder="Alternate Phone Number" runat="server"></asp:TextBox>
                    </div>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="BuildingNumber">Building Number</label>
                    <%--<input type="text" class="form-control" id="BuildingNumber" placeholder="Building Number">--%>
                    <asp:TextBox ID="Txrbldnumb" class="form-control w-50" placeholder="Building Number" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Street1">Street 1</label>
                    <%--<input type="text" class="form-control" id="Street1" placeholder="Street 1">--%>
                    <asp:TextBox ID="Txtstrt" class="form-control" placeholder="Street 1" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                   <label for="Street2">Street 2</label>
                   <%--<input type="text" class="form-control" id="Street2" placeholder="Street 2">--%>
                   <asp:TextBox ID="Txtstrt2" class="form-control" placeholder="Street 2" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="City">City</label>
                  <%--<input type="text" class="form-control" id="City" placeholder="City">--%>
                 <asp:TextBox ID="Txtcity" class="form-control" placeholder="City" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="State">State</label>
                   <%--<input type="text" class="form-control" id="State" placeholder="State">--%>
                   <asp:TextBox ID="Txtstate" class="form-control" placeholder="State" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <label for="Zip">Zip code</label>
                    <%--<input type="text" class="form-control" id="Zip" placeholder="Zip code">--%>
                    <asp:TextBox ID="Txtzipcd" class="form-control" placeholder="Zip code" runat="server"></asp:TextBox>
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
            <%--<button type="submit" class="btn btn-lg btn-success">Schedule</button>--%>

          <%--   <asp:Button class="btn btn-lg btn-success" ID="Btnsub" runat="server" Text="Schedule" OnClick="Btnsub_Click" />
            
           <a href="#" class="btn btn-light btn-lg">Cancel</a> </div>--%>
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

            var pujaprice = $('#<%=Txtprice.ClientID%>').val().toString();
            $("[id*=lblpymtsucc]").text("Y");
            $("[id*=lnkpymtsucs]").click(updatepymtdetails);
                         
            return actions.order.create({
                purchase_units: [{
                    amount: {
                        value: pujaprice
                    }
                }]
            });
        },
        onApprove: function(data, actions) {
            return actions.order.capture().then(function (details) {
                $("[id*=lblpymtsucc]").text("Y");
                alert('Transaction Details: ' + $("[id*=Txtfirstnam]").val().toString() + " " + $("[id*=Txtlastnam]").val().toString() +"Amount: "+"USD" + $('#<%=Txtprice.ClientID%>').val().toString());
                $("[id*=lnkpymtsucs]").click(updatepymtdetails);
               
            });
        }
    }).render('#paypal-button-container');
</script>

              <asp:Button class="btn btn-secondary btn-lg" ID="Butcan" runat="server" Text="Cancel" OnClick="Butcan_Click" />

        </div>
      </div>
    </div>
  </div>
</div>
    </body>
    </div>

</asp:Content>
