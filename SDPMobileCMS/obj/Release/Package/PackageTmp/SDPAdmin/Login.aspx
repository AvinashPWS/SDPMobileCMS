<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SDPAdmin.Login" %>

<!DOCTYPE html>
<html lang="en" class="bg-dark">
<!-- Mirrored from flatfull.com/themes/note/signin.html by HTTrack Website Copier/3.x [XR&CO'2013], Tue, 23 Dec 2014 04:48:06 GMT -->
<head runat="server">
    <meta charset="utf-8" />
    <title>Sai Datta Peetham Mobile CMS</title>
    <meta name="description" content="app, web app, responsive, admin dashboard, admin, flat, flat ui, ui kit, off screen nav" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="stylesheet" href="appCore/css/font.css" type="text/css" />
    <link rel="stylesheet" href="appCore/css/app.v1.css" type="text/css" />
    <!--[if lt IE 9]> <script src="js/ie/html5shiv.js"></script> <script src="js/ie/respond.min.js"></script> <script src="js/ie/excanvas.js"></script> <![endif]-->
</head>
<body class="">
    <section id="content" class="m-t-lg wrapper-md animated fadeInUp">
        <div class="container aside-xxl">
            <a class="navbar-brand block" href="#">Sai Datta Peetham Mobile CMS</a>
            <section class="panel panel-default bg-white m-t-lg">
                <header class="panel-heading text-center">
                    <strong>Sign in</strong>
                </header>
                <form runat="server" id="form1">

                    <div class="panel-body wrapper-lg">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <script type="text/javascript">
                            var prm = Sys.WebForms.PageRequestManager.getInstance();
                            //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
                            prm.add_beginRequest(BeginRequestHandler);
                            // Raised after an asynchronous postback is finished and control has been returned to the browser.
                            prm.add_endRequest(EndRequestHandler);

                            function BeginRequestHandler(sender, args) {
                                //Shows the modal popup - the update progress
                                var popup = $find('<%= modalPopup.ClientID %>');
                                if (popup != null) {
                                    popup.show();
                                }
                            }

                            function EndRequestHandler(sender, args) {
                                //Hide the modal popup - the update progress
                                var popup = $find('<%= modalPopup.ClientID %>');
                                if (popup != null) {
                                    popup.hide();
                                }
                            }
                        </script>

                        <asp:UpdateProgress ID="UpdateProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                            <ProgressTemplate>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <ajaxToolkit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
                            PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <label class="control-label">
                                        User ID</label>
                                    <asp:TextBox ID="UserIDTextbox" Text="saidattanj" runat="server" placeholder="User ID" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">
                                        Password</label>
                                    <asp:TextBox ID="PasswordTextbox" runat="server" Text="1saidatta2nj3" placeholder="Password" CssClass="form-control input-lg"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label runat="server" id="LoginMessageLabel" class="control-label bg-danger">
                                    </label>
                                </div>

                                <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="LoginButton_Click" />
                                <asp:Button ID="ResetButton" runat="server" CssClass="btn btn-danger" Text="Reset" OnClick="ResetButton_Click" />

                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                </form>
            </section>
        </div>
    </section>
    <!-- footer -->
    <footer id="footer">
        <div class="text-center padder">
            <p>
                <small>All Rights Reserved<br>
                    &copy; 2016</small>
            </p>
        </div>
    </footer>
    <!-- / footer -->
    <!-- Bootstrap -->
    <!-- App -->
    <script src="appCore/js/app.v1.js"></script>
    <script src="appCore/js/app.plugin.js"></script>
</body>
<!-- Mirrored from flatfull.com/themes/note/signin.html by HTTrack Website Copier/3.x [XR&CO'2013], Tue, 23 Dec 2014 04:48:06 GMT -->
</html>
