using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class BaseService
    {

        protected HttpRequest Request;
        protected HttpResponse Response;
        public BaseService(HttpRequest Request,HttpResponse Response)
        {
            this.Request = Request;
            this.Response = Response;
        }
        public String GetString(String name)
        {
            return Request[name];
        }
        public int GetInt(String name)
        {
            return Convert.ToInt32(GetString(name));
        }
        public bool GetBoolean(String name)
        {
            return Convert.ToBoolean(GetString(name));
        }
        public DateTime GetDateTime(string name)
        {

            return Convert.ToDateTime(GetString(name));
        }
        public Object GetObject(String name)
        {
            return JSON.Decode(GetString(name));
        }
        public void RenderJson(Object obj)
        {
            String json = JSON.Encode(obj);
            Response.Write(json);
        }
        public void RenderText(String text)
        {
            Response.Write(text);
        }
    }
}
