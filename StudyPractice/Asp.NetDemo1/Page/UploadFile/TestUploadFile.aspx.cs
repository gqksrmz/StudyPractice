using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page.UploadFile
{
    public partial class TestUploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            //1.判断文件是否存在
            if (!this.fileUpload.HasFile) return;
            //2.获取文件大小，判断是否符合设置要求(变成MB)
            double fileLength = this.fileUpload.FileContent.Length / (1024.0 * 1024.0);
            //3.获取配置文件中上传文件大小的限制
            double limitedLength = Convert.ToDouble(System.Configuration.ConfigurationManager
                .AppSettings["PhysicsObjectLength"]);
            limitedLength = limitedLength / 1024.0;//转换成MB单位
            //4.判断实际文件大小是否符合要求
            if (fileLength > limitedLength)
            {
                //this.litMsg.Text = "上传文件大小不能超过" + limitedLength;
                this.litMsg.Text = "<script type='text/javascript'>alert('上传文件最大不能超过"+limitedLength+"')</script>";
                return;
            }
            //5.获取文件名，判断文件扩展名是否符合要求
            string fileName = this.fileUpload.FileName;
            //6.判断文件名是否是exe文件
            if (fileName.Substring(fileName.LastIndexOf(".")).ToLower() == ".exe")
            {
                this.litMsg.Text = "<script type='text/javascript'>alert('上传文件大小不能是.exe文件')</script>";
                return;
            }
            //7.修改文件名 abc.doc 改成年月日时分秒毫秒_文件名.扩展名
            fileName = DateTime.Now.ToString("yyyyMMddhhssms") + "_" + fileName;
            //8.获取服务器文件夹路径
            string path = Server.MapPath("~/上传的文件");
            //9.上传文件
            try
            {
                this.fileUpload.SaveAs(path + "/" + fileName);
                this.litMsg.Text = "<script type='text/javascript'>alert('文件上传成功！')</script>";

            }
            catch (Exception ex)
            {
                this.litMsg.Text = "<script type='text/javascript'>alert('文件上传失败！"+ex.Message+"')</script>";

            }
        }
    }
}