using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class CCommon
    {
        /// <summary>
        /// Get Dictionary value from given key
        /// </summary>
        /// <param name="oParams"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static String DictionaryValue(Dictionary<String, String> oParams, String Key)
        {
            if (oParams.ContainsKey(Key))
                return oParams[Key];
            else
                return String.Empty ;
        }
    }
}
