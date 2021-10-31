using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public static class TestUserClone
    {
        public static TestLibrary.TestUser CloneTestUserDal(DAL.TestUser testUserDAL)
        {
            if (testUserDAL == null) return null;
            return new TestLibrary.TestUser()
            {
                TestUser_Id = testUserDAL.Id,
                Test_Id = testUserDAL.Test.Id,
                Test_Title = testUserDAL.Test.Title,
                User_Id = testUserDAL.User.Id,
                User_FullName = testUserDAL.User.FirstName + " " + testUserDAL.User.LastName,
                Date = testUserDAL.Date,
                ResultPoints = testUserDAL.ResultPoints,
                ResultTest = testUserDAL.ResultTest
            };
        }

    }
}
