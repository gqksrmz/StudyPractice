<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTransfer.aspx.cs" Inherits="Asp.NetDemo1.Page.Server.TestTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnTransfer" runat="server" Text="使用Server.Transfer()跳转到新页面" OnClick="btnTransfer_Click" />
            <br />
            <asp:Button ID="btnRedirect" runat="server" Text="使用Respnse.Redirect()跳转到新页面" OnClick="btnRedirect_Click" />

        </div>
    </form>
</body>
</html>
