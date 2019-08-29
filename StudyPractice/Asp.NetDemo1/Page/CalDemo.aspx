<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalDemo.aspx.cs" Inherits="Asp.NetDemo1.Page.CalDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>基于事件加控件实现计算器</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="textNum1" runat="server"></asp:TextBox>+
            <asp:TextBox ID="textNum2" runat="server"></asp:TextBox>=
            <asp:TextBox ID="textResult" runat="server"></asp:TextBox>
            <asp:Button ID="btnCal" runat="server" Text="计算" OnClick="btnCal_Click" />
        </div>
        <div>
            <%string info = "Hello Asp.Net"; %>
            <%=info %>
        </div>
    </form>
</body>
</html>
