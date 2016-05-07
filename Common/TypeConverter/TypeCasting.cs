using System;
using System.Data;
using System.Configuration;
using System.Web;


/// <summary>
/// Summary description for Casting
/// </summary>
/// 

namespace Common
{
    public static class TypeCasting
    {
        public static String ToString(String Input)
        {
            if (String.IsNullOrEmpty(Input))
            {
                return DBNull.Value.ToString();
            }
            else
            {
                return Input;
            }
        }

        public static int Toint(String Input)
        {
            int Output = 0;
            int.TryParse(Input, out Output);
            return Output;
        }

        public static Int16 ToInt16(String Input)
        {
            Int16 Output = 0;
            Int16.TryParse(Input, out Output);
            return Output;
        }

        public static Int32 ToInt32(String Input)
        {
            Int32 Output = 0;
            Int32.TryParse(Input, out Output);
            return Output;
        }

        public static Int64 ToInt64(String Input)
        {
            Int64 Output = 0;
            Int64.TryParse(Input, out Output);
            return Output;
        }

        public static Decimal ToDecimal(String Input)
        {
            Decimal Output = Decimal.MinValue;
            Decimal.TryParse(Input, out Output);
            return Output;
        }

        public static bool ToBoolean(String Input)
        {
            bool Output = false;
            bool.TryParse(Input, out Output);
            return Output;
        }

        public static DateTime ToDateTime(String Input)
        {
            DateTime Output = DateTime.MinValue;
            if (DateTime.TryParse(Input, out Output))
                return Output;
            else
                return DateTime.Now.Date;
        }

        public static String DateToString(String Input)
        {
            DateTime Output = DateTime.MinValue;
            if (DateTime.TryParse(Input, out Output))
                return Output.ToString("dd-MMM-yyyy");
            else
                return String.Empty;
        }

        public static String DateToString(DateTime Input)
        {
            return Input.ToString("dd-MMM-yyyy");
        }
    }
}
