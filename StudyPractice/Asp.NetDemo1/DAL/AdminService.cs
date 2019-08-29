using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.NetDemo1
{
    public class AdminService
    {
        public bool AdminLogin(string name,string pwd)
        {
            //模拟从数据库判断
            if (name == "root" && pwd == "root")
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}