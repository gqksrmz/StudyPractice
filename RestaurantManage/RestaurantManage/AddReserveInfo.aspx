<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReserveInfo.aspx.cs" Inherits="RestaurantManage.AddReserveInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>预约信息列表</title>
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
        <input name="Status" class="mini-hidden" value="added" />
        <div style="padding-left: 11px; padding-bottom: 5px; margin-left: 20px;">
            <table style="table-layout: fixed;">
                <tr>
                    <td style="width: 80px;">用餐编号：</td>
                    <td style="width: 150px;">
                        <input name="ReserveNo" class="mini-textbox" required="true" emptytext="请输入预定标号" readonly="readonly" />
                    </td>
                    <td style="width: 80px;">餐桌编号：</td>
                    <td style="width: 150px;">
                        <input name="TableNo" class="mini-combobox" valuefield="TableNo" textfield="TableNo"
                            url=""
                            onvaluechanged="" required="true"
                            emptytext="餐桌类型" />
                    </td>
                </tr>
                <tr>
                    <td>用餐人数：</td>
                    <td>
                        <input name="PeopleNum" class="mini-textbox" emptytext="请输入用餐人数" onvaluechanged="onPeopleNumChanged" />
                    </td>
                    <td>用餐开始时间：</td>
                    <td>
                        <input name="StartTime" class="mini-datepicker" required="true" emptytext="请选择日期" format="yyyy-MM-dd HH:mm:ss" showtime="true" showokbutton="true"/>
                    </td>
                </tr>
                <tr>
                    <td>用餐结束时间：</td>
                    <td>
                        <input name="EndTime" class="mini-datepicker" required="true" emptytext="请选择日期" format="yyyy-MM-dd HH:mm:ss" showtime="true"showokbutton="true" />
                    </td>
                    <td>状态：</td>
                    <td>
                        <select name="ReserveStatus" class="mini-radiobuttonlist" onvaluechanged="onReserveStateChanged">
                            <option value="0" selected="selected">预约中</option>
                            <option value="1">用餐中</option>
                            <option value="2">取消</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>备注：</td>
                    <td>
                        <input name="Notes" class="mini-textbox" />
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
        $.ajax({
            url: "ReserveInfoService.ashx?action=ShowNo",
            data: {},
            type: "post",
            success: function (text) {
                var s = mini.getByName("ReserveNo").setValue(text);
            }

        });

        function SaveData() {
            saveForm(form, {
                url: "ReserveInfoService.ashx?action=SaveReserveInfo",
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
        function onReserveStateChanged() {
            var s = mini.getByName("ReserveStatus").setValue(0);
        }
        function onPeopleNumChanged() {
            var s = mini.getByName("PeopleNum").getValue();
            if (s > 6 || s < 0 || s == 0) {
                mini.alert("输入错误");
                mini.getByName("PeopleNum").setValue("");
            }
            else {
                if (s > 0 && s <= 2) {
                    s = 2;
                } else if (s > 2 && s <= 4) {
                    s = 4;
                } else if (s > 4 && s <= 6) {
                    s = 6;
                }
                $.ajax({
                    url: "ReserveInfoService.ashx?action=ShowTable",
                    data: { data: s },
                    type: "post",
                    success: function (data) {
                        mini.getByName("TableNo").setValue(data);
                    }

                });
            }
            


        }


    </script>
</body>
</html>
