<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Asp.NetDemo1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" action="Handlers/LoginHandler.ashx" method="post">
        <div>
            用户名:<input type="text" name="uname" />
            密码:<input type="password" name="uPwd" />
            <input type="submit" name="btnSubmit" value="登录" />
        </div>
    </form>
</body>
</html>
