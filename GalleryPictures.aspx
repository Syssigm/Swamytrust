<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswari.Master" AutoEventWireup="true" CodeBehind="GalleryPictures.aspx.cs" Inherits="Siddeswari.GalleryPictures" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


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
        <a href="<%#Eval("SiddOrgImagePath") %>" class="fancybox-button" data-fancybox-group="button" ><img src="<%#Eval("SiddOrgImagePath") %>" alt="" class="img-fluid img-thumbnail galleryImg" /></a>
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

<link rel="stylesheet" type="text/css" href="source/jquery.fancybox.css?v=2.1.5" media="screen" />
<!-- Add Button helper (this is optional) -->
<link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />

<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet"/>
<script src="https://kit.fontawesome.com/a076d05399.js"></script>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script> 
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
<script src="js/jquery-1.10.2.min.js"></script>

<!-- Add fancyBox main JS and CSS files -->
<script type="text/javascript" src="source/jquery.fancybox.pack.js?v=2.1.5"></script>
<script type="text/javascript" src="source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>



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
