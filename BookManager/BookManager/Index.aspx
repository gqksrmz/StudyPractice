﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BookManager.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>系统界面 OutlookMenu</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" /><link href="ontent/css/demo.css" rel="stylesheet" type="text/css" />
    <script src="Content/scripts/boot.js" type="text/javascript"></script> 
    
    <style type="text/css">
    body{
        margin:0;padding:0;border:0;width:100%;height:100%;overflow:hidden;
    }    
    /*.header
    {
        background:url(../header.gif) repeat-x 0 -1px;
    }*/
    .Note
    {
        background:url(Notes_Large.png) no-repeat;width:32px;height:32px;
    }
    .Reports
    {
        background:url(Reports_Large.png) no-repeat;width:32px;height:32px;
    }

    
    </style>    
</head>
<body >   

<div id="layout1" class="mini-layout" style="width:100%;height:100%;">
    <div class="app-header" region="north" height="70" showSplit="false" showHeader="false">
        <h1 style="margin:0;padding:15px;cursor:default;font-family:'Trebuchet MS',Arial,sans-serif;">图书管理系统</h1>
    </div>
    <div title="south" region="south" showSplit="false" showHeader="false" height="30" >
        <div style="line-height:28px;text-align:center;cursor:default">Copyright © 上海普加软件有限公司版权所有 </div>
    </div>
    <div showHeader="false" region="west" width="180" maxWidth="250" minWidth="100" >
        <!--OutlookMenu-->
        <div id="leftTree" class="mini-outlookmenu" url="Data/outlookmenu.txt" onitemselect="onItemSelect"
            idField="id" parentField="pid" textField="text" borderStyle="border:0" expandOnLoad="false"
        >
        </div>

    </div>
    <div title="center" region="center" bodyStyle="overflow:hidden;">
        <iframe id="mainframe" frameborder="0" name="main" style="width:100%;height:100%;" border="0"></iframe>
    </div>
</div>
    
    <script type="text/javascript">
        mini.parse();

        //init iframe src
        var iframe = document.getElementById("mainframe");
        iframe.src = "../datagrid/datagrid.html"

        function onItemSelect(e) {
            var item = e.item;
            iframe.src = item.url;
        }

//        //自动选中id
//        var tree = mini.get("leftTree");
//        
//        tree.selectNode("addRight");
    </script>

</body>
</html>
