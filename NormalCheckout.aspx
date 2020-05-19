<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="NormalCheckout.aspx.cs" Inherits="Siddeswari.NormalCheckout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <body>
     <div class="container-fluid welcome-content">
	  <div class="container">
		<h3 class=" text-center mb-5">Check out</h3>
		<div class="row align-items-center justify-content-center">
		  <div class="col-md-12">
			<div class="card">
				<div class="card-header text-right">
					<%--<button class="btn btn-warning">Continue Shopping</button>--%>
                    <asp:LinkButton ID="LnkbtnCtnshp" class="btn btn-warning" OnClick="LnkbtnCtnshp_Click" runat="server">Continue Shopping</asp:LinkButton>
					</div>
			  <div class="card-body">
				<div class="shopping-cart">
				  <div class="column-labels">
					<label class="product-image">Image</label>
					<label class="product-details">Product</label>
					<label class="product-price">Price($)</label>
					<label class="product-quantity">Quantity</label>
					<%--<label class="product-removal">Remove</label>--%>
					<label class="product-line-price">Total</label>
					  <label class="product-removal">&nbsp;</label>
				  </div>
                   <asp:Repeater ID="Rptbookdetails" runat="server">
                  <ItemTemplate>
				  <div class="product">
					
                     
					<div class="product-image"> <img src="<%#Eval("SiddOrgBookimg") %>"> </div>
					<div class="product-details">
					  <div class="product-title"><p><%#Eval("SiddOrgBookname")%></p></div>
					  <p class="product-description"><%# Eval("SiddOrgBookDesc")%></p>
					</div>
					<div class="product-price"><%#Eval("SiddOrgsaleprice")%></div>
					
					 <%-- <input type="number" runat="server" id="pdqty" value="1" min="1"/>--%>
                    <div class="product-quantity"><p><%#Eval("bkqty") %></p></div>
					  <div class="product-line-price"><p> <%#Eval("lineitmtotprice") %></p></div>
					 <div class="product-removal text-center">
				    <asp:LinkButton ID="BtRmpdt" class="remove-product" CommandArgument='<%# Eval("SiddOrgBookname") %>' OnClick="BtRmpdt_Click"  runat="server">Remove</asp:LinkButton>
					</div>
					
					
					
				  </div>
					 
		          </ItemTemplate>
                  </asp:Repeater>
					<%--<p> Quantity:    </p>--%>
				  <div class="totals">
					<div class="totals-item">
					  <label>Subtotal($)</label>
					  <div  class="totals-value" id="cart-subtotal">
                          <asp:Label ID="Lblsubtot" runat="server" Text=""></asp:Label></div>
					</div>
					<div class="totals-item">
					  <label>Tax (0%)</label>
					  <div class="totals-value" id="cart-tax">0.00</div>
					</div>
					<div class="totals-item">
					  <label>Shipping(Flat $15)</label>
					  <div class="totals-value" id="cart-shipping">15</div>
					</div>
					<div class="totals-item totals-item-total">
					  <label>Grand Total($)</label>
					  <div class="totals-value" id="cart-total">
                          <asp:Label ID="Lbltot" runat="server" Text=""></asp:Label></div>
					</div>
				  </div>
    <asp:Label ID="Lblcustname" Visible="false" runat="server" Text=""></asp:Label>				                     
    <asp:Label ID="lblpymtsucc" Visible="false" runat="server" Text=""></asp:Label>
    <asp:LinkButton id="lnkpymtsucs" Visible="false" runat="server" />


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


            var chkamt = $("[id*=Lbltot]").val().toString();
            return actions.order.create({
                purchase_units: [{
                    amount: {

                        value: chkamt
                    }
                }]
            });
        },
        onApprove: function (data, actions) {
            return actions.order.capture().then(function (details) {
                $("[id*=lblpymtsucc]").text("Y");


            });
        }
    }).render('#paypal-button-container');
</script>
			 
				</div>
			  </div>
			</div>
		  </div>
		</div>
	  </div>
	</div>
		
    </body>
   
</asp:Content>
