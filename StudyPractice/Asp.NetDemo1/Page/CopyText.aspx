<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CopyText.aspx.cs" Inherits="Asp.NetDemo1.Page.CopyText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="textOld" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCopy" runat="server" Text="复制文字到第二个文本框" OnClick="btnCopy_Click" />
            <br />
            <asp:TextBox ID="textNew" runat="server"></asp:TextBox>

        </div>
    </form>
</body>
</html>
