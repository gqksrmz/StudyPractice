<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="BookManager.AddBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>员工面板</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    
    <script src="Content/scripts/boot.js" type="text/javascript"></script>
    

    <style type="text/css">
    html, body
    {        
        padding:0;
        margin:0;
        border:0;
        height:100%;
        overflow:hidden;
    }
    </style>
</head>
<body>    
     
    <form id="form1" method="post">
        <input name="id" class="mini-hidden" />
        <div style="padding-left:11px;padding-bottom:5px;">
            <table style="table-layout:fixed;">
                <tr>
                    <td style="width:80px;">员工帐号：</td>
                    <td style="width:150px;">    
                        <input name="loginname" class="mini-textbox" required="true"  emptyText="请输入帐号"/>
                    </td>
                    <td style="width:80px;">所属部门：</td>
                    <td style="width:150px;">    
                        <input name="dept_id" class="mini-combobox" valueField="id" textField="name" 
                            url=""
                            onvaluechanged="onDeptChanged" required="true"
                             emptyText="请选择部门"
                            />
                    </td>
                </tr>
                <tr>
                    <td >薪资待遇：</td>
                    <td >    
                        <input name="salary" class="mini-textbox" required="true"/>
                    </td>
                    <td >职位：</td>
                    <td >    
                        <input name="position" class="mini-combobox" valueField="id" textField="name"/>
                    </td>
                </tr>
               
                <tr>
                    <td >学历：</td>
                    <td >    
                        <input name="educational" class="mini-combobox" valueField="id" textField="name" url="" />
                    </td>
                    <td >毕业院校：</td>
                    <td >    
                        <input name="school" class="mini-textbox" />
                    </td>
                </tr>           
            </table>
        </div>
        <fieldset style="border:solid 1px #aaa;padding:3px;">
            <legend >基本信息</legend>
            <div style="padding:5px;">
        <table>
            <tr>
                <td style="width:80px;">姓名</td>
                <td style="width:150px;">    
                    <input name="name" class="mini-textbox" required="true"/>
                </td>
                <td style="width:80px;">性别：</td>
                <td >                        
                    <select name="gender" class="mini-radiobuttonlist">
                        <option value="1">男</option>
                        <option value="2">女</option>
                    </select>
                </td>
                
            </tr>
            <tr>
                <td >年龄：</td>
                <td >    
                    <input name="age" class="mini-spinner" value="25" minValue="1" maxValue="200" />
                </td>
                <td >出生日期：</td>
                <td >    
                    <input name="birthday" class="mini-datepicker" required="true" emptyText="请选择日期"/>
                </td>
            </tr>
            <tr>
                <td ></td>
                <td >    
                    <input name="married" class="mini-checkbox" text="已婚？" trueValue="1" falseValue="0" />
                </td>
                <td ></td>
                <td >    
                    
                </td>
            </tr>     
            <tr>
                <td >国家：</td>
                <td >    
                    <input name="country" class="mini-combobox" url="" />
                </td>
                <td >城市：</td>
                <td >    
                    <input name="city" class="mini-combobox"  />
                </td>
            </tr>
            <tr>
                <td >备注：</td>
                <td colspan="3">    
                    <input name="remarks" class="mini-textarea" style="width:386px;" />
                </td>
            </tr>          
        </table>            
            </div>
        </fieldset>
        <div style="text-align:center;padding:10px;">               
            <a class="mini-button" onclick="onOk" style="width:60px;margin-right:20px;">确定</a>       
            <a class="mini-button" onclick="onCancel" style="width:60px;">取消</a>       
        </div>        
    </form>
</body>
</html>
