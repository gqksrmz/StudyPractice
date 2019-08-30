<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Asp.NetDemo1.Page.UserLogin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            登录：<asp:TextBox ID="textName" runat="server"></asp:TextBox>
            <br />
            密码：<asp:TextBox ID="textPwd" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
            <asp:Literal ID="litMsg" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
