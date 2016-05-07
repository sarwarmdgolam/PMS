using System;
using System.Data;
using System.Configuration;
using System.Web;


/// <summary>
/// Summary description for CPortfolioBalance
/// </summary>
/// 
namespace Model
{
    public class CPortfolioBalance
    {
        public CPortfolioBalance()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private String _Investor_Code;

        public String Investor_Code
        {
            get { return _Investor_Code; }
            set { _Investor_Code = value; }
        }

        private DateTime _Transaction_Date;

        public DateTime Transaction_Date
        {
            get { return _Transaction_Date; }
            set { _Transaction_Date = value; }
        }

        private Decimal _Available_Balance;

        public Decimal Available_Balance
        {
            get { return _Available_Balance; }
            set { _Available_Balance = value; }
        }

        private Decimal _Unmature_Balance;

        public Decimal Unmature_Balance
        {
            get { return _Unmature_Balance; }
            set { _Unmature_Balance = value; }
        }

        private Decimal _Un_Clr_Chq_Balance;

        public Decimal Un_Clr_Chq_Balance
        {
            get { return _Un_Clr_Chq_Balance; }
            set { _Un_Clr_Chq_Balance = value; }
        }

        private Decimal _Ledger_Balance;

        public Decimal Ledger_Balance
        {
            get { return _Ledger_Balance; }
            set { _Ledger_Balance = value; }
        }

        private Decimal _Market_Value_Sec;

        public Decimal Market_Value_Sec
        {
            get { return _Market_Value_Sec; }
            set { _Market_Value_Sec = value; }
        }

        private Decimal _Net_Asset_Value;

        public Decimal Net_Asset_Value
        {
            get { return _Net_Asset_Value; }
            set { _Net_Asset_Value = value; }
        }

        private Decimal _Equity;

        public Decimal Equity
        {
            get { return _Equity; }
            set { _Equity = value; }
        }

        private Decimal _Max_Loan;

        public Decimal Max_Loan
        {
            get { return _Max_Loan; }
            set { _Max_Loan = value; }
        }

        private Decimal _Total_Deposit;

        public Decimal Total_Deposit
        {
            get { return _Total_Deposit; }
            set { _Total_Deposit = value; }
        }

        private Decimal _Realized_Gainloss;

        public Decimal Realized_Gainloss
        {
            get { return _Realized_Gainloss; }
            set { _Realized_Gainloss = value; }
        }

        private Decimal _Total_Withdraw;

        public Decimal Total_Withdraw
        {
            get { return _Total_Withdraw; }
            set { _Total_Withdraw = value; }
        }

        private Decimal _Total_Dishonor;

        public Decimal Total_Dishonor
        {
            get { return _Total_Dishonor; }
            set { _Total_Dishonor = value; }
        }

        private Decimal _Transfer_IN;

        public Decimal Transfer_IN
        {
            get { return _Transfer_IN; }
            set { _Transfer_IN = value; }
        }

        private Decimal _Transfer_OUT;

        public Decimal Transfer_OUT
        {
            get { return _Transfer_OUT; }
            set { _Transfer_OUT = value; }
        }

        private Decimal _Purchase_Power;

        public Decimal Purchase_Power
        {
            get { return _Purchase_Power; }
            set { _Purchase_Power = value; }
        }

        private Decimal _Loan_Ration;

        public Decimal Loan_Ration
        {
            get { return _Loan_Ration; }
            set { _Loan_Ration = value; }
        }

        private Decimal _Unrealized_Gainloss;

        public Decimal Unrealized_Gainloss
        {
            get { return _Unrealized_Gainloss; }
            set { _Unrealized_Gainloss = value; }
        }

        private Decimal _Net_GainLoss;

        public Decimal Net_GainLoss
        {
            get { return _Net_GainLoss; }
            set { _Net_GainLoss = value; }
        }

    }

}
