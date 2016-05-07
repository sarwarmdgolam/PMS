using System;
using System.Collections.Generic;
using System.Text;


namespace Authentication
{
    [Serializable]
    public class SessionVariables
    {
        public const string USER_LOGGEDIN = "USER_LoggedIn";
        public const string FEATURE_PRIVILEGE = "FEATURE_Privilege";
        public const string PRIVILEGED_FEATURE = "PRIVILEGED_FEATURE";
        public const string PRIVILEGED_MENU = "PRIVILEGED_MENU";

        public const string USER_NAME = "USER_NAME";
        public const string AUDIT_LOG_ID = "AUDIT_LOG_ID";

        public const string CHEQUE_NO_TP = "CHEQUE_NO_TP";
        public const string CHEQUE_NO_TC = "CHEQUE_NO_TC";
        public const string FWR_IS_CREATED = "FWR_IS_CREATED";
        public const string PAYMENT_IS_CREATED = "PAYMENT_IS_CREATED";
    }
}
