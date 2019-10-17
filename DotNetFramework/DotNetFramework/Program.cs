using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeOfDay time = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), "afternoon", true);
            //第一个参数是要使用的枚举类型 第二个参数是要转换的字符串，第三个参数是一个bool，指定转换时是否忽略大小写
            Console.ReadLine();
        }
        public enum TimeOfDay
        {
            Morning =0,
            Afternonn=1,
            Evening=2
        }
    }
}
