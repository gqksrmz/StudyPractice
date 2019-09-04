using System;
using System.Collections;
using System.Reflection;
using System.Web;
using Common;

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
            String methodName = Request["method"];

            try
            {
                Type type = this.GetType();
                MethodInfo method = type.GetMethod(methodName);
                if (method == null) throw new Exception("The method \"" + methodName + "\" is not found.");
                method.Invoke(this, null);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null) ex = ex.InnerException;
                Hashtable result = new Hashtable();
                result["success"] = false;
                result["error"] = -1;
                result["message"] = ex.Message;
                result["stackTrace"] = ex.StackTrace;
                String json = JSON.Encode(result);
                Response.Clear();
                Response.Write(json);
            }
            finally
            {

            }
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
