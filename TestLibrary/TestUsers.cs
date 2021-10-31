using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    [Serializable]
    public class TestUser
    {
        public int TestUser_Id { set; get; }
        public int Test_Id { set; get; }
        public string Test_Title { set; get; }
        public int User_Id { set; get; }
        public string User_FullName { set; get; }
        public DateTime Date { set; get; }
        public int? ResultPoints { set; get; } = null;
        public bool? ResultTest { set; get; } = null;

        
        
        
    }
}
