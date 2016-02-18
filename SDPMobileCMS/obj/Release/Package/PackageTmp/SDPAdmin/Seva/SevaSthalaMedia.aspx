<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SevaSthalaMedia.aspx.cs" Inherits="SDPAdmin.Seva.SevaSthalaMedia" %>


<!DOCTYPE html>
<html lang="en" class="app">
<head runat="server">
    <meta charset="utf-8" />
    <title>Sai Datta Peetham Mobile CMS</title>
    <meta name="description" content="app, web app, responsive, admin dashboard, admin, flat, flat ui, ui kit, off screen nav" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="stylesheet" href="../appCore/css/font.css" type="text/css" />
    <link rel="stylesheet" href="../appCore/css/app.v1.css" type="text/css" />
</head>
<body class="">

    <section class="vbox">
        <header class="bg-dark dk header navbar navbar-fixed-top-xs">
            <div class="navbar-header aside-md">
                <a class="btn btn-link visible-xs" data-toggle="class:nav-off-screen,open" data-target="#nav,html">
                    <i class="fa fa-bars"></i></a><a href="#" class="navbar-brand" data-toggle="fullscreen">
                        <img src="../appCore/images/logo.png" class="m-r-sm">Admin</a> <a class="btn btn-link visible-xs"
                            data-toggle="dropdown" data-target=".nav-user"><i class="fa fa-cog"></i>
                        </a>
            </div>


        </header>
        <section>
            <section class="hbox stretch">

                <!-- .aside -->
                <aside class="bg-dark lter b-r aside-md hidden-print hidden-xs" id="nav">
                    <section class="vbox">

                        <section class="w-f scrollable">
                            <div class="slim-scroll" data-height="auto" data-disable-fade-out="true" data-distance="0"
                                data-size="5px" data-color="#333333">
                                <!-- nav -->
                                <nav class="nav-primary hidden-xs">
                                    <ul class="nav">
                                        <li><a href="#"><i class="fa fa-edit icon"><b class="bg-success"></b></i>
                                            <span class="pull-right"><i class="fa fa-angle-down text"></i><i class="fa fa-angle-up text-active"></i></span><span>Events</span> </a>
                                            <ul class="nav lt">

                                                <li><a href="../Events/EventUpcoming.aspx"><i class="fa fa-angle-right"></i><span>Upcoming Events</span>
                                                </a></li>
                                                <li><a href="../Events/EventFlashNews.aspx"><i class="fa fa-angle-right"></i><span>Flash News Events</span>
                                                </a></li>
                                                <li><a href="../Events/EventSponsors.aspx"><i class="fa fa-angle-right"></i><span>Sponsor Events</span>
                                                </a></li>
                                            </ul>
                                        </li>
                                        <li><a href="#"><i class="fa fa-clock-o icon"><b class="bg-success"></b></i>
                                            <span class="pull-right"><i class="fa fa-angle-down text"></i><i class="fa fa-angle-up text-active"></i></span><span>Schedules</span> </a>
                                            <ul class="nav lt">
                                                <li><a href="../Events/EventBanner.aspx"><i class="fa fa-angle-right"></i><span>Flyers</span>
                                                </a></li>
                                                <li><a href="../Events/EventDaily.aspx"><i class="fa fa-angle-right"></i><span>Daily Schedule</span>
                                                </a></li>
                                                <li><a href="../Events/EventRegular.aspx"><i class="fa fa-angle-right"></i><span>Regular Schedule</span>
                                                </a></li>
                                            </ul>
                                        </li>
                                        <li><a href="#"><i class="fa fa-upload icon"><b class="bg-info"></b></i>
                                            <span class="pull-right"><i class="fa fa-angle-down text"></i><i class="fa fa-angle-up text-active"></i></span><span>Gallery</span> </a>
                                            <ul class="nav lt">
                                                <li><a href="../Gallery/Images.aspx"><i class="fa fa-angle-right"></i><span>Images</span>
                                                </a></li>
                                                <li><a href="../Gallery/Videos.aspx"><i class="fa fa-angle-right"></i><span>Videos</span>
                                                </a></li>
                                                <li><a href="../Gallery/Quotes.aspx"><i class="fa fa-angle-right"></i><span>Quotes</span>
                                                </a></li>
                                                 <li><a href="../Gallery/Audio.aspx"><i class="fa fa-angle-right"></i><span>Audio</span>
                                                </a></li>
                                            </ul>
                                        </li>
                                        <li><a href="#"><i class="fa fa-bell icon"><b class="bg-info"></b></i>
                                            <span class="pull-right"><i class="fa fa-angle-down text"></i><i class="fa fa-angle-up text-active"></i></span><span>Calendar</span> </a>
                                            <ul class="nav lt">
                                                <li><a href="../Calendar/HinduCalendar.aspx"><i class="fa fa-angle-right"></i><span>Hindu Calendar</span>
                                                </a></li>
                                            </ul>
                                        </li>
                                        <li><a href="#"><i class="fa fa-bell icon"><b class="bg-primary"></b></i>
                                            <span class="pull-right"><i class="fa fa-angle-down text"></i><i class="fa fa-angle-up text-active"></i></span><span>Notifications</span> </a>
                                            <ul class="nav lt">
                                                <li><a href="../Notifications/SendNotification.aspx"><i class="fa fa-angle-right"></i><span>Create</span>
                                                </a></li>
                                            </ul>
                                        </li>
                                        <li><a href="#"><i class="fa fa-bell icon"><b class="bg-primary"></b></i>
                                            <span class="pull-right"><i class="fa fa-angle-down text"></i><i class="fa fa-angle-up text-active"></i></span><span>Seva</span> </a>
                                            <ul class="nav lt">
                                                <li><a href="../Seva/SevaSthalaFAQ.aspx"><i class="fa fa-angle-right"></i><span>Sthala Seva</span>
                                                </a></li>
                                                <li><a href="../Seva/SevaSthalaMedia.aspx"><i class="fa fa-angle-right"></i><span>Sthala Seva Media</span>
                                                </a></li>
                                                <li><a href="../Seva/SevaAnnadamMedia.aspx"><i class="fa fa-angle-right"></i><span>Annadana Seva Media</span>
                                                </a></li>
                                            </ul>
                                        </li>
                                        <li><a href="../Login.aspx"><i class="fa fa-sign-out icon"><b class="bg-danger"></b></i>
                                            <span class="pull-right"><i class="fa fa-angle-down text"></i><i class="fa fa-angle-up text-active"></i></span><span>Logout</span> </a>
                                        </li>
                                    </ul>
                                </nav>
                                <!-- / nav -->
                            </div>
                        </section>
                        <footer class="footer lt hidden-xs b-t b-light">
                            <a href="#nav" data-toggle="class:nav-xs" class="pull-right btn btn-sm btn-default btn-icon">
                                <i class="fa fa-angle-left text"></i><i class="fa fa-angle-right text-active"></i>
                            </a>
                        </footer>
                    </section>
                </aside>
                <section id="content">
                    <section class="vbox">
                        <section class="scrollable padder">
                            <form id="form1" runat="server">
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
                                        <br />
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <section class="panel panel-default">
                                                    <header class="panel-heading font-bold">
                                                        Media Details
                                                    </header>
                                                    <div class="panel-body">
                                                        <div class="form-group pull-in clearfix">
                                                            <div class="col-sm-6">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <label>
                                                                            Media Header</label>
                                                                        <asp:TextBox ID="MediaHeaderNameTextBox" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" Font-Bold="True" ControlToValidate="MediaHeaderNameTextBox" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <label>
                                                                            Media Title</label>
                                                                        <asp:TextBox ID="MediaTitleTextBox" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" Font-Bold="True" ControlToValidate="MediaTitleTextBox" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <label>
                                                                            Media Type</label>
                                                                        <asp:DropDownList CssClass="btn btn-default dropdown-toggle" ID="MediaTypeDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="MediaTypeDropDownList_SelectedIndexChanged">
                                                                            <asp:ListItem Text="IMAGE"></asp:ListItem>
                                                                            <asp:ListItem Text="VIDEO"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <br />
                                                                <div class="row">
                                                                    <div class="col-sm-6" id="MediaTypeImagePanel" runat="server">
                                                                        <label>
                                                                            Media Attachment</label>
                                                                        <asp:FileUpload ID="MediaFileUpload" runat="server" CssClass="form-control"/>
                                                                        <asp:Button ID="MediaFileUploadButton" runat="server" Text="Upload File" CssClass="btn btn-danger form-control" OnClick="MediaFileUploadButton_Click" CausesValidation="False" />
                                                                        <%--<asp:HiddenField ID="MediaFileName" runat="server" />--%>
                                                                        <asp:TextBox ID="MediaFileName" runat="server" Style="display: none"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="MediaAttachmentRequiredFieldValidator" Enabled="true" runat="server" ErrorMessage="Upload File" Font-Bold="True" ControlToValidate="MediaFileName" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="col-sm-6" id="MediaTypeVideoPanel" runat="server" visible="false">
                                                                        <label>
                                                                            Video ID</label>
                                                                        <asp:TextBox CssClass="form-control" ID="MediaAttachmentTextbox" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group pull-right">
                                                            <div class="col-sm-12">
                                                                <span id="MediaUpdatePanel" runat="server" visible="false">
                                                                    <asp:Button ID="MediaUpdateButton" runat="server" Text="Update" CssClass="btn btn-info" OnClick="MediaUpdateButton_Click" />
                                                                    <asp:Button ID="MediaUpdateCancelButton" runat="server" Text="Cancel Update" CssClass="btn btn-default" OnClick="MediaCancelButton_Click" CausesValidation="False" />

                                                                </span>
                                                                <asp:Button ID="MediaSaveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="MediaSaveButton_Click" />
                                                                <asp:Button runat="server" Text="Reset" CssClass="btn btn-default" OnClick="MediaCancelButton_Click" CausesValidation="False" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </section>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <section class="panel panel-default">
                                                    <header class="panel-heading font-bold">Media List</header>
                                                    <div class="panel-body">
                                                        <asp:GridView ID="MediaGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="MediaSqlDataSource" CssClass="table table-striped m-b-none" Width="100%" AllowSorting="True" AllowPaging="True">
                                                            <Columns>
                                                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" Visible="False" />
                                                                <asp:BoundField DataField="MEDIA_HEADER" HeaderText="Media Header" SortExpression="MEDIA_HEADER" />
                                                                <asp:BoundField DataField="MEDIA_TITLE" HeaderText="Media Title" SortExpression="MEDIA_TITLE" />
                                                                <asp:BoundField DataField="DATETIME" HeaderText="Created On" SortExpression="DATETIME" />

                                                                <asp:TemplateField>
                                                                    <ItemStyle Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink Target="_blank" ID="MediaFileNameButton" runat="server" CssClass="btn btn-info fa fa-external-link-square"
                                                                            CommandArgument='<%# Eval("MEDIA_ATTACHMENT")%>' Text="" NavigateUrl='<%#  "http://www.youtube.com/embed/" + Eval("MEDIA_ATTACHMENT")%>'></asp:HyperLink>

                                                                        <asp:LinkButton ID="MediaEditButton" runat="server" CssClass="btn btn-primary fa fa-edit"
                                                                            CommandArgument='<%# Eval("ID")%>' Text="" OnClick="MediaEditButton_Click" CausesValidation="False"></asp:LinkButton>

                                                                        <asp:LinkButton ID="MediaDeleteButton" runat="server" CssClass="btn btn-danger fa fa-times"
                                                                            CommandArgument='<%# Eval("ID")%>'
                                                                            OnClientClick="return confirm('Do you want to delete?')"
                                                                            Text="" OnClick="MediaDeleteButton_Click" CausesValidation="False"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="MediaSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SaiDatta %>" SelectCommand="SELECT * FROM [SEVA_STHALA_MEDIA]"></asp:SqlDataSource>

                                                    </div>
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="MediaFileUploadButton" />
                                        <asp:AsyncPostBackTrigger ControlID="MediaSaveButton" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </form>
                        </section>
                    </section>
                </section>

            </section>
        </section>
    </section>

    <script type="text/javascript" src="../appCore/js/app.v1.js"></script>
    <script type="text/javascript" src="../appCore/js/app.plugin.js"></script>

</body>

</html>
