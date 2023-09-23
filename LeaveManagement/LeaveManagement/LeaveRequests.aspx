<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveRequests.aspx.cs" Inherits="LeaveManagement.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="main-content">
        <section id="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-4 col-md-offset-4">
                                <h1>Leave Submission</h1>
                            </div>
                        </header>

                        <h2>Welcome <% Response.Write(Session["User"]); %> </h2>

                        <div class="panel-body">
                            <div class="row">

                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="From:" runat="server" />
                                        <asp:Calendar Required="true" ID="FromDate" runat="server" Enabled="true" CssClass="startDate"  />
                                        <asp:CustomValidator ID="FromDateCustVal" OnServerValidate="FromDateCustVal_Validate" runat="server"></asp:CustomValidator>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FromDate" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator ID="DateValidator" ControlToValidate="FromDate" Display="Dynamic" EnableClientScript="true" runat="server" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)\d\d$" SetFocusOnError="true">
                                        Please enter date in dd/MM/yyyy format>--%>

                                        <%--</asp:RegularExpressionValidator>--%>

                                        <span asp-validation-for="From:" class="text-danger"></span>
                                    </div>
                                </div>

                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Until:" runat="server" />
                                        <asp:Calendar Required="true" ID="ToDate" runat="server" Enabled="true" CssClass="endDate" />
                                        <asp:CustomValidator ID="UntilDateCustVal" OnServerValidate="UntilDateCustVal_Validate" runat="server"></asp:CustomValidator>
                                        <span asp-validation-for="Until:" class="text-danger"></span>
                                    </div>
                                </div>


                                <div>

                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label Text="Name" runat="server" />
                                            <asp:TextBox ID="Name" runat="server" Enabled="true" CssClass="form-control input-group-lg" />
                                        </div>
                                    </div>



                                    <div class="col-md-4 col-md-offset-1">
                                        <div class="form-group">
                                            <asp:Label Text="Leave Type:" runat="server" />
                                            <asp:DropDownList Required="true" ID="Type" runat="server" Enabled="true" CssClass="form-control input-group-sm">
                                                <asp:ListItem Text="Anual" />
                                                <asp:ListItem Text="Sick" />
                                                <asp:ListItem Text="Unpaid" />
                                            </asp:DropDownList>
                                            <span asp-validation-for="Leave Type" class="text-danger"></span>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Reason" runat="server" />
                                        <asp:TextBox Required="true" ID="Reason" runat="server" Enabled="true" CssClass="form-control input-group-lg" placeholder="Reason" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1" style="padding-top: 10px">
                                        <div class="form-group">
                                            <asp:Button Text="Submit" ID="btnsubmit" OnClick="btnsubmit_Click" CssClass="btn btn-primary" Width="150px" runat="server" />
                                            <asp:Label Text="" ForeColor="White" BackColor="Green" ID="lblmessage" CssClass="label label-success" runat="server" />
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <br />
                            <asp:GridView ID="gv" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </div>
                    </section>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
