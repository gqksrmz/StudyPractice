<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUploadFile.aspx.cs" Inherits="Asp.NetDemo1.Page.UploadFile.TestUploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请选择你要上传的文件：
            <br />
            <asp:FileUpload ID="fileUpload" runat="server" />
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="开始上传" OnClick="btnUpload_Click" />
            <br />
            <asp:Literal ID="litMsg" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
