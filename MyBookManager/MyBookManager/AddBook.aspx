<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="BookManager.AddBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>图书列表</title>
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
        <input name="bookguid" class="mini-hidden" />
        <div style="padding-left: 11px; padding-bottom: 5px;  margin-left: 20px;">
            <table style="table-layout: fixed;">
                <tr>
                    <td style="width: 80px;">图书名称：</td>
                    <td style="width: 150px;">
                        <input name="bookname" class="mini-textbox" required="true" emptytext="请输入图书名称" />
                    </td>
                    <td style="width: 80px;">图书类别：</td>
                    <td style="width: 150px;">
                        <input name="booktype" class="mini-combobox" valuefield="id" textfield="text"
                            url="Data/booktype.Json"
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
    <script type="text/javascript">
        mini.parse();


        var form = new mini.Form("form1");

        function SaveData() {
            saveForm(form, {
                url: "AjaxService.aspx?method=SaveBooks",
                callback: function (success) {
                    if (success) CloseWindow("save");
                    else CloseWindow();
                }
            });
        }

        ////////////////////
        //标准方法接口定义
        function SetData(data) {
            if (data.action == "edit") {
                //跨页面传递的数据对象，克隆后才可以安全使用
                data = mini.clone(data);

                $.ajax({
                    url: "AjaxService.aspx?method=GetBook&id=" + data.id,
                    cache: false,
                    success: function (text) {
                        var o = mini.decode(text);
                        form.setData(o);
                        form.setChanged(false);

                        onDeptChanged();
                        mini.getbyName("position").setValue(o.position);
                    }
                });
            }
        }

        function GetData() {
            var o = form.getData();
            return o;
        }
        function CloseWindow(action) {
            if (action == "close" && form.isChanged()) {
                if (confirm("数据被修改了，是否先保存？")) {
                    return false;
                }
            }
            if (window.CloseOwnerWindow) return window.CloseOwnerWindow(action);
            else window.close();
        }
        function onOk(e) {
            SaveData();
        }
        function onCancel(e) {
            CloseWindow("cancel");
        }
        //////////////////////////////////
        function onBookChanged(e) {
            var bookTypeCombox = mini.getbyName("booktype");
            var bookTypeId = bookTypeCombox.getValue();

            bookTypeCombox.setValue(bookTypeId);
        }



    </script>
</body>
</html>
