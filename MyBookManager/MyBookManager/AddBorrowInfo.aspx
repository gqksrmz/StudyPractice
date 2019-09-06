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
        <%--<input name="id" class="mini-hidden" />--%>
        <div style="height: 60px;"></div>
        <div style="padding-left: 11px; padding-bottom: 5px; height: 100px; margin-left: 20px;">
            <table style="table-layout: fixed;">
                <tr>
                    <td style="width: 80px;">图书名称：</td>
                    <td style="width: 150px;">
                        <input name="BookName" class="mini-combobox" valuefield="BookName" textfield="BookName"
                            url="AjaxService.aspx?method=GetAllBookWithoutPaging"
                            onvaluechanged="" required="true"
                            emptytext="请选择图书" />
                    </td>
                    <td>借阅人：</td>
                    <td style="width: 150px;">
                        <input name="BorrowPerson" class="mini-textbox" required="true" emptytext="请输入借阅人" />
                    </td>
                </tr>
                <tr>
                    <td>办理人</td>
                    <td>
                        <input name="Handler" class="mini-textbox" required="true" emptytext="请输入办理人" />
                    </td>
                    <td>借阅事由：</td>
                    <td>
                        <input name="BorrowCause" class="mini-textbox" required="true" emptytext="请输入借阅事由" />
                    </td>
                </tr>
                <tr>
                    <td>借阅日期：</td>
                    <td>
                        <input name="BorrowDate" class="mini-datepicker" required="true" emptytext="请选择日期" minDate="2019-09-06"/>
                    </td>
                    <td>归还日期：</td>
                    <td>
                        <input name="ReturnDate" class="mini-datepicker" required="true" emptytext="请选择日期"  minDate="2019-09-06"/>
                    </td>
                </tr>
                <tr>
                    <td>备注：</td>
                    <td colspan="3">
                        <input name="Remark" class="mini-textbox" required="true" />
                    </td>
                </tr>
            </table>
        </div>

        <div style="text-align: center; padding: 10px; margin-top: 30px">
            <a class="mini-button" onclick="onOk" style="width: 60px; margin-right: 20px;">确定</a>
            <a class="mini-button" onclick="onCancel" style="width: 60px;">取消</a>
        </div>
    </form>
    <script type="text/javascript">
        mini.parse();


        var form = new mini.Form("form1");

        function SaveData() {
            saveForm(form, {
                url: "AjaxService.aspx?method=SaveBorrowInfo",
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
      



    </script>
</body>
</html>

