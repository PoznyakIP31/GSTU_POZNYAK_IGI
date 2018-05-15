<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visitors.aspx.cs" Inherits="Lab_7.Views.Visitors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="~/UserPage.aspx">Домашняя</a></li>
                        <%--<li><a runat="server" href="~/About">Информация</a></li>
                        <li><a runat="server" href="~/Contact">Связаться</a></li>--%>
                        <li><a runat="server" href="Instructors.aspx">Instructors</a></li>
                        <li><a runat="server" href="Visitors.aspx">Visitors</a></li>
                        <li><a runat="server" href="Groups.aspx">Groups</a></li>
                        <li><a runat="server" href="TimeTables.aspx">TimeTables</a></li>
                    </ul>
                </div>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="VisitorID" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="VisitorID" HeaderText="VisitorID" InsertVisible="False" ReadOnly="True" SortExpression="VisitorID" />
                    <asp:BoundField DataField="GroupID" HeaderText="GroupID" SortExpression="GroupID" />
                    <asp:BoundField DataField="Midname" HeaderText="Midname" SortExpression="Midname" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Passport" HeaderText="Passport" SortExpression="Passport" />
                    <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sport_complexConnectionString %>" SelectCommand="SELECT [VisitorID], [GroupID], [Midname], [Name], [Passport], [Surname] FROM [Visitors]" DeleteCommand="DELETE FROM [Visitors] WHERE [VisitorID] = @VisitorID" InsertCommand="INSERT INTO [Visitors] ([GroupID], [Midname], [Name], [Passport], [Surname]) VALUES (@GroupID, @Midname, @Name, @Passport, @Surname)" UpdateCommand="UPDATE [Visitors] SET [GroupID] = @GroupID, [Midname] = @Midname, [Name] = @Name, [Passport] = @Passport, [Surname] = @Surname WHERE [VisitorID] = @VisitorID">
                <DeleteParameters>
                    <asp:Parameter Name="VisitorID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="GroupID" Type="Int32" />
                    <asp:Parameter Name="Midname" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Passport" Type="String" />
                    <asp:Parameter Name="Surname" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="GroupID" Type="Int32" />
                    <asp:Parameter Name="Midname" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Passport" Type="String" />
                    <asp:Parameter Name="Surname" Type="String" />
                    <asp:Parameter Name="VisitorID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
