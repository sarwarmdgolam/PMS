using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace Model
{
    public class CPortfolioDividend
    {
        public CPortfolioDividend()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private String _Company_Name;

        public String Company_Name
        {
            get { return _Company_Name; }
            set { _Company_Name = value; }
        }

        private String _Dividend_Type;

        public String Dividend_Type
        {
            get { return _Dividend_Type; }
            set { _Dividend_Type = value; }
        }


        private long _Total_Qty;

        public long Total_Qty
        {
            get { return _Total_Qty; }
            set { _Total_Qty = value; }
        }

        private Decimal _Rate;

        public Decimal Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }

    }
}
