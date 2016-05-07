using System;
using System.Data;
using System.Configuration;
using System.Web;


/// <summary>
/// Summary description for CPortfolioStock
/// </summary>
/// 
namespace Model
{
    public class CPortfolioStock
    {
        public CPortfolioStock()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private String _Portfolio_ID;

        public String Portfolio_ID
        {
            get { return _Portfolio_ID; }
            set { _Portfolio_ID = value; }
        }

        private String _Holdings_Type;

        public String Holdings_Type
        {
            get { return _Holdings_Type; }
            set { _Holdings_Type = value; }
        }

        private String _Company_Name;

        public String Company_Name
        {
            get { return _Company_Name; }
            set { _Company_Name = value; }
        }

        private long _Total_Qty;

        public long Total_Qty
        {
            get { return _Total_Qty; }
            set { _Total_Qty = value; }
        }

        private long _Saleable_Qty;

        public long Saleable_Qty
        {
            get { return _Saleable_Qty; }
            set { _Saleable_Qty = value; }
        }

        private Decimal _Avg_Rate;

        public Decimal Avg_Rate
        {
            get { return _Avg_Rate; }
            set { _Avg_Rate = value; }
        }

        private Decimal _Cost_Amount;

        public Decimal Cost_Amount
        {
            get { return _Cost_Amount; }
            set { _Cost_Amount = value; }
        }

        private Decimal _Market_Price;

        public Decimal Market_Price
        {
            get { return _Market_Price; }
            set { _Market_Price = value; }
        }

        private Decimal _Market_Values;

        public Decimal Market_Values
        {
            get { return _Market_Values; }
            set { _Market_Values = value; }
        }

        private Decimal _Unrealize_Gain;

        public Decimal Unrealize_Gain
        {
            get { return _Unrealize_Gain; }
            set { _Unrealize_Gain = value; }
        }

    }
}

