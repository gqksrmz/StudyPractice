﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllTableInfo.aspx.cs" Inherits="RestaurantManage.AllTableInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>餐桌信息管理</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <%--<link href="Content/css/demo.css" rel="stylesheet" type="text/css" />--%>

    <script src="Content/scripts/boot.js" type="text/javascript"></script>
    <%--  <script src="Content/js/ColumnsMenu.js" type="text/javascript"></script>--%>
</head>
<body>
    <h1>餐桌信息管理</h1>

    <div style="width: 1100px;">
        <div class="mini-toolbar" style="border-bottom: 0; padding: 0px;">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 100%;">
                        <a class="mini-button" iconcls="icon-add" onclick="add()">增加</a>
                        <a class="mini-button" iconcls="icon-remove" onclick="remove()">删除</a>
                    </td>
                    <td style="white-space: nowrap;">
                        <input name="SearchHoldNum" class="mini-combobox" valuefield="id" textfield="text"
                            url="Data/holdnum.Json"
                            onvaluechanged="" required="true"
                            emptytext="请选择餐桌类型" />
                        <input name="SearchIsUse" class="mini-combobox" valuefield="id" textfield="text"
                            url="Data/isuse.Json"
                            onvaluechanged="" required="true"
                            emptytext="是否使用中" />
                        <a class="mini-button" onclick="search()">查询</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="datagrid1" class="mini-datagrid" style="width: 1100px; height: 350px;" allowresize="true"
        url="TableInfoService.ashx?action=SearchAllTable" idfield="id" multiselect="true">
        <div property="columns">
            <div type="indexcolumn"></div>
            <div type="checkcolumn"></div>
            <div field="TableNo" width="120" headeralign="center">餐桌编号</div>
            <div field="HoldNum" width="120" headeralign="center" renderer="onHoldNumRenderer">餐桌类型</div>
            <div field="IsUse" width="120" headeralign="center" renderer="onIsUseRender">是否使用中</div>
            <div field="Notes" width="120" headeralign="center">备注</div>
            <div field="Operation" width="120" headeralign="center" renderer="onActionRenderer">操作</div>

        </div>
    </div>


    <script type="text/javascript">
        mini.parse();

        var grid = mini.get("datagrid1");
        grid.load();


        function add() {

            mini.open({
                targetWindow: window,

                url: "AddTableInfo.aspx",
                title: "新增餐桌", width: 600, height: 400,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    var data = { action: "added" };
                    iframe.contentWindow.SetData(data);
                },
                ondestroy: function (action) {
                    grid.reload();
                }
            });
        }
        function remove() {

            var rows = grid.getSelecteds();
            if (rows.length > 0) {
                if (confirm("确定删除选中记录？")) {
                    var ids = [];
                    for (var i = 0, l = rows.length; i < l; i++) {
                        var r = rows[i];
                        ids.push(r.TableNo);
                    }
                    var id = ids.join(',');
                    grid.loading("操作中，请稍后......");
                    $.ajax({
                        url: "TableInfoService.ashx?action=RemoveTableInfo&TableNo=" + id,
                        success: function (text) {
                            mini.alert("提交成功！" + text);
                            grid.reload();
                        },
                        error: function () {
                        }
                    });
                }
            } else {
                alert("请选中一条记录");
            }
        }
        function onIsUseRender(e) {
            if (e.value == 0) {
                e.rowStyle = 'color:green;';
                return "否";
            } else if (e.value == 1) {
                return "是";
            }
        }
        function onHoldNumRenderer(e) {
            if (e.value == 2) {
                return "二人桌";
            }
            else if (e.value ==4) {
                return "四人桌";
            }
            else if (e.value == 6) {
                return "六人桌"
            }

        }

        function search() {
            var SearchHoldNum = mini.getByName("SearchHoldNum").getValue();
            var SearchIsUse = mini.getByName("SearchIsUse").getValue();
            grid.load({ SearchHoldNum: SearchHoldNum, SearchIsUse: SearchIsUse });
        }
        function onActionRenderer(e) {
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;

            var s = '<a class="Delete_Button" href="javascript:remove(\'' + uid + '\')">删除</a> ';
            return s;
        }
    </script>
</body>
</html>
