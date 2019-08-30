<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestButtonDemo.aspx.cs" Inherits="Asp.NetDemo1.Page.Widget.TestButtonDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            学号：<asp:TextBox ID="textNum" runat="server"></asp:TextBox>
            <asp:Button ID="btnDel" OnClientClick="return confirm('确认删除吗?')" runat="server" Text="删除" OnClick="btnDel_Click" />
            <asp:Literal ID="litMsg" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
