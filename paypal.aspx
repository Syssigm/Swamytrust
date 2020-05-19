<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paypal.aspx.cs" Inherits="Siddeswari.paypal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body runat="server">
   
    <asp:Label ID="Lblamt" runat="server" Text="Label"></asp:Label>
    <form id="form3"  action ="https://www.paypal.com/cgi-bin/webscr" method="post" runat="server">
        <input type="hidden"  name="cmd" value="_xclick" />
        <input type="hidden"  name="business" value="info@srisiddheswariseva.org" />
        <input type="hidden"  name="item_name"  value="Shakthi Prabha Magazine" />
       <input type="hidden" name="amount" value="50.00" />       
               
       
        <input type="submit"  value="Buy Now!" />
    </form>
                
</body>
</html>
