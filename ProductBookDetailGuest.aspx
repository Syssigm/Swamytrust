<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswari.Master" AutoEventWireup="True" Inherits="Siddeswari.ProductBookDetailGuest" Codebehind="ProductBookDetailGuest.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
  <div class="container-fluid welcome-content">
  <div class="container">
<!--    <h3 class=" text-center mb-5">Checkout</h3>
-->   <div class="row align-items-center justify-content-center">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="card-title m-0">Product Details</h5>
          </div>
            
          <div class="card-body">
 			<div class="container-fliud">
				<div class="wrapper row">
					
					<div class="preview col-md-6">
						<asp:Repeater ID="prodbkdtl" runat="server">
                            <ItemTemplate>
						<div class="tab-content">
						  <div class="tab-pane active" id="pic-1"><img src="<%#Eval("SiddOrgBookimg") %>" /></div>
						  </div>
						
						
					</div>
					<div class="details col-md-6">
              		<h3 class="product-title"><%#Eval("SiddOrgBookname") %></h3>
						<div class="rating">
							<div class="stars">
								<span>  <img src="<%#Eval("SiddOrgbkrating") %>" />></span>
								
							</div>
						</div>
						<p class="product-description"><%#Eval("SiddOrgBookDesc") %></p>
						<h4 class="price">price: <%#Eval("SiddOrgsaleprice") %></h4>
                            
              			<p class="vote"><strong><%#Eval("SiddOrgBkstck") %></strong> in stock  <i>(can be backordered)</i></p>
						
                          </ItemTemplate>
                        </asp:Repeater>
                        <p>No. Of Items:<asp:TextBox ID="Txtnoitems"  Text="1"  runat="server"></asp:TextBox></p>
						<div class="action">
							<%--<a href="#" class="btn btn-success btn-lg">Add to Cart</a>--%>
                           
                            <asp:LinkButton ID="Lnkaddtocart" class="btn btn-success btn-lg" OnClick="Lnkaddtocart_Click" runat="server">Add to Cart</asp:LinkButton>
                            <asp:TextBox ID="Txtprice" Visible="false" Text='<%#Eval("SiddOrgsaleprice") %>' runat="server" xmlns:asp="#unknown"></asp:TextBox>
						</div>
					</div>
				</div>
			</div>
			
			
			
          </div>

			<div class="card-body">
			
				
			</div>

        </div>
      </div>
    </div>
  </div>
</div>
    </body>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script> 
    <script type="text/javascript" src="modernizr.js"> </script>
   
    <script>

        $('#Txtnoitems').change(function () {

             alert('test');
        var itmval = $("[id*=Txtnoitems]").val().toString;
        var itmprice = $("[id*=Txtprice]").val().toString;
        var totitmval = (parseInt(itmval) * parseInt(itmprice));
        var rvsditmprice = totitmval.toString();

        $("[id*=saleprice]").val(rvsditmprice);


        }

        $("[id*=Txtnoitems]").change(function () {

             alert('test');
        var itmval = $("[id*=Txtnoitems]").val().toString;
        var itmprice = $("[id*=Txtprice]").val().toString;
        var totitmval = (parseInt(itmval) * parseInt(itmprice));
        var rvsditmprice = totitmval.toString();

        $("[id*=salprice]").val(rvsditmprice);

        }
    
    </script>
</asp:Content>
