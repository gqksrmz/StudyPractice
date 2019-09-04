<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="BookManager.AddBook" %>

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
        <div style="height:60px;"></div>
        <div style="padding-left: 11px; padding-bottom: 5px; height:100px; margin-left:20px;">
            <table style="table-layout: fixed;">
                <tr>
                    <td style="width: 80px;">图书名称：</td>
                    <td style="width: 150px;">
                        <input name="bookname" class="mini-textbox" required="true" emptytext="请输入图书名称" />
                    </td>
                    <td style="width: 80px;">图书类别：</td>
                    <td style="width: 150px;">
                        <input name="booktype" class="mini-combobox" valuefield="id" textfield="name"
                            url=""
                            onvaluechanged="onBookTypeChanged" required="true"
                            emptytext="请选择图书类别" />
                    </td>
                </tr>
                <tr>
                    <td>适合人群：</td>
                    <td>
                        <select name="suitable" class="mini-radiobuttonlist">
                            <option value="1">老年人</option>
                            <option value="2">青年人</option>
                            <option value="3">儿童</option>
                        </select>
                    </td>
                    <td>入库日期</td>
                    <td>
                        <input name="buydate" class="mini-datepicker" required="true" emptytext="请选择日期" />
                    </td>
                </tr>

                <tr>
                    <td>借阅次数：</td>
                    <td>
                        <input name="count" class="mini-textbox" valuefield="id" textfield="name" url="" />
                    </td>
                    <td>备注：</td>
                    <td>
                        <input name="remark" class="mini-textbox" />
                    </td>
                </tr>
            </table>
        </div>
        
        <div style="text-align: center; padding: 10px;">
            <a class="mini-button" onclick="onOk" style="width: 60px; margin-right: 20px;">确定</a>
            <a class="mini-button" onclick="onCancel" style="width: 60px;">取消</a>
        </div>
    </form>
</body>
</html>
