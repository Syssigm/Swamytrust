<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswari.Master" AutoEventWireup="true" CodeBehind="Productdetailgust.aspx.cs" Inherits="Siddeswari.Productdetailgust" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="container-fluid welcome-content">
             <div class="container">
                 <div class="row align-items-center justify-content-center">
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
								<span class="fa fa-star checked" title="<"></span>
								
							</div>
						</div>
						<p class="product-description"><%#Eval("SiddOrgBookDesc") %></p>
                        <h5><asp:Label ID="lblsaleprice" runat="server" Text="<%#Eval("SiddOrgsaleprice")%>>" </asp:Label></h5>
						
              			<p class="vote"><strong><%#Eval("SiddOrgBkstck") %></strong> in stock  <i>(can be backordered)</i></p>
						<p>No. Of Items: <asp:TextBox ID="Txtnoitems" class="form-control itemsCount" Text="1" OnTextChanged="Txtnoitems_TextChanged1"  runat="server"></asp:TextBox></p>
                          </ItemTemplate>
                        </asp:Repeater>
						<div class="action">
							<%--<a href="#" class="btn btn-success btn-lg">Add to Cart</a>--%>
                            <asp:LinkButton ID="Lnkaddtocart" class="btn btn-success btn-lg" OnClick="Lnkaddtocart_Click" runat="server">Add to Cart</asp:LinkButton>
                            <asp:TextBox ID="Txtprice" Visible="false" Text="<%#Eval("SiddOrgsaleprice") %>" runat="server"></asp:TextBox>
						</div>
					</div>
				</div>
			</div>
			
			
			
          </div>

                             </div>
                         </div>
                     </div>
                 </div>
            </div>
    </body>
</asp:Content>
