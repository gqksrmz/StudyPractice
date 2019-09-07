<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookLendManager.aspx.cs" Inherits="BookManager.Data.BookLendManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>图书借阅管理</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="Content/css/demo.css" rel="stylesheet" type="text/css" />

    <script src="Content/scripts/boot.js" type="text/javascript"></script>
    <script src="Content/js/ColumnsMenu.js" type="text/javascript"></script>

</head>
<body>
    <h1>图书借阅管理</h1>      

    <div style="width:1100px;">
        <div class="mini-toolbar" style="border-bottom:0;padding:0px;">
            <table style="width:100%;">
                <tr>
                    <td style="width:100%;">
                        <a class="mini-button" iconCls="icon-add" onclick="add()">增加</a>
                        <a class="mini-button" iconCls="icon-add" onclick="edit()">编辑</a>
                        <a class="mini-button" iconCls="icon-remove" onclick="remove()">删除</a>       
                    </td>
                    <td style="white-space:nowrap;">
                        <input id="key" class="mini-textbox" emptyText="请输入图书名称" style="width:150px;" onenter="onKeyEnter"/>   
                        <a class="mini-button" onclick="search()">查询</a>
                    </td>
                </tr>
            </table>           
        </div>
    </div>
    <div id="datagrid1" class="mini-datagrid" style="width:1100px;height:350px;" allowResize="true"
        url="AjaxService.aspx?method=SearchAllBorrowInfo"  idField="id" multiSelect="true" 
    >
        <div property="columns">
            <!--<div type="indexcolumn"></div>        -->
            <div type="checkcolumn" ></div>        
            <div field="BookName" width="120" headerAlign="center" allowSort="true">图书名称</div>    
            <div field="UseGuid" width="120" headerAlign="center" allowSort="true">借阅标识</div>    
            <div field="BorrowPerson" width="120" headerAlign="center" allowSort="true">借阅人</div>    
            <div field="Handler" width="120" headerAlign="center" allowSort="true">办理人</div>    
            <div field="BorrowCause" width="120" headerAlign="center" allowSort="true" >借阅事由</div>    
            <div field="BorrowDate" width="120" headerAlign="center" allowSort="true" renderer="onDateRenderer">借阅时间</div>    
            <div field="ReturnDate" width="120" headerAlign="center" allowSort="true" renderer="onDateRenderer">归还日期</div>    
            <div field="Remark" width="120" headerAlign="center">备注</div> 
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

                url:  "AddBorrowInfo.aspx",
                title: "新增借阅信息", width: 600, height: 400,
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
                    url:"EditBorrowInfo.aspx",
                    title: "编辑借阅信息", width: 600, height: 400,
                    onload: function () {
                        var iframe = this.getIFrameEl();
                        var data = { action: "edit", id: row.UseGuid };
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
                        ids.push(r.UseGuid);
                    }
                    var id = ids.join(',');
                    grid.loading("操作中，请稍后......");
                    $.ajax({
                        url: "AjaxService.aspx?method=RemoveBorrowInfo&useGuid=" +id,
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
        function onKeyEnter(e) {
            search();
        }
       
        function onDateRenderer(e) {
            var value = e.value;
            if (value) return mini.formatDate(value, 'yyyy-MM-dd');
            return "";

        }
        function search() {
            var key = mini.get("key").getValue();
            grid.load({ key: key });
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