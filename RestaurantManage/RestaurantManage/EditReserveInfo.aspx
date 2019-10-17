<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditReserveInfo.aspx.cs" Inherits="RestaurantManage.EditReserveInfo" %>

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
        <input name="Status" class="mini-hidden" value="edit" />

        <div style="padding-left: 11px; padding-bottom: 5px; margin-left: 20px;">
            <table style="table-layout: fixed;">
                <tr>
                    <td style="width: 80px;">预定编号：</td>
                    <td style="width: 150px;">
                        <input name="ReserveNo" class="mini-textbox" required="true" emptytext="预约编号" readonly="readonly"/>
                    </td>
                    <td style="width: 80px;">餐桌编号：</td>
                    <td style="width: 150px;">
                        <input name="TableNo" class="mini-combobox" valuefield="TableNo" textfield="TableNo"
                            url=""
                            onvaluechanged="" required="true"
                            emptytext="餐桌类型" readonly="readonly"/>
                    </td>
                </tr>
                <tr>
                    <td>用餐人数：</td>
                    <td>
                        <input name="PeopleNum" class="mini-textbox" emptytext="用餐人数" readonly="readonly"/>
                    </td>
                    <td>用餐开始时间：</td>
                    <td>
                        <input name="StartTime" class="mini-datepicker" required="true" emptytext="请选择日期" renderer="onTimeRenderer" readonly="readonly" format="yyyy-MM-dd HH:mm:ss" showtime="true"/>
                    </td>
                </tr>
                <tr>
                    <td>用餐结束时间：</td>
                    <td>
                        <input name="EndTime" class="mini-datepicker" required="true" emptytext="请选择日期" renderer="onTimeRenderer" readonly="readonly" format="yyyy-MM-dd HH:mm:ss" showtime="true"/>
                    </td>
                    <td>状态：</td>
                    <td>
                        <select name="ReserveStatus" class="mini-radiobuttonlist" >
                            <option value="0">预约中</option>
                            <option value="1">用餐中</option>
                            <option value="2">取消</option>
                        </select>
                    </td>
                </tr>
                 <tr>
                    <td>备注：</td>
                    <td>
                        <input name="Notes" class="mini-textbox"  readonly="readonly"/>
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
                    url: "ReserveInfoService.ashx?action=GetEntityByReserveNo&ReserveNo=" + data.id,
                    cache: false,
                    success: function (text) {
                        var o = mini.decode(text);
                        form.setData(o);
                        var SelectBookType = mini.getByName("Status").setValue("edit");
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
        function onTimeRenderer(e) {
            var value = e.value;
            if (value) return mini.formatDate(value, 'yyyy-MM-dd HH:mm');
            return "";

        }



    </script>
</body>
</html>
