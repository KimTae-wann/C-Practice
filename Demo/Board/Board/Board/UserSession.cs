using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    // 로그인 세션을 관리하는 정적 클래스
    public static class UserSession
    {
        public static MemberVO CurrentUser { get; set; } = null;
        public static bool IsLoggedIn => CurrentUser != null;
        public static void Logout() { CurrentUser = null; }
    }
}
