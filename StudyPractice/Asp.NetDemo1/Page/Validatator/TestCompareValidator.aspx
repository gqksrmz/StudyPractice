<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCompareValidator.aspx.cs" Inherits="Asp.NetDemo1.Page.Validatator.TestCompareValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户密码：<asp:TextBox ID="textPwd1" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入密码！" ControlToValidate="textPwd1" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            密码确认：<asp:TextBox ID="textPwd2" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请再次输入密码！" ControlToValidate="textPwd2" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="textPwd1" ControlToValidate="textPwd2" Display="Dynamic" ErrorMessage="两次输入密码不相同！" ForeColor="Red"></asp:CompareValidator>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="提交注册" />
        </div>
    </form>
</body>
</html>
