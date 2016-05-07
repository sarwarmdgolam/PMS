using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication
{
    [Serializable]
    public class AuthenticationEnum
    {
        public enum UserRolses
        {
            Administrator = 1,
            BBLOp = 2,
            EPL = 3,
            Customer = 6,
            SuperAdmin = 47
        }

        public enum SessionVariables
        {
            CENTRAL_LOGIN_USER_ID = 1,
            LOCAL_USER_ID = 2,
            USER_GROUP = 3,
            USER_NAME = 4,
            PASSWORD = 5,
            PROJECT_ID = 6,
            PIN_NO = 7,
            USER_FULL_NAME = 8,
            PROFILE_ID = 9,
            CIF = 10,
            CAPTCHA_IMAGE_TEXT = 11
        }


        public enum CentralUserStatus
        {
            InActive = 0,
            Active = 1

        }
    }
}
