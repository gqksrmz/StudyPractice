<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestViewState.aspx.cs" Inherits="Asp.NetDemo1.Page.TestViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            按钮计数器
            <asp:Button ID="Button1" runat="server" Text="点击" OnClick="Button1_Click" />
            <br />
           您单击了多少 <asp:Literal ID="Literal1" runat="server">0</asp:Literal>次
        </div>
    </form>
</body>
</html>
