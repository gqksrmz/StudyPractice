<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWidget1.aspx.cs" Inherits="Asp.NetDemo1.Page.Widget.TestWidget" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="textName" type="text" />
            <br />
            <input id="textID" type="text" runat="server" />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label">这个是Label控件</asp:Label>
        <asp:Literal ID="Literal1" runat="server">这个是Literal控件</asp:Literal>
        <br />
        <asp:TextBox ID="textConent1" runat="server" AutoPostBack="True" OnTextChanged="textConent1_TextChanged"></asp:TextBox>
        <br />
        <asp:TextBox ID="textConent2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:TextBox ID="textConent3" runat="server"  TextMode="MultiLine" ></asp:TextBox>
        <asp:HiddenField ID="HiddenField1" runat="server" value="这里是隐藏域传递的值"/>
    </form>
</body>
</html>
