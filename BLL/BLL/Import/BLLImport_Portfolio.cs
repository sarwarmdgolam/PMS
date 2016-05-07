
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAL;
using Model;
using Common;

namespace BLL
{
    public class BLLImport_Portfolio
    {

        List<CPortfolioDividend> CPortfolioDividendList;

        private String RemoveComma(String Value)
        {
            StringBuilder Return = new StringBuilder();
            String[] Array = Value.Split(',');
            for (int i = 0; i < Array.Length; i++)
            {
                Return.Append(Array[i]);
            }
            return String.IsNullOrEmpty(Return.ToString()) ? Value : Return.ToString();
        }
     
        private CResult InsertPortfolioStockInfo(ref int oRowNo, DataTable dtExcelList)
        {
            CResult CResult = new CResult();
            try
            {
                List<CPortfolioStock> CPortfolioStockList = new List<CPortfolioStock>();

                for (oRowNo = 1; oRowNo < dtExcelList.Rows.Count; oRowNo++)
                {
                    DataRow oRow = dtExcelList.Rows[oRowNo];
                    if (oRow[0].ToString().Contains("Total"))
                    {
                        break;
                    }
                    CPortfolioStock CPortfolioStock = new CPortfolioStock();
                    CPortfolioStock.Holdings_Type = "Holdings";
                    CPortfolioStock.Company_Name = oRow[0].ToString();
                    CPortfolioStock.Total_Qty = Convert.ToInt64(RemoveComma(oRow[1].ToString()));
                    CPortfolioStock.Saleable_Qty = Convert.ToInt64(RemoveComma(oRow[2].ToString()));
                    CPortfolioStock.Avg_Rate = Convert.ToDecimal(RemoveComma(oRow[3].ToString()));
                    CPortfolioStock.Cost_Amount = Convert.ToDecimal(RemoveComma(oRow[4].ToString()));
                    CPortfolioStock.Market_Price = Convert.ToDecimal(RemoveComma(oRow[5].ToString()));
                    CPortfolioStock.Market_Values = Convert.ToDecimal(RemoveComma(oRow[6].ToString()));
                    CPortfolioStock.Unrealize_Gain = Convert.ToDecimal(RemoveComma(oRow[7].ToString()));
                    CPortfolioStockList.Add(CPortfolioStock);
                }

                //Insert CPortfolioStock 
                foreach (CPortfolioStock CPortfolioStock in CPortfolioStockList)
                {
                    String Query = @"INSERT INTO tbl_Portfolio_Statement_Stock
                                        (
                                        Portfolio_ID
                                       ,Holdings_Type
                                       ,Company_Name
                                       ,Total_Qty
                                       ,Saleable_Qty
                                       ,Avg_Rate
                                       ,Cost_Amount
                                       ,Market_Price
                                       ,Market_Values
                                       ,Unrealize_Gain
                                        )
                                        VALUES
                                        (
                                        @Portfolio_ID
                                       ,@Holdings_Type
                                       ,@Company_Name
                                       ,@Total_Qty
                                       ,@Saleable_Qty
                                       ,@Avg_Rate
                                       ,@Cost_Amount
                                       ,@Market_Price
                                       ,@Market_Values
                                       ,@Unrealize_Gain
                                        )
                                       ";

                    SqlParameter[] objList = new SqlParameter[10];
                    objList[0] = new SqlParameter("@Portfolio_ID", new Guid());
                    objList[1] = new SqlParameter("@Holdings_Type", "Holdings");
                    objList[2] = new SqlParameter("@Company_Name", CPortfolioStock.Company_Name);
                    objList[3] = new SqlParameter("@Total_Qty", CPortfolioStock.Total_Qty);
                    objList[4] = new SqlParameter("@Saleable_Qty", CPortfolioStock.Saleable_Qty);
                    objList[5] = new SqlParameter("@Avg_Rate", CPortfolioStock.Avg_Rate);
                    objList[6] = new SqlParameter("@Cost_Amount", CPortfolioStock.Cost_Amount);
                    objList[7] = new SqlParameter("@Market_Price", CPortfolioStock.Market_Price);
                    objList[8] = new SqlParameter("@Market_Values", CPortfolioStock.Market_Values);
                    objList[9] = new SqlParameter("@Unrealize_Gain", CPortfolioStock.Unrealize_Gain);

                    DatabaseManager DatabaseManager = new DatabaseManager();
                    CResult.AffectedRows += ((CResult)DatabaseManager.ExecuteSQLQuery (Query, objList, true, CommandType.Text)).AffectedRows;
                }

            }
            catch (Exception ex)
            {
                CResult.Message = ex.Message;
            }
            return CResult;
        }

        
        private CResult InsertPortfolioBalanceInfo(ref int oRowNo, DataTable dtExcelList)
        {
            CResult CResult = new CResult();

            try
            {
                int oColNo = 0;
                DataRow PortfolioSummary = dtExcelList.Rows[oRowNo];
                oRowNo++;
                CPortfolioBalance CPortfolioBalance = new CPortfolioBalance();
                for (oColNo = 0; oColNo < dtExcelList.Columns.Count; oColNo++)
                {
                    if (PortfolioSummary[oColNo].ToString().Contains("Available"))
                    {
                        CPortfolioBalance.Available_Balance = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Immatured"))
                    {
                        CPortfolioBalance.Unmature_Balance = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Net Asset Value"))
                    {
                        CPortfolioBalance.Net_Asset_Value = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Unclear Cheque"))
                    {
                        CPortfolioBalance.Un_Clr_Chq_Balance = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Equity"))
                    {
                        CPortfolioBalance.Equity = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Ledger"))
                    {
                        CPortfolioBalance.Ledger_Balance = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Max Loan"))
                    {
                        CPortfolioBalance.Max_Loan = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Purchase Power"))
                    {
                        CPortfolioBalance.Purchase_Power = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Total Deposit"))
                    {
                        CPortfolioBalance.Total_Deposit = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Loan Ratio"))
                    {
                        CPortfolioBalance.Loan_Ration = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Total Withdraw"))
                    {
                        CPortfolioBalance.Total_Withdraw = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }
                    else if (PortfolioSummary[oColNo].ToString().Contains("Dishonor"))
                    {
                        CPortfolioBalance.Total_Dishonor = Convert.ToDecimal(RemoveComma(PortfolioSummary[++oColNo].ToString()));
                    }

                }

                //Insert portfolio Balance
                String Query = @"INSERT INTO tbl_Portfolio_Statement_Balance 
            (
            Portfolio_ID
           ,Investor_Code
           ,Transaction_Date
           ,Available_Balance
           ,Unmature_Balance
           ,Un_Clr_Chq_Balance
           ,Ledger_Balance
           ,Market_Value_Sec
           ,Net_Asset_Value
           ,Equity
           ,Max_Loan
           ,Total_Deposit
           ,Realized_Gainloss
           ,Total_Withdraw
           ,Total_Dishonor
           ,Transfer_IN
           ,Transfer_OUT
           ,Purchase_Power
           ,Loan_Ration
           ,Unrealized_Gainloss
           ,Net_GainLoss
            )
            VALUES
            (
            @Portfolio_ID
           ,@Investor_Code
           ,@Transaction_Date
           ,@Available_Balance
           ,@Unmature_Balance
           ,@Un_Clr_Chq_Balance
           ,@Ledger_Balance
           ,@Market_Value_Sec
           ,@Net_Asset_Value
           ,@Equity
           ,@Max_Loan
           ,@Total_Deposit
           ,@Realized_Gainloss
           ,@Total_Withdraw
           ,@Total_Dishonor
           ,@Transfer_IN
           ,@Transfer_OUT
           ,@Purchase_Power
           ,@Loan_Ration
           ,@Unrealized_Gainloss
           ,@Net_GainLoss
            )
            ";


                SqlParameter[] objList = new SqlParameter[21];
                objList[0] = new SqlParameter("@Portfolio_ID", new Guid());
                objList[1] = new SqlParameter("@Investor_Code", "Holdings");
                objList[2] = new SqlParameter("@Transaction_Date", DateTime.Now.Date);
                objList[3] = new SqlParameter("@Available_Balance", CPortfolioBalance.Available_Balance);
                objList[4] = new SqlParameter("@Unmature_Balance", CPortfolioBalance.Unmature_Balance);
                objList[5] = new SqlParameter("@Un_Clr_Chq_Balance", CPortfolioBalance.Un_Clr_Chq_Balance);
                objList[6] = new SqlParameter("@Ledger_Balance", CPortfolioBalance.Ledger_Balance);
                objList[7] = new SqlParameter("@Market_Value_Sec", CPortfolioBalance.Market_Value_Sec);
                objList[8] = new SqlParameter("@Net_Asset_Value", CPortfolioBalance.Net_Asset_Value);
                objList[9] = new SqlParameter("@Equity", CPortfolioBalance.Equity);
                objList[10] = new SqlParameter("@Max_Loan", CPortfolioBalance.Max_Loan);
                objList[11] = new SqlParameter("@Total_Deposit", CPortfolioBalance.Total_Deposit);
                objList[12] = new SqlParameter("@Realized_Gainloss", CPortfolioBalance.Realized_Gainloss);
                objList[13] = new SqlParameter("@Total_Withdraw", CPortfolioBalance.Total_Withdraw);
                objList[14] = new SqlParameter("@Total_Dishonor", CPortfolioBalance.Total_Dishonor);
                objList[15] = new SqlParameter("@Transfer_IN", CPortfolioBalance.Transfer_IN);
                objList[16] = new SqlParameter("@Transfer_OUT", CPortfolioBalance.Transfer_OUT);
                objList[17] = new SqlParameter("@Purchase_Power", CPortfolioBalance.Purchase_Power);
                objList[18] = new SqlParameter("@Loan_Ration", CPortfolioBalance.Loan_Ration);
                objList[19] = new SqlParameter("@Unrealized_Gainloss", CPortfolioBalance.Unrealized_Gainloss);
                objList[20] = new SqlParameter("@Net_GainLoss", CPortfolioBalance.Net_GainLoss);

                DatabaseManager DatabaseManager = new DatabaseManager();
                CResult = DatabaseManager.ExecuteSQLQuery(Query, objList, true, CommandType.Text);
            }
            catch(Exception ex)
            {
                CResult.Message = ex.Message;
            }

            return CResult;
        }

        private List<CPortfolioDividend> GetStockDividendInfo(ref int oCurrentRow, DataTable dtExcelList)
        {
            List<CPortfolioDividend> CPortfolioDividendList = new List<CPortfolioDividend>();
            int SL = 0;
            //Iterate throught the file in search of Bonur/Rights
            for (int j = oCurrentRow; j < dtExcelList.Rows.Count; j++)
            {
                DataRow oRow = dtExcelList.Rows[j]; // Row
                if (oRow[0].ToString().Contains("Stock Dividend Receivable and Locking"))
                {
                    oCurrentRow = j;
                    break;
                }
            }

            //Read  Bonur/Rights
            DataRow oHdrRow = dtExcelList.Rows[oCurrentRow]; // Header Row
            for (; oCurrentRow < dtExcelList.Rows.Count; oCurrentRow++)
            {
                CPortfolioDividend CPortfolioDividend = new CPortfolioDividend();
                DataRow oValueRow = dtExcelList.Rows[oCurrentRow]; // Value Row

                // exit if Dividend information is finished and IPO Application started
                if (oValueRow[0].ToString().Contains("IPO Application"))
                {
                    break;
                }
                else if (int.TryParse(oValueRow[0].ToString(), out SL)) // if Serial no Exists
                {
                    foreach (DataColumn oCol in dtExcelList.Columns)
                    {
                        if (!String.IsNullOrEmpty(oValueRow[1].ToString())) // check if value exists
                        {
                            if (oHdrRow[oCol].ToString().Contains("SL"))
                            {
                                CPortfolioDividend.Company_Name = oValueRow[oCol].ToString();
                            }
                            else if (oHdrRow[oCol].ToString().Contains("Company Name"))
                            {
                                CPortfolioDividend.Dividend_Type = oValueRow[oCol].ToString();
                            }
                            else if (oHdrRow[oCol].ToString().Contains("Trans Reference"))
                            {
                                CPortfolioDividend.Total_Qty = Convert.ToInt64(RemoveComma(oValueRow[oCol].ToString()));
                            }
                            else if (oHdrRow[oCol].ToString().Contains("Qty"))
                            {
                                CPortfolioDividend.Rate = Convert.ToDecimal(RemoveComma(oValueRow[oCol].ToString()));
                            }
                        }
                    }
                    CPortfolioDividendList.Add(CPortfolioDividend);
                }

            }

            return CPortfolioDividendList;
        }

        public CResult PopulateDataTableFromUploadedFile(DataTable dtExcelList)
        {
            CResult CResult = new CResult();
            StringBuilder sErrorOnLine = new StringBuilder();
            int oRowNo = 0;

            //Get Portfolio Stock Information 
            try
            {
                CResult = InsertPortfolioStockInfo(ref oRowNo, dtExcelList);

                //Get Portfolio Balance Information
                if (CResult.IsSuccess)
                {
                    CResult = InsertPortfolioBalanceInfo(ref  oRowNo, dtExcelList);
                    
                    //Get Bonus / rights
                    if (CResult.IsSuccess)
                    {
                        CPortfolioDividendList = GetStockDividendInfo(ref oRowNo, dtExcelList);
                    }
                }
            }
            catch (Exception ex)
            {
                CResult.Message = ex.Message;
            }
            return CResult;
        }
    }

}
