<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestValidationSummary.aspx.cs" Inherits="Asp.NetDemo1.Page.Validatator.TestValidationSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<asp:TextBox ID="textName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入用户名！" ControlToValidate="textName" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            密码：<asp:TextBox ID="textPwd" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入密码！" ControlToValidate="textPwd" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="登录注册" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
