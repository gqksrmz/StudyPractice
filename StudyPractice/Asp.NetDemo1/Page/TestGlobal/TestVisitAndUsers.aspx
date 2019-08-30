<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestVisitAndUsers.aspx.cs" Inherits="Asp.NetDemo1.Page.TestGlobal.TestVisitAndUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           您是本站的第 <asp:Literal ID="litMsg" runat="server">0</asp:Literal>位访客
            <asp:Button ID="btnClear" runat="server" Text="清除当前用户的Session信息" OnClick="btnClear_Click" />
        </div>
    </form>
</body>
</html>
