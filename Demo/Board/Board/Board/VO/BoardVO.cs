using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class BoardVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Password { get; set; }
        public DateTime IDate { get; set; }
        public int ReadCount { get; set; }
    }
}
