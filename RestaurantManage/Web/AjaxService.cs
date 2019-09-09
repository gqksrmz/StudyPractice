using BLL;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web
{
    public class AjaxService : BaseService
    {
        TableInfoBLL tableInfoBLL = new TableInfoBLL();
        public AjaxService(HttpRequest Request, HttpResponse Response)
                    : base(Request, Response)
        {

        }
        public void SearchAllTable()
        {
            int pageIndex = GetInt("pageIndex");
            int pageSize = GetInt("pageSize");
            List<TableInfo> tableInfoList = tableInfoBLL.GetList(pageIndex, pageSize);
            Hashtable result = new Hashtable
            {
                ["data"] = tableInfoList,
                ["total"] = tableInfoBLL.GetTableCount()
            };
            RenderJson(result);
        }
    }
}
