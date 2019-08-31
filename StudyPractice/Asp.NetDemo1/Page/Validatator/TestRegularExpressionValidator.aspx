<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRegularExpressionValidator.aspx.cs" Inherits="Asp.NetDemo1.Page.Validatator.TestRegularExpressionValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            电子邮件：<asp:TextBox ID="textEmail" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textEmail" ErrorMessage="电子邮件格式不正确" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="注册提交" />
        </div>
    </form>
</body>
</html>
