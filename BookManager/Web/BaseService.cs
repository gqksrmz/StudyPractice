using Plusoft.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web
{
    public class BaseService
    {
        protected HttpRequest Request;
        protected HttpResponse Response;
        public BaseService(HttpRequest Request, HttpResponse Response)
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
        public DateTime GetDateTime(String name)
        {
            return Convert.ToDateTime(GetString(name));
        }
        public Object GetObject(String name)
        {
            return JSON.Decode(GetString(name));
        }
        public Object GetHashtable(String name)
        {
            string s = GetString(name);
            if (String.IsNullOrEmpty(s)) return new Hashtable();
            return (Hashtable)JSON.Decode(s);
        }
        public ArrayList GetArrayList(String name)
        {
            string s = GetString(name);
            if (String.IsNullOrEmpty(s)) return new ArrayList();
            return (ArrayList)JSON.Decode(s);
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
