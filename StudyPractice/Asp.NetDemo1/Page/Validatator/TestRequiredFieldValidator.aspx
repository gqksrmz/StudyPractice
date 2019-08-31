<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequiredFieldValidator.aspx.cs" Inherits="Asp.NetDemo1.Page.Validatator.TestRequiredFieldValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<asp:TextBox ID="textName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入用户名" ControlToValidate="textName" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="提交注册" />
        </div>
    </form>
</body>
</html>
