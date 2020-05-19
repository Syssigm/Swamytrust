<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="GalleryPictAftlogin.aspx.cs" Inherits="Siddeswari.GalleryPictAftlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Sri Siddheswari Seva Charitable Trust</title>
<!-- Bootstrap Css -->
<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet">
<script src="https://kit.fontawesome.com/a076d05399.js"></script>

<!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
<![endif]-->

<link rel="stylesheet" type="text/css" href="source/jquery.fancybox.css?v=2.1.5" media="screen" />
<!-- Add Button helper (this is optional) -->
<link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />

<link rel="stylesheet" type="text/css" href="css/custom.css">
<link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=Roboto+Slab:100,300,400,700" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <div class="slider">
  <div class="slide-inner">
    <h2>Photo Gallery</h2>
  </div>
<div  class="container-fluid welcome-content">
  <div class="container">
		<p class="lead mb-5"><strong>Please find the below photos of Pooja Swamiji and different events organized earlier</strong></p>
        <div id="myCarousel" class="carousel slide">
                <!-- Wrapper for slides -->
                <div class="carousel-inner">
       <div class="row text-center">
            <asp:Repeater id="InRptpictures" runat="server">
               <ItemTemplate>
                    <%-- <div class="item">
                                <div class="item active">--%>
		<div class="col-lg-2">
            
       <%--<asp: Image runat="server" id="imgid" <img src="<%# Eval("SiddOrgImagePath") %>" alt="" class="img-fluid img-thumbnail galleryImg"></asp> --%>
        <a runat="server" class="fancybox-button" data-fancybox-group="button" ><img src="<%#Eval("SiddOrgImagePath") %>" alt="" class="img-fluid img-thumbnail galleryImg" /></a>
		</div>
                   <%--                 </div>
                            </div>--%>
		</ItemTemplate></asp:Repeater>
            </div>
            </div>
	</div> 
                   
		
  </div>
</div>

</div>
<%--<link rel="stylesheet" type="text/css" href="source/jquery.fancybox.css?v=2.1.5" media="screen" />
<!-- Add Button helper (this is optional) -->
<link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />--%>

<%--<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet"/>
<script src="https://kit.fontawesome.com/a076d05399.js"></script>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script> 
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
<script src="js/jquery-1.10.2.min.js"></script>

<!-- Add fancyBox main JS and CSS files -->
<script type="text/javascript" src="source/jquery.fancybox.pack.js?v=2.1.5"></script>
<script type="text/javascript" src="source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>--%>



<script type="text/javascript">

$(document).ready(function() {
	/* Simple image gallery. Uses default settings */
    
	$('.fancybox').fancybox();

	/*Button helper. Disable animations, hide close button, change title type and content*/

    $('.fancybox-button').fancybox({
       
		openEffect  : 'none',
		closeEffect : 'none',
		prevEffect : 'none',
		nextEffect : 'none',
		closeBtn  : false,
		helpers : {
			title : {
				type : 'inside'
			},
			buttons	: {}
		},
        afterLoad: function () {
            
			this.title = 'Image ' + (this.index + 1) + ' of ' + this.group.length + (this.title ? ' - ' + this.title : '');
		}
	});
});
</script>

<script type="text/javascript">

jQuery(document).on('click', '.mega-dropdown', function(e) {
  e.stopPropagation()
})
</script>

 </body>
</asp:Content>
