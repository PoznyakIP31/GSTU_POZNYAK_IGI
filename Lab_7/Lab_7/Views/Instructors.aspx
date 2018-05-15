<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instructors.aspx.cs" Inherits="Lab_7.Views.Instructors" %>

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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="InstructorID" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" InsertVisible="False" ReadOnly="True" SortExpression="InstructorID" />
                    <asp:BoundField DataField="Aducation" HeaderText="Aducation" SortExpression="Aducation" />
                    <asp:BoundField DataField="Experience" HeaderText="Experience" SortExpression="Experience" />
                    <asp:BoundField DataField="Midname" HeaderText="Midname" SortExpression="Midname" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sport_complexConnectionString %>" SelectCommand="SELECT [InstructorID], [Aducation], [Experience], [Midname], [Name], [Surname] FROM [Instructors]" DeleteCommand="DELETE FROM [Instructors] WHERE [InstructorID] = @InstructorID" InsertCommand="INSERT INTO [Instructors] ([Aducation], [Experience], [Midname], [Name], [Surname]) VALUES (@Aducation, @Experience, @Midname, @Name, @Surname)" UpdateCommand="UPDATE [Instructors] SET [Aducation] = @Aducation, [Experience] = @Experience, [Midname] = @Midname, [Name] = @Name, [Surname] = @Surname WHERE [InstructorID] = @InstructorID">
                <DeleteParameters>
                    <asp:Parameter Name="InstructorID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Aducation" Type="String" />
                    <asp:Parameter Name="Experience" Type="Int32" />
                    <asp:Parameter Name="Midname" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Surname" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Aducation" Type="String" />
                    <asp:Parameter Name="Experience" Type="Int32" />
                    <asp:Parameter Name="Midname" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Surname" Type="String" />
                    <asp:Parameter Name="InstructorID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
