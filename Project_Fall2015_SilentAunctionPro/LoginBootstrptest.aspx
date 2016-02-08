<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginBootstrptest.aspx.cs" Inherits="Project_Fall2015_SilentAunctionPro.LoginBootstrptest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/navbar-fixed-top.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-default" role="navigation">
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#myModal" data-toggle="modal" data-target="#myModal">Log-in</a></li>
                </ul>
            </div>
        </nav>

        <div class="text-center">
            <h1>Open log-in modal from navbar</h1>
            <p class="lead">Go ahead, click the 'Log-in' button in the top right of the navbar.</p>
        </div>

        <div class="modal fade" id="myModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                        <h4 class="modal-title">Log-in</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Email address</label>
                            <input class="form-control" id="exampleInputEmail1" placeholder="Enter email" type="email">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Password</label>
                            <input class="form-control" id="exampleInputPassword1" placeholder="Password" type="password">
                        </div>
                        <p class="text-right"><a href="#">Forgot password?</a></p>
                    </div>
                    <div class="modal-footer">
                        <a href="#" data-dismiss="modal" class="btn">Close</a>
                        <a href="#" class="btn btn-primary">Log-in</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
