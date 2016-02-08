<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="Project_Fall2015_SilentAunctionPro.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Silent Auction Home Page</title>
    <link href="assets/css/style2.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <br />
    <br />
    <div id="main">

        <header>
            <div id="strapline">
                <div id="welcome_slogan">
                    <br />
                    <br />
                    <br />
                    <h3>Welcome To&nbsp;&nbsp;<span>Silent Auction Website</span></h3>
                </div>
                <!--close welcome_slogan-->

            </div>
            <!--close strapline-->
        </header>

        <div id="slideshow_container">
            <div class="slideshow">
                <ul class="slideshow">
                    <li class="show">
                        <img width="940" height="600" src="UserWebForms/Fe3.jpg" /></li>
                     <li>
                        <img width="940" height="600" src="UserWebForms/fest.jpg" /></li>
                     <li>
                        <img width="940" height="600" src="UserWebForms/Festival.jpg" /></li>
                      <li>
                        <img width="940" height="600" src="UserWebForms/img.jpg" /></li>
                      
                </ul>
            </div>
            <!--close slideshow-->
        </div>
        <!--close slideshow_container-->

        <div id="site_content" style="background-image:url('UserWebForms/imaglow.jpg');">
           

            <div class="sidebar_container">
                <div class="sidebar">
                    <div class="sidebar_item">
                        <h2 style="font-weight:900; color:whitesmoke;">Silent Auction</h2>
                        <p style="color:whitesmoke;">Welcome to our newly launched Bidding Website. Please surf around any feedback, concerns and comments are most welcome.</p>
                    </div>
                    <!--close sidebar_item-->
                </div>
                <!--close sidebar-->
                <div class="sidebar">
                    <div class="sidebar_item">
                        <h2 style="font-weight: 900; color:whitesmoke;">News and Updates</h2>
                        <h3 style="font-weight: 400; color:whitesmoke;">December 2015</h3>
                        <p style="color:whitesmoke;">On Decemeber 25th, OPENING NIGHT</p>
                    </div><br /><br /><br /><br /><br /><br />
                    <!--close sidebar_item-->
                </div>
                <!--close sidebar-->
               <%-- <div class="sidebar">
                    <div class="sidebar_item" style="color:whitesmoke;">
                        <h3 style="color:whitesmoke;">November 2015</h3>
                        <p style="color:whitesmoke;">Bid Events ....</p>
                    </div>
                    <!--close sidebar_item-->
                </div>--%>
                <!--close sidebar-->
            </div>
            <!--close sidebar_container-->

            <div id="content">
                <div class="content_item">
                    <h2 style="font-weight:900; color:whitesmoke;">Silent Auction Bidding</h2>
                    <p style="color:whitesmoke;">
                        Online silent auction event management software providing a complete event management
                 solution for charitable fundraising. Sell tickets, 
                store credit cards, online and mobile bidding, and more. 
                Top rated software for all types of charitable organizations including Schools, 
                Churchs, Service Clubs, etc.
                    </p>
                    <div class="content_container">
                       
                        <div class="content_item">
                            <h2 style="font-weight:900; color:whitesmoke;">Stay Connected..</h2>
                            <br />
                            <br />
                            <div class="g-plusone" data-annotation="none" data-href="https://plus.google.com/+ankitchainani"></div>
                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div class="fb-like" data-href="https://developers.facebook.com/docs/plugins/" data-width="30" data-layout="button_count" data-action="like" data-show-faces="true" data-share="false"></div>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		    <a href="https://twitter.com/SA_NASA" class="twitter-follow-button" data-show-count="false" data-size="large">Follow @SA_NASA</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a data-pin-do="buttonBookmark" data-pin-tall="true" data-pin-color="red" href="https://www.pinterest.com/pin/create/button/"><img src="//assets.pinterest.com/images/pidgets/pinit_fg_en_rect_red_28.png" /></a>
                        </div>
                    </div>
                    <!--close content_container-->
                </div>
                <!--close content_item-->
            </div>
            <!--close content-->
        </div>
        <!--close site_content-->



    </div>

    <div id="fb-root"></div>
    <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.5";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
    <script async defer src="//assets.pinterest.com/js/pinit.js"></script>
    <script src="https://apis.google.com/js/platform.js" async defer></script>
    <script src="http://code.jquery.com/jquery.js"></script>
    <!-- If no online access, fallback to our hardcoded version of jQuery -->
    <script src="assets/js/image_slide.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="assets/js/jquery-1.11.1.js"></script>
    <script src="assets/js/jquery.min.js"></script>
</asp:Content>
