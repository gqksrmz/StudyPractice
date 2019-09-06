<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllBook.aspx.cs" Inherits="BookManager.AllBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>图书管理</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <%--<link href="Content/css/demo.css" rel="stylesheet" type="text/css" />--%>

    <script src="Content/scripts/boot.js" type="text/javascript"></script>
    <%--  <script src="Content/js/ColumnsMenu.js" type="text/javascript"></script>--%>
</head>
<body>
    <h1>图书管理</h1>

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
                        <input name="SelectBookType" class="mini-combobox" valuefield="id" textfield="text"
                            url="Data/booktype.Json"
                            onvaluechanged="" emptytext="请选择图书类别" />
                                                <input name="BeginDate" class="mini-datepicker" required="true" emptytext="请选择日期" />
                        <input name="EndDate" class="mini-datepicker" required="true" emptytext="请选择日期" />
                        <a class="mini-button" onclick="search()">查询</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="datagrid1" class="mini-datagrid" style="width: 1100px; height: 350px;" allowresize="true"
        url="AjaxService.aspx?method=SearchAllBook" idfield="id" multiselect="true">
        <div property="columns">
            <!--<div type="indexcolumn"></div>        -->
            <div type="checkcolumn"></div>
            <div field="BookGuid" width="120" headeralign="center" allowsort="true">图书编号</div>
            <div field="BookName" width="120" headeralign="center" allowsort="true">图书名称</div>
            <div field="BookType" width="120" headeralign="center" allowsort="true" renderer="onBookTypeRenderer">图书类别</div>
            <div field="SuitAble" width="120" headeralign="center" allowsort="true" renderer="onSuitableRenderer">适合人群</div>
            <div field="BuyDate" width="120" headeralign="center" allowsort="true" renderer="onBuyDateRenderer">入库日期</div>
            <div field="Count" width="120" headeralign="center" allowsort="true" renderer="oncountrenderer">借阅次数</div>
            <div field="Remark" width="120" headeralign="center" allowsort="true">备注</div>
        </div>
    </div>


    <script type="text/javascript">
        mini.parse();

        var grid = mini.get("datagrid1");
        grid.load();


        function add() {

            mini.open({
                targetWindow: window,

                url: "AddBook.aspx",
                title: "新增图书", width: 600, height: 400,
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
                    url: "EditBookInfo.aspx",
                    title: "编辑图书", width: 600, height: 400,
                    onload: function () {
                        var iframe = this.getIFrameEl();
                        var data = { action: "edit", id: row.BookGuid };
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
                        ids.push(r.BookGuid);
                    }
                    var id = ids.join(',');
                    grid.loading("操作中，请稍后......");
                    $.ajax({
                        url: "AjaxService.aspx?method=RemoveBook&bookGuid=" + id,
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
        function search() {
            var key = mini.get("key").getValue();
            grid.load({ key: key });
        }
        function onBookTypeRenderer(e) {
            if (e.value == "1") {
                return "电子科技";
            } else if (e.value = "2") {
                return "人文生活";
            } else if (e.value = "3") {
                return "时尚周刊";
            } else if (e.value = "4") {
                return "艺术鉴赏";
            }
        }
        function onSuitableRenderer(e) {
            if (e.value == "1") {
                return "老年人";
            } else if (e.value == "2") {
                return "青年人";
            }
            else if (e.value == "3") {
                return "儿童";
            }
        }
        function oncountrenderer(e) {
            if (e.value > 10) {
                e.rowStyle = 'color:red;';

            } else {
                e.rowStyle = 'color:green;';
            }
            return e.value

        }
        function onBuyDateRenderer(e) {
            var value = e.value;
            if (value) return mini.formatDate(value, 'yyyy-MM-dd');
            return "";

        }
    </script>
</body>
</html>
