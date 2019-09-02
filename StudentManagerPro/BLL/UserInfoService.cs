using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserInfoService
    {
        UserInfoDal userInfoDal = new UserInfoDal();
        public List<UserInfo> GetList()
        {
            return userInfoDal.GetList();
        }
    }
}
