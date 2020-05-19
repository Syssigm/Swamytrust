<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="Siddeswari.AddToCart" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
     <div class="container-fluid welcome-content">
	  <div class="container">
		<h3 class=" text-center mb-5">Add to Cart</h3>
		<div class="row align-items-center justify-content-center">
		  <div class="col-md-12">
			<div class="card">
			  <div class="card-body">
				<div class="shopping-cart">
				  <div class="column-labels">
					<label class="product-image">Image</label>
					<label class="product-details">Product</label>
					<label class="product-price">Price</label>
					<label class="product-quantity">Quantity</label>
					<label class="product-removal">Remove</label>
					<label class="product-line-price">Total</label>
				  </div>
                   <asp:Repeater ID="Rptbookdetails" runat="server">
                  <ItemTemplate>
				  <div class="product">
					<div class="product-image"> <img src="<%#Eval("SiddOrgimgloc") %>"> </div>
					<div class="product-details">
					  <div class="product-title"><p><%#Eval("SiddOrgItemName")%></p></div>
					  <p class="product-description"><%# Eval("SiddOrgItemDesc")%></p>
					</div>
					<div class="product-price"><%#Eval("SiddOrgItemPrice")%></div>
					<div class="product-quantity">
					  <input type="number" runat="server" id="pdqty" value="1" min="1"/>
					</div>
					<div class="product-removal">
				    <asp:LinkButton ID="BtRmpdt" class="remove-product" OnClick="BtRmpdt_Click" CommandArgument='<%#Eval("SiddOrgItemName") %>' runat="server">Remove</asp:LinkButton>
					</div>
					<div class="product-line-price"><p> <%#Eval("SiddOrgItemPrice") %></p></div>
                     
				  </div>
		          </ItemTemplate>
                  </asp:Repeater>
				  <div class="totals">
					<div class="totals-item">
					  <label>Subtotal</label>
					  <div  class="totals-value" id="cart-subtotal">
                          <asp:Label ID="Lblsubtot" runat="server" Text=""></asp:Label></div>
					</div>
					<div class="totals-item">
					  <label>Tax (5%)</label>
					  <div class="totals-value" id="cart-tax">0.00</div>
					</div>
					<div class="totals-item">
					  <label>Shipping</label>
					  <div class="totals-value" id="cart-shipping">0.00</div>
					</div>
					<div class="totals-item totals-item-total">
					  <label>Grand Total</label>
					  <div class="totals-value" id="cart-total">
                          <asp:Label ID="Lbltot" runat="server" Text=""></asp:Label></div>
					</div>
				  </div>
    <asp:Label ID="Lblcustname" Visible="false" runat="server" Text=""></asp:Label>				                     
    <asp:Label ID="lblpymtsucc" Visible="false" runat="server" Text=""></asp:Label>
    <asp:LinkButton id="lnkpymtsucs" Visible="false" runat="server" OnClientClick="updatepymtdetails()"/>


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
             
            var Bookcartvalue = $('#<%=Lbltot.ClientID%>').val().toString();
           
            return actions.order.create({
                purchase_units: [{
                    amount: {
                        value: Bookcartvalue
                    }
                }]
            });
        },
        onApprove: function(data, actions) {
            return actions.order.capture().then(function (details) {
                $("[id*=lblpymtsucc]").text("Y");
                alert('Transaction successful of : ' + $('#<%=Lblcustname.ClientID%>').val().toString() + " for Amount: "+"USD" + $('#<%=Lbltot.ClientID%>').val().toString());
                 $("[id*=lnkpymtsucs]").click(updatepymtdetails);
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
