<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBorrowInfo.aspx.cs" Inherits="BookManager.AddBorrowInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>员工面板</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />

    <script src="Content/scripts/boot.js" type="text/javascript"></script>


    <style type="text/css">
        html, body {
            padding: 0;
            margin: 0;
            border: 0;
            height: 100%;
            overflow: hidden;
        }
    </style>
</head>
<body>

    <form id="form1" method="post">
        <input name="id" class="mini-hidden" />
        <div style="height: 60px;"></div>
        <div style="padding-left: 11px; padding-bottom: 5px; height: 100px; margin-left: 20px;">
            <table style="table-layout: fixed;">
                <tr>
                    <td style="width: 80px;">图书名称：</td>
                    <td style="width: 150px;">
                        <input name="bookname" class="mini-textbox" required="true" emptytext="请输入图书名称" />
                    </td>
                    <td style="width: 80px;">借阅标识：</td>
                    <td style="width: 150px;">
                        <input name="useguid" class="mini-textbox" required="true" emptytext="借阅标识" />
                    </td>
                </tr>
                <tr>
                    <td>借阅人：</td>
                    <td style="width: 150px;">
                        <input name="borrowperson" class="mini-textbox" required="true" emptytext="请输入借阅人" />
                    </td>
                    <td>办理人</td>
                    <td>
                        <input name="handler" class="mini-textbox" required="true" emptytext="请输入办理人" />
                    </td>
                </tr>

                <tr>
                    <td>借阅事由：</td>
                    <td>
                        <input name="handler" class="mini-textbox" required="true" emptytext="请输入办理人" />

                    </td>
                    <td>借阅日期：</td>
                    <td>
                        <input name="borrowdate" class="mini-datepicker" required="true" emptytext="请选择日期" />
                    </td>
                </tr>
                <tr>
                    <td>归还日期：</td>
                    <td>
                        <input name="returndate" class="mini-datepicker" required="true" emptytext="请选择日期" />

                    </td>
                    <td>备注：</td>
                    <td>
                        <input name="handler" class="mini-textbox" required="true" emptytext="请输入办理人" />
                    </td>
                </tr>
            </table>
        </div>

        <div style="text-align: center; padding: 10px; margin-top: 30px">
            <a class="mini-button" onclick="onOk" style="width: 60px; margin-right: 20px;">确定</a>
            <a class="mini-button" onclick="onCancel" style="width: 60px;">取消</a>
        </div>
    </form>
</body>
</html>

