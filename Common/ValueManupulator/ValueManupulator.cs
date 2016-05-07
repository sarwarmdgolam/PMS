using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class ValueManupulator
    {
        /// <summary>
        /// Remove Comma from given Text
        /// </summary>
        /// <param name="sText"></param>
        public static void RemoveCommaDelimeter(ref String sText)
        {
            StringBuilder sValue = new StringBuilder();
            String[] arrValue = sText.Split(',');
            for (int i = 0; i < arrValue.Length; i++)
            {
                sValue.Append(arrValue[i]);
            }
            sText = sValue.ToString();
        }

    }
}
