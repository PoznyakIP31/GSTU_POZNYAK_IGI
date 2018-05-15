<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="Lab_7.UserPage" %>

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
                        <li><a runat="server" href="Views/Instructors.aspx">Instructors</a></li>
                        <li><a runat="server" href="Views/Visitors.aspx">Visitors</a></li>
                        <li><a runat="server" href="Views/Groups.aspx">Groups</a></li>
                        <li><a runat="server" href="Views/TimeTables.aspx">TimeTables</a></li>
                    </ul>
                </div>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" style="margin-left:20px;margin-top:10px;">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Button ID="Button1" runat="server" Height="34" Text="Выйти" OnClick="Button1_Click" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">

                     <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1">
                     </asp:TreeView>
                     <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />

                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
