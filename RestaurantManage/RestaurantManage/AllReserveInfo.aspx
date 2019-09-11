<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllReserveInfo.aspx.cs" Inherits="RestaurantManage.AllReserveInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>预约信息管理</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <%--<link href="Content/css/demo.css" rel="stylesheet" type="text/css" />--%>

    <script src="Content/scripts/boot.js" type="text/javascript"></script>
    <%--  <script src="Content/js/ColumnsMenu.js" type="text/javascript"></script>--%>
</head>
<body>
    <h1>预约信息管理</h1>

    <div style="width: 1100px;">
        <div class="mini-toolbar" style="border-bottom: 0; padding: 0px;">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 100%;">
                        <a class="mini-button" iconcls="icon-add" onclick="add()">增加</a>
                        <a class="mini-button" iconcls="icon-add" onclick="edit()">编辑</a>
                        <a class="mini-button" iconcls="icon-remove" onclick="remove()">删除</a>
                    </td>
                    <td style="white-space: nowrap;">
                        <input name="Count" class="mini-textbox" valuefield="id" textfield="name" url="" emptytext="请输入查询内容" />
                        <a class="mini-button" onclick="search()">查询</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="datagrid1" class="mini-datagrid" style="width: 1100px; height: 350px;" allowresize="true"
        url="ReserveInfoService.ashx?action=SearchAllReserve" idfield="id" multiselect="true">
        <div property="columns">
            <div type="checkcolumn"></div>
            <%--<div type="indexcolumn"></div>--%>
            <div field="ReserveNo" width="120" headeralign="center">预定编号</div>
            <div field="TableNo" width="120" headeralign="center" renderer="">餐桌编号</div>
            <div field="PeopleNum" width="120" headeralign="center" renderer="">用餐人数</div>
            <div field="StartTime" width="120" headeralign="center" renderer="onTimeRenderer">用餐开始时间</div>
            <div field="EndTime" width="120" headeralign="center" renderer="onTimeRenderer">用餐用餐结束时间</div>
            <div field="ReserveStatus" width="120" headeralign="center" renderer="onStatusRenderer">状态</div>
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

                url: "AddReserveInfo.aspx",
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

        function edit() {

            var row = grid.getSelected();
            if (row) {
                mini.open({
                    targetWindow: window,
                    url: "EditReserveInfo.aspx",
                    title: "编辑餐桌信息", width: 600, height: 400,
                    onload: function () {
                        var iframe = this.getIFrameEl();
                        var data = { action: "edit", id: row.ReserveNo };
                        iframe.contentWindow.SetData(data);
                    },
                    ondestroy: function (action) {
                        //var iframe = this.getIFrameEl();
                        grid.reload();
                    }
                });

            } else {
                alert("请选中一条记录");
            }

        }
        function remove() {

            var rows = grid.getSelecteds();
            if (rows.length > 0) {
                if (confirm("确定删除选中记录？")) {
                    var ids = [];
                    for (var i = 0, l = rows.length; i < l; i++) {
                        var r = rows[i];
                        ids.push(r.ReserveNo);
                    }
                    var id = ids.join(',');
                    grid.loading("操作中，请稍后......");
                    $.ajax({
                        url: "ReserveInfoService.ashx?action=RemoveReserveInfo&ReserveNo=" + id,
                        success: function (text) {
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
                return "否";
            } else if (e.value = 1) {
                return "是";
            }
        }
        function onTableTypeRender(e) {
            if (e.value == 2) {
                return "二人桌";
            } else if (e.value = 4) {
                return "四人桌";
            } else if (e.value = 6) {
                return "六人桌";
            }
        }

        function search() {
            var SelectBookType = mini.getByName("SelectBookType").getValue();
            var BeginDate = mini.formatDate(mini.getByName("BeginDate").getValue(), 'yyyy-MM-dd HH:mm:ss');
            var EndDate = mini.formatDate(mini.getByName("EndDate").getValue(), 'yyyy-MM-dd HH:mm:ss');
            grid.load({ SelectBookType: SelectBookType, BeginDate: BeginDate, EndDate: EndDate });
        }
        function onTimeRenderer(e) {
            var value = e.value;
            if (value) return mini.formatDate(value, 'yyyy-MM-dd HH:mm');
        }
        var tableType = [{ id: 0, text: "预约中" },
        { id: 1, text: "用餐中" },
        { id: 2, text: "取消" }];
        function onStatusRenderer(e) {
            for (var i = 0, l = tableType.length; i < l; i++) {
                var d1 = e.row.StartTime;
                var d2 = new Date();
                var g = tableType[i];
                if (((d2 - d1) / (1000 * 60)) > 15&& e.value == 0) {
                    e.rowStyle = 'background:yellow';
                    return "预约中";
                } else if (e.value == 0) {
                    return "预约中";
                } else if (e.value = 1) {
                    return "用餐中";
                } else if (e.value = 2) {
                    return "取消";
                }
            }

            //var t1 = mini.getByName("Time").getValue()
            //var t2 = mini.getByName("EndTime").getValue()
            //var d1 = t1.replace(/\-/g, "/");
            //var d2 = t2.replace(/\-/g, "/");
            //var date1 = new Date(d1); 
            //var date2 = new Date(d2);
            //var date3 = date2.getTime() - date1.getTime(); //时间差秒
            //var leave1 = date3 % (24 * 3600 * 1000); //计算天数后剩余的毫秒数
            //var leave2 = leave1 % (3600 * 1000);        //计算小时数后剩余的毫秒数
            //var minutes = Math.floor(leave2 / (60 * 1000));

            //if (minutes>15&&e.value==0) {
            //    e.rowStyle = 'color:yellow;';
            //    return e.value;
            //} 
        }
        function onActionRenderer(e) {
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;

            var s = '<a class="Edit_Button" href="javascript:edit(\'' + uid + '\')">修改</a> '
                + '<a class="Delete_Button" href="javascript:remove(\'' + uid + '\')">删除</a> ';
            return s;
        }
    </script>
</body>
</html>
