<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWidget2.aspx.cs" Inherits="Asp.NetDemo1.Page.Widget.TestWidget2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="普通按钮" OnClick="Button1_Click" />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">这是一个超链接按钮</asp:LinkButton>
            <br />
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Content/316-1F51R02232-50.jpg" OnClick="ImageButton1_Click" Width="100px" />
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" Text="男" GroupName="Gender"/>
            <asp:RadioButton ID="RadioButton1" runat="server" Text="女" GroupName="Gender"/>
            <br />
            <asp:HyperLink ID="HyperLink1" NavigateUrl="https://www.baidu.com" runat="server">这个是超链接控件</asp:HyperLink>
            <br />
            <asp:Button ID="Button2" runat="server" Text="改变链接地址" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
