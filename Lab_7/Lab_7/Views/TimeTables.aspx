<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeTables.aspx.cs" Inherits="Lab_7.Views.TimeTables" %>

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
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TimeTableID" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="TimeTableID" HeaderText="TimeTableID" InsertVisible="False" ReadOnly="True" SortExpression="TimeTableID" />
                <asp:BoundField DataField="Days_of_the_week" HeaderText="Days_of_the_week" SortExpression="Days_of_the_week" />
                <asp:BoundField DataField="GroupID" HeaderText="GroupID" SortExpression="GroupID" />
                <asp:BoundField DataField="Time_visits" HeaderText="Time_visits" SortExpression="Time_visits" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sport_complexConnectionString %>" SelectCommand="SELECT [TimeTableID], [Days_of_the_week], [GroupID], [Time_visits] FROM [Timetables]" DeleteCommand="DELETE FROM [Timetables] WHERE [TimeTableID] = @TimeTableID" InsertCommand="INSERT INTO [Timetables] ([Days_of_the_week], [GroupID], [Time_visits]) VALUES (@Days_of_the_week, @GroupID, @Time_visits)" UpdateCommand="UPDATE [Timetables] SET [Days_of_the_week] = @Days_of_the_week, [GroupID] = @GroupID, [Time_visits] = @Time_visits WHERE [TimeTableID] = @TimeTableID">
            <DeleteParameters>
                <asp:Parameter Name="TimeTableID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Days_of_the_week" Type="Int32" />
                <asp:Parameter Name="GroupID" Type="Int32" />
                <asp:Parameter Name="Time_visits" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Days_of_the_week" Type="Int32" />
                <asp:Parameter Name="GroupID" Type="Int32" />
                <asp:Parameter Name="Time_visits" Type="String" />
                <asp:Parameter Name="TimeTableID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
