using SPTest.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTest
{
    class UserSession
    {
        public static MemberVO CurrentUser { get; set; } = null;
        public static bool IsLoggedIn => CurrentUser != null;
        public static void Logout() { CurrentUser = null; }
    }
}
