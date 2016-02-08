<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Geolocation.aspx.cs" 
    MasterPageFile="~/MasterPages/Main.Master"
    Inherits="Project_Fall2015_SilentAunctionPro.Geolocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Silent Auction Pro</title>
     <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=false&amp;key=ABQIAAAAuPsJpk3MBtDpJ4G8cqBnjRRaGTYH6UMl8mADNa0YKuWNNa8VNxQCzVBXTx2DYyXGsTOxpWhvIG7Djw"
type="text/javascript">

</script>

   <%--  <script src="Maps.js" type="text/javascript"></script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" onload="initialize()">
    <br />
    <br />
    <br />
   
    <script>


        var map = null;
        var geocoder = null;

        function initialize() {
            if (GBrowserIsCompatible()) {
                map = new GMap2(document.getElementById("map_canvas"));
                map.setCenter(new GLatLng(37.4419, -122.1419), 13);
                geocoder = new GClientGeocoder();
            }
        }

        function showAddress(address) {
            if (geocoder) {
                geocoder.getLatLng(
                  address,
                  function (point) {
                      if (!point) {
                          alert(address + " not found");
                      } else {
                          map.setCenter(point, 13);
                          var marker = new GMarker(point);
                          map.addOverlay(marker);
                          marker.openInfoWindowHtml(address);
                      }
                  }
                );
            }
        }



    </script>

</asp:Content>