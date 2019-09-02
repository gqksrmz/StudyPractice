using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string userPass { get; set; }
        public DateTime RegTime { get; set; }
        public string Email { get; set; }
    }
}
