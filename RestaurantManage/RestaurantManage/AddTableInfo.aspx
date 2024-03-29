﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTableInfo.aspx.cs" Inherits="RestaurantManage.AddTableInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>餐桌信息列表</title>
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
                    <td style="width: 80px;">餐桌标号：</td>
                    <td style="width: 150px;">
                        <input name="TableNo" class="mini-textbox" required="true" emptytext="请输入餐桌标号" readonly="readonly" />
                    </td>
                    <td style="width: 80px;">餐桌类型：</td>
                    <td style="width: 150px;">
                        <input name="HoldNum" class="mini-combobox" valuefield="id" textfield="text"
                            url="Data/holdnum.Json"
                            onvaluechanged="onHoldNumChanged" required="true"
                            emptytext="请选择餐桌类型" />
                    </td>
                </tr>
                <tr>
                    <td>是否使用中：</td>
                    <td>
                        <select name="IsUse" class="mini-radiobuttonlist" onvaluechanged="onIsUseChanged">
                            <option value="0" selected="selected">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                    <tr>
                        <td>备注：</td>
                        <td colspan="3">
                            <input name="Notes" class="mini-textarea" style="width: 386px;" required="true"/>
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
                if (mini.confirm("数据被修改了，是否先保存？")) {
                    return false;
                }
            }
            if (window.CloseOwnerWindow) return window.CloseOwnerWindow(action);
            else window.close();
        }
        function onOk(e) {
            var form = new mini.Form("form1");
            var data = form.getData();
            var json = mini.encode(data);
            $.ajax({
                url: "TableInfoService.ashx?action=SaveTableInfo",
                type: "post",
                data: {data:json},
                success: function (text) {
                    if (mini.confirm("提交成功，返回结果" + text)) {
                        CloseWindow("save");
                    }
                    else {
                        return false;
                    }

                }
            });
        }
        function onCancel(e) {
            CloseWindow("cancel");
        }
        function onHoldNumChanged() {
            var json = mini.getByName("HoldNum").getValue();
            $.ajax({
                url: "TableInfoService.ashx?action=ShowNo",
                data: { data: json },
                type: "post",
                success: function (text) {
                    var s = mini.getByName("TableNo").setValue(text);
                }

            });
        }
        function onIsUseChanged() {
            var s = mini.getByName("IsUse").setValue(0);
        }


    </script>
</body>
</html>
