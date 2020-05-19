<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswari.Master" AutoEventWireup="true" CodeBehind="Productdetail.aspx.cs" Inherits="Siddeswari.Productdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="container-fluid welcome-content">
  <div class="container">
<!--    <h3 class=" text-center mb-5">Checkout</h3>
-->    <div class="row align-items-center justify-content-center">
      <div class="col-md-12">
        <div class="card">
          <div class="card-header">
            <h5 class="card-title m-0">Product Details</h5>
          </div>
          <div class="card-body">
            
			<div class="container-fliud">
				<div class="wrapper row">
					<div class="preview col-md-6">
						
						<div class="tab-content">
						  <div class="tab-pane active" id="pic-1"><img src="images/gallery_1.jpg" /></div>
						  <div class="tab-pane" id="pic-2"><img src="images/gallery_2.jpg" /></div>
						  <div class="tab-pane" id="pic-3"><img src="images/gallery_3.jpg" /></div>
						  <div class="tab-pane" id="pic-4"><img src="images/gallery_4.jpg" /></div>
						</div>
						<ul class="preview-thumbnail nav nav-tabs">
						  <li><a data-target="#pic-1" data-toggle="tab"><img src="images/gallery_1.jpg" /></a></li>
						  <li><a data-target="#pic-2" data-toggle="tab"><img src="images/gallery_2.jpg" /></a></li>
						  <li><a data-target="#pic-3" data-toggle="tab"><img src="images/gallery_3.jpg" /></a></li>
						  <li><a data-target="#pic-4" data-toggle="tab"><img src="images/gallery_4.jpg" /></a></li>
						</ul>
						
					</div>
					<div class="details col-md-6">
						<h3 class="product-title">Rasaganga</h3>
						<div class="rating">
							<div class="stars">
								<span class="fa fa-star checked"></span>
								<span class="fa fa-star checked"></span>
								<span class="fa fa-star checked"></span>
								<span class="fa fa-star"></span>
								<span class="fa fa-star"></span>
							</div>
						</div>
						<p class="product-description">Here are some of the books written by Sri Siddheswarananda Bharathi Swamiji and use the following purchase options based on your convenience:

</p>
						<h4 class="price">price: <span class="priceAmount">$20</span></h4>
						<p class="vote"><strong>20</strong> in stock  <i>(can be backordered)</i></p>
						<p>No. Of Items: <input type="number" value="1" class="form-control itemsCount" /></p>
						<div class="action">
							<a href="#" class="btn btn-success btn-lg">Add to Cart</a>
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
</asp:Content>
