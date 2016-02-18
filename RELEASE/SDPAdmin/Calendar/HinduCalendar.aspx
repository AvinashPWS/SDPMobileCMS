<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HinduCalendar.aspx.cs" Inherits="SDPAdmin.Calendar.HinduCalendar" %>

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
                                                        Calendar Details
                                                    </header>
                                                    <div class="panel-body">
                                                        <div class="form-group pull-in clearfix">
                                                            <div class="col-sm-6">
                                                                <label>
                                                                    Calendar Name</label>
                                                                <asp:TextBox ID="HinduCalendarNameTextBox" runat="server" class="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" Font-Bold="True" ControlToValidate="HinduCalendarNameTextBox" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div class="col-sm-8">
                                                                    <label>
                                                                        Calendar Attachment</label>
                                                                    <asp:FileUpload ID="HinduCalendarFileUpload" runat="server" CssClass="form-control" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <label>
                                                                        &nbsp;</label>
                                                                    <asp:Button ID="HinduCalendarFileUploadButton" runat="server" Text="Upload Image" CssClass="btn btn-danger form-control" OnClick="HinduCalendarFileUploadButton_Click" CausesValidation="False" />
                                                                    <%--<asp:HiddenField ID="HinduCalendarFileName" runat="server" />--%>
                                                                    <asp:TextBox ID="HinduCalendarFileName" runat="server" Style="display: none"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Upload Image" Font-Bold="True" ControlToValidate="HinduCalendarFileName" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group pull-in clearfix">
                                                            <div class="col-sm-6">
                                                                <div class="col-sm-8">
                                                                    <label>
                                                                        Calendar Target</label>
                                                                    <asp:FileUpload ID="HinduCalendarDetailFileUpload" runat="server" CssClass="form-control" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <label>
                                                                        &nbsp;</label>
                                                                    <asp:Button ID="HinduCalendarDetailFileUploadButton" runat="server" Text="Upload Target" CssClass="btn btn-danger form-control" CausesValidation="False" OnClick="HinduCalendarDetailFileUploadButton_Click" />
                                                                    <%--<asp:HiddenField ID="HinduCalendarDetailFile" runat="server" />--%>
                                                                    <asp:TextBox ID="HinduCalendarDetailFileName" runat="server" Style="display: none"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Upload Image" Font-Bold="True" ControlToValidate="HinduCalendarDetailFileName" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group pull-right">
                                                            <div class="col-sm-12">
                                                                <span id="HinduCalendarUpdatePanel" runat="server" visible="false">
                                                                    <asp:Button ID="HinduCalendarUpdateButton" runat="server" Text="Update" CssClass="btn btn-info" OnClick="HinduCalendarUpdateButton_Click" />
                                                                    <asp:Button ID="HinduCalendarUpdateCancelButton" runat="server" Text="Cancel Update" CssClass="btn btn-default" OnClick="HinduCalendarCancelButton_Click" />
                                                                </span>
                                                                <asp:Button ID="HinduCalendarSaveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="HinduCalendarSaveButton_Click" />
                                                                <asp:Button runat="server" Text="Reset" CssClass="btn btn-default" OnClick="HinduCalendarCancelButton_Click" CausesValidation="False" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </section>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <section class="panel panel-default">
                                                    <header class="panel-heading font-bold">Calendar List</header>
                                                    <div class="panel-body">
                                                        <asp:GridView ID="HinduCalendarGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="HinduCalendarSqlDataSource" CssClass="table table-striped m-b-none" Width="100%" AllowSorting="True" AllowPaging="True">
                                                            <Columns>
                                                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" Visible="False" />
                                                                <asp:BoundField DataField="EVENT_NAME" HeaderText="Calendar Name" SortExpression="EVENT_NAME" />
                                                                <asp:BoundField DataField="DATETIME" HeaderText="Created On" SortExpression="DATETIME" />

                                                                <asp:TemplateField>
                                                                    <ItemStyle Width="15%" />
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink Target="_blank" ID="HinduCalendarAttachmentButton" runat="server" CssClass="btn btn-info fa fa-external-link-square"
                                                                            CommandArgument='<%# Eval("EVENT_ATTACHMENT")%>' Text="" NavigateUrl='<%# Eval("EVENT_ATTACHMENT")%>'></asp:HyperLink>
                                                                        <asp:LinkButton ID="HinduCalendarEditButton" runat="server" CssClass="btn btn-primary fa fa-edit"
                                                                            CommandArgument='<%# Eval("ID")%>' Text="" OnClick="HinduCalendarEditButton_Click" CausesValidation="False"></asp:LinkButton>

                                                                        <asp:LinkButton ID="HinduCalendarDeleteButton" runat="server" CssClass="btn btn-danger fa fa-times"
                                                                            CommandArgument='<%# Eval("ID")%>'
                                                                            OnClientClick="return confirm('Do you want to delete?')"
                                                                            Text="" OnClick="HinduCalendarDeleteButton_Click" CausesValidation="False"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="HinduCalendarSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SaiDatta %>" SelectCommand="SELECT * FROM [EVENT_CALENDAR]"></asp:SqlDataSource>

                                                    </div>
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="HinduCalendarFileUploadButton" />
                                        <asp:AsyncPostBackTrigger ControlID="HinduCalendarSaveButton" />
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

