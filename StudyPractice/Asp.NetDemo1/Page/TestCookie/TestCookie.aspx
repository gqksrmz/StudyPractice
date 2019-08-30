<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCookie.aspx.cs" Inherits="Asp.NetDemo1.Page.TestSession.TestSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入用户名:<asp:TextBox ID="textBox1" runat="server"></asp:TextBox>
            <asp:Button ID="btnSave" runat="server" Text="将用户名保存到Cookie" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
