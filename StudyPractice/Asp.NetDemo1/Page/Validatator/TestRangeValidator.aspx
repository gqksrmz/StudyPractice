<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRangeValidator.aspx.cs" Inherits="Asp.NetDemo1.Page.Validatator.TestRangeValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            学员体重：<asp:TextBox ID="textWeight" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textWeight" Display="Dynamic" ErrorMessage="请输入体重！" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="textWeight" Display="Dynamic" ErrorMessage="学员体重必须在50-100之前！" ForeColor="Red" MaximumValue="100" MinimumValue="50" Type="Double"></asp:RangeValidator>
            <br />
            出生日期：<asp:TextBox ID="textBirthday" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textBirthday" Display="Dynamic" ErrorMessage="请输入出生日期！" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="textBirthday" Display="Dynamic" ErrorMessage="出生日期必须在1990-1-1到2000-1-1" ForeColor="Red" MaximumValue="2000-1-1" MinimumValue="1990-1-1" Type="Date"></asp:RangeValidator>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="提交注册" />
        </div>
    </form>
</body>
</html>
