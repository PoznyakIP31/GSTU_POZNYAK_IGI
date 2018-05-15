<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="Lab_7.Views.Groups" %>

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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="GroupID" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="GroupID" HeaderText="GroupID" InsertVisible="False" ReadOnly="True" SortExpression="GroupID" />
                    <asp:BoundField DataField="Count_of_visitor" HeaderText="Count_of_visitor" SortExpression="Count_of_visitor" />
                    <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" SortExpression="InstructorID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sport_complexConnectionString %>" SelectCommand="SELECT [GroupID], [Count_of_visitor], [InstructorID], [Name] FROM [Groups]" DeleteCommand="DELETE FROM [Groups] WHERE [GroupID] = @GroupID" InsertCommand="INSERT INTO [Groups] ([Count_of_visitor], [InstructorID], [Name]) VALUES (@Count_of_visitor, @InstructorID, @Name)" UpdateCommand="UPDATE [Groups] SET [Count_of_visitor] = @Count_of_visitor, [InstructorID] = @InstructorID, [Name] = @Name WHERE [GroupID] = @GroupID">
                <DeleteParameters>
                    <asp:Parameter Name="GroupID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Count_of_visitor" Type="Int32" />
                    <asp:Parameter Name="InstructorID" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Count_of_visitor" Type="Int32" />
                    <asp:Parameter Name="InstructorID" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="GroupID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
