<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Asp.NetDemo1.Page.ShoppingCart.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:CheckBox ID="ckbProduct1" runat="server" Text="衬衣" />
            <br />
            <asp:CheckBox ID="ckbProduct2" runat="server" Text="帽子" />
            <br />
            <asp:CheckBox ID="ckbProduct3" runat="server" Text="手套" />
            <br />
            <asp:CheckBox ID="ckbProduct4" runat="server" Text="外套" />
            <br />
            <asp:CheckBox ID="ckbProduct5" runat="server" Text="裤子" />
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="将所选择的商品添加到购物车" OnClick="btnAdd_Click" />
            <asp:Button ID="btnShow" runat="server" Text="显示购物车" OnClick="btnShow_Click" />
        </div>
    </form>
</body>
</html>
